# VubChat — demo mrežne komunikacije u C#

Demonstracijski projekt za kolegij **Desktop aplikacije** na Veleučilištu u Bjelovaru.

Sustav se sastoji od tri projekta unutar jednog Visual Studio 2026 *Solution*-a:

| Projekt | Tip | Opis |
|---|---|---|
| `VubChat.Zajednicki` | Class Library (.NET 10) | Zajednički modeli, JSON protokol, framing za TCP |
| `VubChat.Server` | WinForms App (.NET 10) | Multi-client TCP chat server |
| `VubChat.Klijent` | WinForms App (.NET 10) | Chat klijent koji se spaja na server |

## Tehnologije

- **.NET 10** (`net10.0` za biblioteku, `net10.0-windows` za WinForms)
- **C# 14** (`<LangVersion>14.0</LangVersion>`)
- **Visual Studio 2026** (Format Version 12.00 · `VisualStudioVersion = 18.0`)
- Bez vanjskih NuGet ovisnosti — sve iz BCL-a (`System.Net.Sockets`, `System.Text.Json`)

## Što demo pokazuje

- Asinkroni TCP server koji prihvaća više klijenata istovremeno
- Korištenje `TcpListener` / `TcpClient` / `NetworkStream` s `async`/`await`
- Razmjenu strukturiranih objekata kroz **JSON** (`System.Text.Json`)
- **Framing protokol** s 4-byte length prefiksom (jer TCP je tok bez granica poruka)
- **Broadcast** logiku — server prosljeđuje poruke svim povezanim klijentima
- Thread-safe rukovanje aktivnim klijentima (`ConcurrentDictionary`)
- Pravilno **ažuriranje WinForms UI-ja** iz pozadinskih dretvi (`Invoke` / `BeginInvoke`)
- Graceful disconnect i `CancellationToken` integraciju
- Modernu uporabu C# 14 značajki: `record` tipovi, primary constructors, file-scoped namespaces, pattern matching, switch expressions

## Pokretanje

Pogledajte priložene **upute** (`UPUTE-VubChat.docx`) za detaljan vodič kako otvoriti projekt u Visual Studio 2026, postaviti ga za istovremeno pokretanje servera i više klijenata, te testirati mrežu.

Kratko:

```
1. Otvori VubChat.sln u Visual Studio 2026
2. Postavi Multiple Startup Projects: Server + Klijent
3. Pritisni F5
4. Pokreni server (Pokreni server), zatim spoji klijenta
5. Otvori još klijenata (debug → Start New Instance) za multi-user chat
```

## Struktura

```
VubChat/
├── VubChat.sln
├── README.md
├── .gitignore
└── src/
    ├── VubChat.Zajednicki/         ← zajednička biblioteka
    │   ├── Poruka.cs               ← record s podacima poruke
    │   ├── VrstaPoruke.cs          ← enum (Prijava/Odjava/Poruka/Sistem)
    │   ├── JsonProtokol.cs         ← (de)serijalizacija
    │   └── OkvirPoruke.cs          ← length-prefix framing
    ├── VubChat.Server/             ← serverski WinForms
    │   ├── Program.cs
    │   ├── GlavnaForma.cs          ← UI logika
    │   ├── GlavnaForma.Designer.cs ← UI dizajn
    │   ├── ChatServer.cs           ← TcpListener + Accept petlja
    │   └── PovezaniKlijent.cs      ← jedna spojena veza
    └── VubChat.Klijent/            ← klijent WinForms
        ├── Program.cs
        ├── GlavnaForma.cs
        ├── GlavnaForma.Designer.cs
        └── ChatKlijent.cs          ← TcpClient + receive petlja
```

## Autor

doc. dr. sc. Aleksander Radovan, prof. struč. stud.
Veleučilište u Bjelovaru · 2025./2026.
