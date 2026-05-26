using System.Net.Sockets;
using VubChat.Zajednicki;

namespace VubChat.Server;

/// <summary>
/// Predstavlja jedan TCP klijent koji je spojen na server.
/// Sluša poruke u petlji i preusmjerava ih nazad <see cref="ChatServer"/>-u.
/// </summary>
internal sealed class PovezaniKlijent : IDisposable
{
    private readonly TcpClient _tcp;
    private readonly NetworkStream _tok;
    private readonly ChatServer _server;
    private readonly SemaphoreSlim _slanjeBrava = new(1, 1);

    /// <summary>Jedinstveni identifikator klijenta unutar sesije.</summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>Nadimak — postavlja se kad klijent pošalje Prijavu.</summary>
    public string Nadimak { get; private set; } = "(anonimni)";

    /// <summary>Udaljena IP adresa i port klijenta.</summary>
    public string UdaljenaAdresa { get; }

    public PovezaniKlijent(TcpClient tcp, ChatServer server)
    {
        _tcp = tcp;
        _tok = tcp.GetStream();
        _server = server;
        UdaljenaAdresa = tcp.Client.RemoteEndPoint?.ToString() ?? "?";
    }

    /// <summary>
    /// Šalje jednu poruku ovom klijentu. Koristi semaphore brave kako bi
    /// spriječio isprepletene zapise iz različitih dretvi.
    /// </summary>
    public async Task PosaljiAsync(Poruka poruka, CancellationToken ct = default)
    {
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

    /// <summary>
    /// Glavna petlja za primanje poruka od ovog klijenta.
    /// Završava kad klijent zatvori vezu ili se dogodi greška.
    /// </summary>
    public async Task PokreniPetljuAsync(CancellationToken ct)
    {
        try
        {
            while (!ct.IsCancellationRequested)
            {
                string? json = await OkvirPoruke.PrimiAsync(_tok, ct);
                if (json is null) break; // veza zatvorena

                Poruka? poruka = JsonProtokol.Deserijaliziraj(json);
                if (poruka is null)
                {
                    _server.Logiraj($"[{UdaljenaAdresa}] neispravan JSON, ignoriram.");
                    continue;
                }

                await ObradiPorukuAsync(poruka, ct);

                if (poruka.Vrsta == VrstaPoruke.Odjava) break;
            }
        }
        catch (OperationCanceledException) { /* uredno gašenje */ }
        catch (IOException) { /* veza prekinuta */ }
        catch (Exception ex)
        {
            _server.Logiraj($"[{Nadimak}] greška: {ex.Message}");
        }
        finally
        {
            _server.UkloniKlijenta(this);
        }
    }

    private async Task ObradiPorukuAsync(Poruka poruka, CancellationToken ct)
    {
        switch (poruka.Vrsta)
        {
            case VrstaPoruke.Prijava:
                Nadimak = string.IsNullOrWhiteSpace(poruka.Posiljatelj)
                    ? "(anonimni)" : poruka.Posiljatelj.Trim();

                _server.Logiraj($"{UdaljenaAdresa} se prijavio kao '{Nadimak}'.");

                await _server.BroadcastAsync(
                    Poruka.Sustav($"{Nadimak} se pridružio chatu."),
                    ct: ct);
                break;

            case VrstaPoruke.PorukaKorisnika:
                _server.Logiraj($"<{Nadimak}> {poruka.Sadrzaj}");
                await _server.BroadcastAsync(poruka, ct: ct);
                break;

            case VrstaPoruke.Odjava:
                _server.Logiraj($"{Nadimak} se odjavljuje.");
                break;

            case VrstaPoruke.PorukaSustava:
                // klijent ne smije slati sistemske poruke — ignoriraj
                break;
            case VrstaPoruke.PrivatnaPoruka:
                PovezaniKlijent primatelj = _server.PronadiKlijenta(poruka.Primatelj);
                try
                {
                    await _server.PosaljiSigurnoAsync(primatelj, poruka, ct: ct);
                }
                catch (Exception ex) {
                    MessageBox.Show("Nije moguce pronaci korisnika!");
                }
                break;
        }
    }

    public void Dispose()
    {
        try { _tok.Dispose(); } catch { /* ignore */ }
        try { _tcp.Dispose(); } catch { /* ignore */ }
        _slanjeBrava.Dispose();
    }
}
