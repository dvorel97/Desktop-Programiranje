using System.Net;
using System.Net.Sockets;

namespace VubChat.Server;

public partial class GlavnaForma : Form
{
    private ChatServer? _server;

    public GlavnaForma()
    {
        InitializeComponent();
    }

    protected override async void OnFormClosing(FormClosingEventArgs e)
    {
        if (_server is not null)
        {
            await _server.DisposeAsync();
            _server = null;
        }
        base.OnFormClosing(e);
    }

    private void GlavnaForma_Load(object sender, EventArgs e)
    {
        nudPort.Value = 50000;
        PrikaziLokalneAdrese();
        AzurirajStanje(pokrenut: false);
    }

    private void PrikaziLokalneAdrese()
    {
        try
        {
            string ime = Dns.GetHostName();
            var adrese = Dns.GetHostAddresses(ime)
                .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                .Select(a => a.ToString())
                .ToArray();

            lblAdrese.Text = adrese.Length > 0
                ? $"Lokalne adrese: {string.Join(", ", adrese)}"
                : "Lokalne adrese: (nema IPv4 adresa)";
        }
        catch
        {
            lblAdrese.Text = "Lokalne adrese: (nedostupno)";
        }
    }

    private void btnPokreni_Click(object sender, EventArgs e)
    {
        try
        {
            int port = (int)nudPort.Value;
            _server = new ChatServer(port);

            // eventi se okidaju s pozadinske dretve — koristimo Invoke
            _server.LogPoruka += OnLogPoruka;
            _server.BrojKlijenataPromijenjen += OnBrojKlijenataPromijenjen;

            _server.Pokreni();
            AzurirajStanje(pokrenut: true);
        }
        catch (SocketException ex) when (ex.SocketErrorCode == SocketError.AddressAlreadyInUse)
        {
            MessageBox.Show(this,
                $"Port {nudPort.Value} je već zauzet.\nIzaberite drugi port ili zaustavite proces koji ga koristi.",
                "Port zauzet",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            _server = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show(this,
                $"Greška pri pokretanju servera:\n{ex.Message}",
                "Greška",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            _server = null;
        }
    }

    private async void btnZaustavi_Click(object sender, EventArgs e)
    {
        if (_server is null) return;

        btnZaustavi.Enabled = false;
        await _server.DisposeAsync();
        _server = null;
        AzurirajStanje(pokrenut: false);
    }

    private void btnOcistiLog_Click(object sender, EventArgs e)
    {
        lbLog.Items.Clear();
    }

    private void OnLogPoruka(string poruka)
    {
        if (IsDisposed) return;

        // event dolazi s pozadinske dretve — BeginInvoke je sigurniji jer ne čeka
        try
        {
            BeginInvoke(() =>
            {
                string redak = $"{DateTime.Now:HH:mm:ss} — {poruka}";
                lbLog.Items.Add(redak);
                lbLog.TopIndex = lbLog.Items.Count - 1; // auto-scroll
            });
        }
        catch (ObjectDisposedException) { /* forma se gasi */ }
        catch (InvalidOperationException) { /* handle nije kreiran */ }
    }

    private void OnBrojKlijenataPromijenjen(int n)
    {
        if (IsDisposed) return;

        try
        {
            BeginInvoke(() =>
            {
                lblKlijenti.Text = $"Spojenih klijenata: {n}";
            });
        }
        catch (ObjectDisposedException) { }
        catch (InvalidOperationException) { }
    }

    private void AzurirajStanje(bool pokrenut)
    {
        btnPokreni.Enabled = !pokrenut;
        btnZaustavi.Enabled = pokrenut;
        nudPort.Enabled = !pokrenut;
        lblStatus.Text = pokrenut ? $"● Server radi na portu {nudPort.Value}" : "○ Server zaustavljen";
        lblStatus.ForeColor = pokrenut ? Color.SeaGreen : Color.DimGray;

        if (!pokrenut)
        {
            lblKlijenti.Text = "Spojenih klijenata: 0";
        }
    }
}
