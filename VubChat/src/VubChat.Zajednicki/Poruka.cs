namespace VubChat.Zajednicki;

/// <summary>
/// Immutable model poruke koja se prenosi između klijenta i servera.
/// Koristi se record tip iz C# 9+ jer:
///   - automatski generira Equals/GetHashCode/ToString
///   - immutable (sigurno za multi-threaded okruženje)
///   - bezbolno serijalizira u JSON kroz System.Text.Json
/// </summary>
/// <param name="Vrsta">Vrsta poruke — vidi <see cref="VrstaPoruke"/>.</param>
/// <param name="Posiljatelj">Nadimak korisnika koji je poslao poruku.</param>
/// <param name="Sadrzaj">Tekst poruke (za sistemske: opis događaja).</param>
/// <param name="Vrijeme">Vrijeme nastanka poruke s časovnom zonom.</param>
public sealed record Poruka(
    VrstaPoruke Vrsta,
    string Posiljatelj,
    string Sadrzaj,
    DateTimeOffset Vrijeme,
    string Primatelj="")
{
    /// <summary>Pomoćna metoda za stvaranje sistemske poruke.</summary>
    public static Poruka Sustav(string sadrzaj) =>
        new(VrstaPoruke.PorukaSustava, "Sustav", sadrzaj, DateTimeOffset.Now);
}
