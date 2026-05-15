using Projekt.Services;
using Projekt.Forms;

namespace Projekt
{
    public partial class NoteForge : Form
    {
        private NoteRepository<Note> repository = new NoteRepository<Note>();
        public NoteForge()
        {
            InitializeComponent();
            lstNotes.SelectedIndexChanged += lstNotes_SelectedIndexChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void NoteForge_Load(object sender, EventArgs e)
        {
            LoadFromDatabase();
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
                        repository.Add(note, sync:false);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            MarkdownNote newNote = new MarkdownNote();
            repository.Add(newNote, sync:true);

            var noteEditor = new NoteEditor(newNote);
            noteEditor.ShowDialog();
            if (noteEditor.Saved)
            {
                repository.Update(newNote);
            }
            else
            {
                repository.Remove(newNote);
            }
            RefreshNoteList();
        }
        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is not Note note) return;
            txtPreview.Text = MDParser.Plain(note.Content) ?? "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                RefreshNoteList();
                return;
            }

            var results = repository.Search(txtSearch.Text);
            lstNotes.Items.Clear();
            foreach (var result in results)
                lstNotes.Items.Add(result.Note);
            lstNotes.DisplayMember = "Title";
        }
    }
}
