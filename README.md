Tema 24: NoteForge – Napredni editor bilješki s Markdown podrškom

Aplikacija za kreiranje i organizaciju bogatih bilješki s Markdown formatiranjem, tagovima, pretragom punog teksta i mogućnošću izvoza u HTML.
I1 – C# sintaksa
Enum za vrstu bilješke (Osobna / Posao / Studij / Ideja / Projekt)
Formatiranje stringa za prikaz metapodataka (datum izmjene, veličina, broj riječi)
Petlje za pretragu punog teksta, nizovi za pohranu tagova
Dokumentacijski komentari za Markdown parser metode

I2 – OOP osnove (apstrakcija, nasljeđivanje, polimorfizam)
Apstraktna klasa Note s apstraktnom metodom Render()
Klase MarkdownNote i PlainTextNote nasljeđuju Note
Sučelje IExportable s metodama ExportToHTML(), ExportToTXT(), ExportToPDF()
Virtualna metoda GeneratePreview(), enkapsulacija sadržaja bilješke

I3 – Napredni OOP, kolekcije i generici
List<Note> za bilješke, Dictionary<string, List<Note>> po tagu
HashSet<string> za jedinstvene tagove, SortedList<DateTime, Note> kronološki
Event OnNoteModified, vlastita iznimka NoteNotFoundException
Struktura SearchResult, generički NoteRepository<T>

I4 – Višedretvenost i asinkronost
Dretva za indeksiranje punog teksta u pozadini pri svakoj izmjeni
Task.Run() za export svih bilješki u HTML u pozadini
ReaderWriterLockSlim za zaštitu indeksa pretrage
Async/await za auto-save operacije, delegat za notifikaciju pri auto-save

I5 – Grafičko korisničko sučelje (WinForms i WPF)
Windows Forms: lista bilješki s pregledom i pretraživanjem
WPF: podijeljeni prikaz s Markdown editorom i HTML pregledom (WebBrowser kontrola)
3 prozora: lista bilješki, editor, pregled tagova i statistike
RichTextBox za uređivanje, ListBox za tagove, Timer za auto-save svakih 30s
TreeView po kategorijama, OpenFileDialog za uvoz .md datoteka, ListView za rezultate pretrage
MenuStrip s Markdown alatima, KeyDown za Ctrl+S, Ctrl+B i sl.

I6 – Komunikacija s okolinom (datoteke, baza, mreža)
XML serijalizacija metapodataka bilješki, pohrana sadržaja u .md datoteke
Čitanje i parsiranje Markdown datoteka, generiranje HTML iz Markdowna
Export svih bilješki kao ZIP arhiva s HTML i MD datotekama
Entity Framework Core + SQLite (tablice: Notes, Tags, SearchIndex, ExportHistory)
TCP klijent za sinkronizaciju bilješki s drugom instancom aplikacije
