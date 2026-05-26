using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using VubChat.Zajednicki;

namespace VubChat.Server;

/// <summary>
/// Asinkroni TCP chat server koji prihvaća više klijenata istovremeno
/// i broadcast-a sve poruke svim spojenim klijentima.
/// <para/>
/// Arhitektura:
/// <list type="bullet">
///   <item><see cref="TcpListener"/> sluša na zadanom portu</item>
///   <item>Za svakog klijenta pokreće se zasebna asinkrona petlja</item>
///   <item><see cref="ConcurrentDictionary{TKey, TValue}"/> drži aktivne klijente — thread-safe</item>
///   <item>Eventi se okidaju iz pozadinske dretve; GUI mora koristiti Invoke</item>
/// </list>
/// </summary>
internal sealed class ChatServer : IAsyncDisposable
{
    private readonly TcpListener _slusatelj;
    private readonly ConcurrentDictionary<Guid, PovezaniKlijent> _klijenti = new();
    private CancellationTokenSource? _cts;
    private Task? _petlja;

    public int Port { get; }
    public bool Pokrenut => _cts is { IsCancellationRequested: false };
    public int BrojKlijenata => _klijenti.Count;

    /// <summary>Event za log poruke (poziva se iz pozadinskih dretvi).</summary>
    public event Action<string>? LogPoruka;

    /// <summary>Event kad se promijeni broj klijenata (priključenje / odlazak).</summary>
    public event Action<int>? BrojKlijenataPromijenjen;

    public ChatServer(int port)
    {
        Port = port;
        _slusatelj = new TcpListener(IPAddress.Any, port);
    }

    /// <summary>Pokreće server (ne-blokirajuće).</summary>
    public void Pokreni()
    {
        if (Pokrenut) return;

        _cts = new CancellationTokenSource();
        _slusatelj.Start();
        Logiraj($"Server pokrenut na portu {Port}. Slušam veze...");

        _petlja = Task.Run(() => PrihvacajPetljaAsync(_cts.Token));
    }

    /// <summary>Zaustavlja server i zatvara sve aktivne veze.</summary>
    public async Task ZaustaviAsync()
    {
        if (!Pokrenut) return;

        Logiraj("Zaustavljam server...");

        _cts?.Cancel();
        try { _slusatelj.Stop(); } catch { /* ignore */ }

        // zatvori sve aktivne klijente
        foreach (var k in _klijenti.Values)
        {
            try { k.Dispose(); } catch { /* ignore */ }
        }
        _klijenti.Clear();
        BrojKlijenataPromijenjen?.Invoke(0);

        if (_petlja is not null)
        {
            try { await _petlja; } catch { /* ignore */ }
        }

        _cts?.Dispose();
        _cts = null;

        Logiraj("Server zaustavljen.");
    }

    /// <summary>
    /// Glavna petlja koja prihvaća dolazne TCP veze. Za svakog klijenta
    /// pokreće zasebnu zadaću da ne blokira sljedeće prihvaćanje.
    /// </summary>
    private async Task PrihvacajPetljaAsync(CancellationToken ct)
    {
        try
        {
            while (!ct.IsCancellationRequested)
            {
                TcpClient tcp = await _slusatelj.AcceptTcpClientAsync(ct);

                var klijent = new PovezaniKlijent(tcp, this);
                _klijenti[klijent.Id] = klijent;
                BrojKlijenataPromijenjen?.Invoke(_klijenti.Count);

                Logiraj($"Nova veza: {klijent.UdaljenaAdresa}");

                // svaki klijent dobiva svoju petlju u Task.Run da ne smetamo
                // ovoj petlji za AcceptTcpClient
                _ = Task.Run(() => klijent.PokreniPetljuAsync(ct), ct);
            }
        }
        catch (OperationCanceledException) { /* uredno gašenje */ }
        catch (ObjectDisposedException) { /* listener zatvoren */ }
        catch (SocketException ex) when (ex.SocketErrorCode == SocketError.Interrupted)
        {
            // Stop() je prekinuo blokirajući AcceptTcpClientAsync
        }
        catch (Exception ex)
        {
            Logiraj($"Greška u petlji prihvaćanja: {ex.Message}");
        }
    }

    /// <summary>
    /// Šalje poruku svim spojenim klijentima, opcionalno preskačući jednog.
    /// </summary>
    public async Task BroadcastAsync(
        Poruka poruka,
        Guid? osim = null,
        CancellationToken ct = default)
    {
        var zadace = new List<Task>(_klijenti.Count);

        foreach (var k in _klijenti.Values)
        {
            if (k.Id == osim) continue;
            zadace.Add(PosaljiSigurnoAsync(k, poruka, ct));
        }

        await Task.WhenAll(zadace);
    }

    public async Task PosaljiSigurnoAsync(
        PovezaniKlijent klijent,
        Poruka poruka,
        CancellationToken ct)
    {
        try
        {
            await klijent.PosaljiAsync(poruka, ct);
        }
        catch (Exception ex)
        {
            Logiraj($"Ne mogu poslati klijentu '{klijent.Nadimak}': {ex.Message}");
            UkloniKlijenta(klijent);
        }
    }

   
    /// <summary>Uklanja klijenta iz mape (poziva ga PovezaniKlijent kad mu petlja završi).</summary>
    internal void UkloniKlijenta(PovezaniKlijent klijent)
    {
        if (_klijenti.TryRemove(klijent.Id, out _))
        {
            Logiraj($"{klijent.Nadimak} ({klijent.UdaljenaAdresa}) odlazi.");
            BrojKlijenataPromijenjen?.Invoke(_klijenti.Count);

            // obavijesti ostale
            _ = BroadcastAsync(Poruka.Sustav($"{klijent.Nadimak} je napustio chat."));
        }

        klijent.Dispose();
    }

    /// <summary>Pomoćna metoda za logiranje (interno, dostupna i klijent objektima).</summary>
    internal void Logiraj(string poruka) => LogPoruka?.Invoke(poruka);

    public async ValueTask DisposeAsync()
    {
        await ZaustaviAsync();
    }

    public PovezaniKlijent PronadiKlijenta(string ime)
    {
        foreach (var k in _klijenti.Values)
        {
            if (k.Nadimak == ime)
            {
                return k;
            }
        }
        return null;
    }
}
