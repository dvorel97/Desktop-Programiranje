using System.Net.Sockets;
using VubChat.Zajednicki;

namespace VubChat.Klijent;

/// <summary>
/// TCP klijent koji se spaja na <see cref="VubChat.Server.ChatServer"/>,
/// šalje poruke i prima ih u pozadinskoj petlji.
/// <para/>
/// Eventi se okidaju s pozadinske dretve — GUI mora koristiti
/// <see cref="System.Windows.Forms.Control.Invoke(Delegate)"/> ili
/// <see cref="System.Windows.Forms.Control.BeginInvoke(Delegate)"/>.
/// </summary>
internal sealed class ChatKlijent : IAsyncDisposable
{
    private TcpClient? _tcp;
    private NetworkStream? _tok;
    private CancellationTokenSource? _cts;
    private Task? _primanjeZadaca;
    private readonly SemaphoreSlim _slanjeBrava = new(1, 1);

    /// <summary>Postavljen nakon uspješne prijave.</summary>
    public string Nadimak { get; private set; } = "";

    public bool Spojen => _tcp?.Connected == true;

    /// <summary>Okida se kad pristigne nova poruka.</summary>
    public event Action<Poruka>? PorukaPrimljena;

    /// <summary>Okida se kad veza prekine (uredno ili greškom).</summary>
    public event Action<string?>? VezaPrekinuta;

    /// <summary>
    /// Spaja se na server i šalje poruku Prijave s nadimkom.
    /// </summary>
    public async Task SpojiAsync(
        string host,
        int port,
        string nadimak,
        CancellationToken ct = default)
    {
        if (Spojen)
            throw new InvalidOperationException("Klijent je već spojen.");

        ArgumentException.ThrowIfNullOrWhiteSpace(host);
        ArgumentException.ThrowIfNullOrWhiteSpace(nadimak);

        _tcp = new TcpClient();

        // timeout 5 sekundi za spajanje
        using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
            ct, timeoutCts.Token);

        await _tcp.ConnectAsync(host, port, linkedCts.Token);
        _tok = _tcp.GetStream();
        Nadimak = nadimak;

        // odmah šalji prijavu
        var prijava = new Poruka(VrstaPoruke.Prijava, nadimak, "", DateTimeOffset.Now);
        await PosaljiInternoAsync(prijava, ct);

        // pokreni asinkronu petlju za primanje
        _cts = new CancellationTokenSource();
        _primanjeZadaca = Task.Run(() => PrimajPetljaAsync(_cts.Token));
    }

    /// <summary>Šalje korisničku poruku svim ostalim klijentima (kroz server).</summary>
    public async Task PosaljiPorukuAsync(string sadrzaj, string primatelj = "", CancellationToken ct = default)
    {
        if (!Spojen)
            throw new InvalidOperationException("Niste spojeni na server.");
        Poruka poruka;

        if (string.IsNullOrEmpty(primatelj.Trim()))
        {
            poruka = new Poruka(
                VrstaPoruke.PorukaKorisnika, Nadimak, sadrzaj, DateTimeOffset.Now);
        }
        else
        {
            poruka = new Poruka(
                VrstaPoruke.PrivatnaPoruka, Nadimak, sadrzaj, DateTimeOffset.Now, primatelj);
        }
        await PosaljiInternoAsync(poruka, ct);
    }

    /// <summary>Šalje urednu odjavu i prekida vezu.</summary>
    public async Task OdjaviAsync(CancellationToken ct = default)
    {
        if (!Spojen) return;

        try
        {
            var odjava = new Poruka(
                VrstaPoruke.Odjava, Nadimak, "", DateTimeOffset.Now);
            await PosaljiInternoAsync(odjava, ct);
        }
        catch
        {
            // ako server već ne sluša, ignoriraj
        }

        await ZatvoriAsync();
    }

    private async Task PosaljiInternoAsync(Poruka poruka, CancellationToken ct)
    {
        if (_tok is null) throw new InvalidOperationException("Tok nije inicijaliziran.");

        string json = JsonProtokol.Serijaliziraj(poruka);

        await _slanjeBrava.WaitAsync(ct);
        try
        {
            await OkvirPoruke.PosaljiAsync(_tok, json, ct);
        }
        finally
        {
            _slanjeBrava.Release();
        }
    }

    private async Task PrimajPetljaAsync(CancellationToken ct)
    {
        string? razlogPrekida = null;

        try
        {
            while (!ct.IsCancellationRequested && _tok is not null)
            {
                string? json = await OkvirPoruke.PrimiAsync(_tok, ct);
                if (json is null)
                {
                    razlogPrekida = "Server je zatvorio vezu.";
                    break;
                }

                Poruka? poruka = JsonProtokol.Deserijaliziraj(json);
                if (poruka is not null)
                {
                    PorukaPrimljena?.Invoke(poruka);
                }
            }
        }
        catch (OperationCanceledException) { /* uredno gašenje */ }
        catch (IOException ex)
        {
            razlogPrekida = $"Mrežna greška: {ex.Message}";
        }
        catch (Exception ex)
        {
            razlogPrekida = $"Neočekivana greška: {ex.Message}";
        }
        finally
        {
            VezaPrekinuta?.Invoke(razlogPrekida);
        }
    }

    private async Task ZatvoriAsync()
    {
        _cts?.Cancel();

        if (_tok is not null)
        {
            try { await _tok.DisposeAsync(); } catch { }
            _tok = null;
        }

        if (_tcp is not null)
        {
            try { _tcp.Close(); } catch { }
            _tcp = null;
        }

        if (_primanjeZadaca is not null)
        {
            try { await _primanjeZadaca; } catch { }
            _primanjeZadaca = null;
        }

        _cts?.Dispose();
        _cts = null;
    }

    public async ValueTask DisposeAsync()
    {
        await ZatvoriAsync();
        _slanjeBrava.Dispose();
    }
}
