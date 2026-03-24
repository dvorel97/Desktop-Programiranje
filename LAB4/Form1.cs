namespace LAB4
{
    public partial class Form1 : Form
    {
        Oglas[] oglasi;
        int brojac = 0;
        public Form1()
        {
            InitializeComponent();
            oglasi = new Oglas[100];

            tbSlika.Enabled = false;
            tbVideo.Enabled = false;
            AzurirajPrikaz();
        }

        private void AzurirajPrikaz()
        {
            tbOglasi.Clear();
            for (int i = 0; i < brojac; i++)
            {
                tbOglasi.AppendText(oglasi[i].ToString() + "\n\n");
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string naslov = tbNaslov.Text.Trim();
            string opis = tbTekst.Text.Trim();
            string autor = Environment.UserName;


            if (cbSlikovni.Checked && cbVideo.Checked)
            {
                MessageBox.Show(
                    "Oglas ne može biti i slikovni i video!",
                    "Greška", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (cbSlikovni.Checked)
                {
                    string slika = tbSlika.Text;
                    oglasi[brojac] = new SlikovniOglas(naslov, opis, autor, slika);
                }
                else if (cbVideo.Checked)
                {
                    string video = tbVideo.Text;
                    oglasi[brojac] = new VideoOglas(naslov, opis, autor, video);
                }
                else
                {
                    oglasi[brojac] = new Oglas(naslov, opis, autor);
                }
                brojac++;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                AzurirajPrikaz();
            }
        }

        private void cbSlikovni_CheckedChanged(object sender, EventArgs e)
        {
            tbSlika.Enabled = cbSlikovni.Checked;
            // Isključi drugi checkbox
            if (cbSlikovni.Checked)
                cbVideo.Checked = false;
        }

        private void cbVideo_CheckedChanged(object sender, EventArgs e)
        {
            tbVideo.Enabled = cbVideo.Checked;
            // Isključi drugi checkbox
            if (cbVideo.Checked)
                cbSlikovni.Checked = false;
        }
    }
}
