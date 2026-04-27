using Projekt.Forms;

namespace Projekt
{
    public partial class NoteForge : Form
    {
        private NoteRepository repository = new NoteRepository();
        public NoteForge()
        {
            InitializeComponent();
            LoadSampleData();
            RefreshNoteList();
        }

        private void LoadSampleData()
        {
            repository.Add(new Note("Arhitektura projekta", NoteType.Project));
            repository.Add(new Note("Sprint Review", NoteType.Work));
            repository.Add(new Note("OOP biljeske", NoteType.Study));
            repository.Add(new Note("Ideja: dark mode", NoteType.Idea));
            repository.Add(new Note("Osobni ciljevi", NoteType.Personal));
        }

        private void RefreshNoteList()
        {
            lstNotes.Items.Clear();
            foreach (var note in repository.Notes)
                lstNotes.Items.Add(note);
            lstNotes.DisplayMember = "Title";
        }

        private void DeleteNote(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is not Note note) return;

            var result = MessageBox.Show(
                $"Obrisati \"{note.Title}\"?",
                "NoteForge",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                repository.Remove(note);
                RefreshNoteList();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            lstNotes.Items.Clear();

            var results = string.IsNullOrEmpty(query)
                ? repository.Notes
                : repository.Search(query);

            foreach (var note in results)
                lstNotes.Items.Add(note);

            lstNotes.DisplayMember = "Title";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var splitView = new NoteEditor();
            splitView.ShowDialog();
        }
    }
}
