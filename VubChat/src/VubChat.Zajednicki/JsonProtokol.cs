using System.Text.Json;
using System.Text.Json.Serialization;

namespace VubChat.Zajednicki;

/// <summary>
/// Centralizirana logika za (de)serijalizaciju poruka u JSON.
/// JSON je čovjeku čitljiv format — može se inspecitrati Wiresharkom,
/// Telnet-om ili netcat-om što ga čini idealnim za nastavu.
/// </summary>
public static class JsonProtokol
{
    /// <summary>
    /// Opcije serijalizacije:
    ///   - camelCase imena svojstava (standard u JSON svijetu)
    ///   - enum kao string ("Prijava" umjesto 0) — jasnije za debug
    ///   - bez whitespace-a (manje bajtova preko žice)
    /// </summary>
    private static readonly JsonSerializerOptions opcije = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false,
        Converters = { new JsonStringEnumConverter() }
    };

    /// <summary>Serijalizira poruku u JSON string.</summary>
    public static string Serijaliziraj(Poruka poruka) =>
        JsonSerializer.Serialize(poruka, opcije);

    /// <summary>
    /// Pokušava deserijalizirati JSON u poruku. Vraća null ako format nije ispravan
    /// — tako ne padamo na pokvarenim porukama od zlonamjernog klijenta.
    /// </summary>
    public static Poruka? Deserijaliziraj(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<Poruka>(json, opcije);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}
