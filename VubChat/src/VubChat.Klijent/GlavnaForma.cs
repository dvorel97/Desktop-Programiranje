using System.Net.Sockets;
using VubChat.Zajednicki;

namespace VubChat.Klijent;

public partial class GlavnaForma : Form
{
    private ChatKlijent? _klijent;

    public GlavnaForma()
    {
        InitializeComponent();
    }

    private void GlavnaForma_Load(object sender, EventArgs e)
    {
        txtHost.Text = "127.0.0.1";
        nudPort.Value = 50000;
        txtNadimak.Text = $"korisnik{Random.Shared.Next(100, 999)}";
        AzurirajStanje(spojen: false);

        // pošalji porukom na Enter
        txtPoruka.KeyDown += (s, args) =>
        {
            if (args.KeyCode == Keys.Enter && !args.Shift)
            {
                args.SuppressKeyPress = true;
                btnPosalji_Click(this, EventArgs.Empty);
            }
        };
    }

    protected override async void OnFormClosing(FormClosingEventArgs e)
    {
        if (_klijent is not null)
        {
            try { await _klijent.OdjaviAsync(); } catch { }
            await _klijent.DisposeAsync();
            _klijent = null;
        }
        base.OnFormClosing(e);
    }

    private async void btnSpoji_Click(object sender, EventArgs e)
    {
        string host = txtHost.Text.Trim();
        int port = (int)nudPort.Value;
        string nadimak = txtNadimak.Text.Trim();

        if (string.IsNullOrWhiteSpace(host))
        {
            MessageBox.Show(this, "Unesite adresu poslužitelja.", "Greška",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(nadimak))
        {
            MessageBox.Show(this, "Unesite nadimak.", "Greška",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnSpoji.Enabled = false;
        lblStatus.Text = $"○ Spajam se na {host}:{port}...";

        try
        {
            _klijent = new ChatKlijent();
            _klijent.PorukaPrimljena += OnPorukaPrimljena;
            _klijent.VezaPrekinuta += OnVezaPrekinuta;

            await _klijent.SpojiAsync(host, port, nadimak);

            AzurirajStanje(spojen: true);
            DodajSistemskuPoruku($"Spojeni ste kao '{nadimak}' na {host}:{port}.");
            txtPoruka.Focus();
        }
        catch (SocketException ex)
        {
            string razlog = ex.SocketErrorCode switch
            {
                SocketError.ConnectionRefused =>
                    "Server odbija vezu. Provjerite da li je pokrenut i da li sluša na tom portu.",
                SocketError.HostNotFound =>
                    "Adresa poslužitelja nije pronađena.",
                SocketError.TimedOut =>
                    "Isteklo vrijeme čekanja na server.",
                _ => $"Greška: {ex.Message}"
            };
            MessageBox.Show(this, razlog, "Spajanje neuspješno",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            await PocistiKlijentaAsync();
            AzurirajStanje(spojen: false);
        }
        catch (OperationCanceledException)
        {
            MessageBox.Show(this, "Isteklo vrijeme čekanja na server.",
                "Spajanje neuspješno",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            await PocistiKlijentaAsync();
            AzurirajStanje(spojen: false);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Neočekivana greška:\n{ex.Message}",
                "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            await PocistiKlijentaAsync();
            AzurirajStanje(spojen: false);
        }
    }

    private async void btnOdspoji_Click(object sender, EventArgs e)
    {
        if (_klijent is null) return;

        btnOdspoji.Enabled = false;
        try { await _klijent.OdjaviAsync(); } catch { }
        await PocistiKlijentaAsync();
        AzurirajStanje(spojen: false);
        DodajSistemskuPoruku("Odspojeni ste od servera.");
    }

    private async void btnPosalji_Click(object sender, EventArgs e)
    {
        if (_klijent is null || !_klijent.Spojen) return;

        string tekst = txtPoruka.Text.Trim();
        if (string.IsNullOrWhiteSpace(tekst)) return;

        string nadimak = tBNadimak.Text.Trim();
        try
        {
            await _klijent.PosaljiPorukuAsync(tekst, nadimak);
            txtPoruka.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Ne mogu poslati poruku:\n{ex.Message}",
                "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task PocistiKlijentaAsync()
    {
        if (_klijent is not null)
        {
            await _klijent.DisposeAsync();
            _klijent = null;
        }
    }

    private void OnPorukaPrimljena(Poruka poruka)
    {
        if (IsDisposed) return;

        try
        {
            BeginInvoke(() => PrikaziPoruku(poruka));
        }
        catch (ObjectDisposedException) { }
        catch (InvalidOperationException) { }
    }

    private void OnVezaPrekinuta(string? razlog)
    {
        if (IsDisposed) return;

        try
        {
            BeginInvoke(async () =>
            {
                DodajSistemskuPoruku(razlog ?? "Veza je prekinuta.");
                await PocistiKlijentaAsync();
                AzurirajStanje(spojen: false);
            });
        }
        catch (ObjectDisposedException) { }
        catch (InvalidOperationException) { }
    }

    private void PrikaziPoruku(Poruka p)
    {
        string vrijeme = p.Vrijeme.LocalDateTime.ToString("HH:mm:ss");

        Color boja = p.Vrsta switch
        {
            VrstaPoruke.PorukaSustava => Color.DarkOrange,
            VrstaPoruke.PorukaKorisnika when p.Posiljatelj == _klijent?.Nadimak => Color.SeaGreen,
            VrstaPoruke.PorukaKorisnika => Color.SteelBlue,
            _ => Color.Black
        };

        // vrijeme (sivo)
        DodajTekst($"[{vrijeme}] ", Color.Gray, FontStyle.Regular);

        // pošiljatelj
        if (p.Vrsta == VrstaPoruke.PorukaSustava)
        {
            DodajTekst($"{p.Sadrzaj}\r\n", boja, FontStyle.Italic);
        }
        else
        {
            DodajTekst($"{p.Posiljatelj}: ", boja, FontStyle.Bold);
            DodajTekst($"{p.Sadrzaj}\r\n", Color.Black, FontStyle.Regular);
        }

        // auto-scroll
        rtbChat.SelectionStart = rtbChat.TextLength;
        rtbChat.ScrollToCaret();
    }

    private void DodajSistemskuPoruku(string tekst)
    {
        DodajTekst($"[{DateTime.Now:HH:mm:ss}] ", Color.Gray, FontStyle.Regular);
        DodajTekst($"-- {tekst} --\r\n", Color.DimGray, FontStyle.Italic);
        rtbChat.SelectionStart = rtbChat.TextLength;
        rtbChat.ScrollToCaret();
    }

    private void DodajTekst(string tekst, Color boja, FontStyle stil)
    {
        rtbChat.SelectionStart = rtbChat.TextLength;
        rtbChat.SelectionLength = 0;
        rtbChat.SelectionColor = boja;
        rtbChat.SelectionFont = new Font(rtbChat.Font, stil);
        rtbChat.AppendText(tekst);
    }

    private void AzurirajStanje(bool spojen)
    {
        btnSpoji.Enabled = !spojen;
        btnOdspoji.Enabled = spojen;
        btnPosalji.Enabled = spojen;
        txtPoruka.Enabled = spojen;
        txtHost.Enabled = !spojen;
        nudPort.Enabled = !spojen;
        txtNadimak.Enabled = !spojen;

        lblStatus.Text = spojen
            ? $"● Spojen kao '{_klijent?.Nadimak}' na {txtHost.Text}:{nudPort.Value}"
            : "○ Niste spojeni";
        lblStatus.ForeColor = spojen ? Color.SeaGreen : Color.DimGray;
    }
}
