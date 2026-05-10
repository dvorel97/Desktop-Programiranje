using Projekt.Services;
using Projekt.Forms;

namespace Projekt
{
    public partial class NoteForge : Form
    {
        private NoteRepository repository = new NoteRepository();
        public NoteForge()
        {
            InitializeComponent();

            lstNotes.SelectedIndexChanged += lstNotes_SelectedIndexChanged;
        }

        private void NoteForge_Load(object sender, EventArgs e)
        {
            LoadFromDatabase();
            RefreshNoteList();
            RefreshNoteList();
        }

        private void LoadFromDatabase()
        {
            try
            {
                var db = new DBService();
                var notes = db.LoadNotes();

                foreach (var note in notes)
                {
                    bool exists = repository.Notes
                        .Any(n => n.Id == note.Id);

                    if (!exists)
                        repository.Add(note);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Greška pri učitavanju: {ex.Message}",
                    "NoteForge",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
            var noteEditor = new NoteEditor();
            noteEditor.ShowDialog();
        }
        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is not Note note) return;
            txtPreview.Text = note.Content ?? "";
        }

    }
}
