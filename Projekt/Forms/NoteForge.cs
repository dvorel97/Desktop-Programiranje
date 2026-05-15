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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Note newNote = new Note();
            var noteEditor = new NoteEditor(newNote);
            noteEditor.ShowDialog();
            if (noteEditor.Saved)
            {
                repository.Add(newNote);
                RefreshNoteList();
            }
        }
        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is not Note note) return;
            txtPreview.Text = MDParser.Plain(note.Content) ?? "";
        }

    }
}
