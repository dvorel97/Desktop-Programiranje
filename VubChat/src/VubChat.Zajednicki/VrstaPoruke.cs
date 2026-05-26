namespace VubChat.Zajednicki;

/// <summary>
/// Vrste poruka koje se razmjenjuju između klijenta i servera.
/// Sve poruke imaju istu strukturu, ali vrsta govori serveru i klijentu
/// kako ih obraditi.
/// </summary>
public enum VrstaPoruke
{
    /// <summary>Klijent se prijavljuje na chat (šalje samo nadimak).</summary>
    Prijava = 0,

    /// <summary>Klijent se odjavljuje s chata.</summary>
    Odjava = 1,

    /// <summary>Obična poruka korisnika koja se broadcasta svima.</summary>
    PorukaKorisnika = 2,

    /// <summary>Sistemska poruka (npr. "Marko se pridružio").</summary>
    PorukaSustava = 3,

    // LAB 13 zadatak
    PrivatnaPoruka = 4
}
