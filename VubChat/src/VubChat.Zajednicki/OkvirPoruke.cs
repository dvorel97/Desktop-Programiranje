using System.Buffers.Binary;
using System.Net.Sockets;
using System.Text;

namespace VubChat.Zajednicki;

/// <summary>
/// TCP je tok bajtova bez ugrađenih granica poruka. Ako jedan klijent pošalje
/// dvije poruke uzastopce, primatelj ih može pročitati zajedno u jednom Read pozivu
/// — ili samo dio prve. Zato treba <b>framing protokol</b>.
/// <para/>
/// Naša shema je najjednostavnija moguća:
/// <code>
///   [ 4 bajta — duljina tijela (big-endian, Int32) ][ N bajtova tijela (UTF-8 JSON) ]
/// </code>
/// </summary>
public static class OkvirPoruke
{
    /// <summary>Najveća dopuštena duljina jedne poruke — zaštita od pohlepnih klijenata.</summary>
    public const int MaksDuljina = 1 * 1024 * 1024; // 1 MB

    /// <summary>Šalje string poruku kroz NetworkStream s 4-byte length prefiksom.</summary>
    public static async Task PosaljiAsync(
        NetworkStream tok,
        string poruka,
        CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(tok);
        ArgumentNullException.ThrowIfNull(poruka);

        byte[] tijelo = Encoding.UTF8.GetBytes(poruka);

        if (tijelo.Length > MaksDuljina)
            throw new InvalidOperationException(
                $"Poruka prevelika: {tijelo.Length} > {MaksDuljina} bajtova.");

        // zaglavlje: 4 bajta velikog endianskog Int32 s duljinom tijela
        byte[] zaglavlje = new byte[4];
        BinaryPrimitives.WriteInt32BigEndian(zaglavlje, tijelo.Length);

        await tok.WriteAsync(zaglavlje, ct);
        await tok.WriteAsync(tijelo, ct);
        await tok.FlushAsync(ct);
    }

    /// <summary>
    /// Čita jednu kompletnu poruku iz toka. Vraća <c>null</c> ako je veza
    /// uredno zatvorena.
    /// </summary>
    public static async Task<string?> PrimiAsync(
        NetworkStream tok,
        CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(tok);

        // 1) pročitaj 4 bajta zaglavlja
        byte[] zaglavlje = new byte[4];
        if (!await ProcitajTocnoAsync(tok, zaglavlje, ct))
            return null;

        int duljina = BinaryPrimitives.ReadInt32BigEndian(zaglavlje);

        if (duljina <= 0 || duljina > MaksDuljina)
            throw new InvalidDataException(
                $"Neispravna duljina poruke u zaglavlju: {duljina}.");

        // 2) pročitaj točno toliko bajtova tijela
        byte[] tijelo = new byte[duljina];
        if (!await ProcitajTocnoAsync(tok, tijelo, ct))
            return null;

        return Encoding.UTF8.GetString(tijelo);
    }

    /// <summary>
    /// Čita iz toka točno onoliko bajtova koliko stane u <paramref name="bafer"/>.
    /// Vraća <c>false</c> ako tok završi ranije (peer je zatvorio vezu).
    /// </summary>
    private static async Task<bool> ProcitajTocnoAsync(
        NetworkStream tok,
        byte[] bafer,
        CancellationToken ct)
    {
        int procitano = 0;
        while (procitano < bafer.Length)
        {
            int n = await tok.ReadAsync(
                bafer.AsMemory(procitano, bafer.Length - procitano), ct);

            if (n == 0) return false; // veza zatvorena
            procitano += n;
        }
        return true;
    }
}
