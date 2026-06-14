using Projekt.Services;
using Projekt.Forms;
using System.IO;

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
            repository.OnNoteModified += OnNoteModified;
        }

        NoteRepository<Note>.NoteModifiedHandler OnNoteModified => (note, action) =>
        {
            RefreshNoteList();
        };
        private void EditNote(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is not Note note) return;

            var noteEditor = new NoteEditor(note);
            noteEditor.ShowDialog();

            if (noteEditor.Saved)
                repository.Update(note);
        }


        private void NoteForge_Load(object sender, EventArgs e)
        {
            LoadFromDatabase();
            RefreshNoteList();

            cmbCategory.Items.Add("Sve");
            foreach (NoteType type in Enum.GetValues(typeof(NoteType)))
                cmbCategory.Items.Add(type);
            cmbCategory.SelectedIndex = 0;
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
                        repository.Add(note, sync: false);
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
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MarkdownNote newNote = new MarkdownNote();
            repository.Add(newNote, sync: true);

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
                cmbCategory_SelectedIndexChanged(sender, e);
                return;
            }

            var results = repository.Search(txtSearch.Text);
            lstNotes.Items.Clear();
            foreach (var result in results)
            {
                if (cmbCategory.SelectedItem is NoteType type && result.Note.Type != type)
                    continue;
                lstNotes.Items.Add(result.Note);
            }
            lstNotes.DisplayMember = "Title";
        }

        private async void TSExportHtml_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;

            await ExportService.ExportToHtml(repository.Notes, dialog.SelectedPath);

            MessageBox.Show("HTML export završen!", "NoteForge",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void TSExportMd_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;

            await ExportService.ExportToMd(repository.Notes, dialog.SelectedPath);

            MessageBox.Show("MD export završen!", "NoteForge",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void TSExportZip_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog();
            dialog.Filter = "ZIP|*.zip";
            dialog.FileName = "NoteForge_export.zip";
            if (dialog.ShowDialog() != DialogResult.OK) return;

            await ExportService.ExportToZip(repository.Notes, dialog.FileName);

            MessageBox.Show("ZIP export završen!", "NoteForge",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem is NoteType type)
            {
                lstNotes.Items.Clear();
                foreach (var note in repository.GetByType(type))
                    lstNotes.Items.Add(note);
                lstNotes.DisplayMember = "Title";
            }
            else
            {
                RefreshNoteList();
            }
        }

        private void TSImportMd_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Filter = "Markdown files|*.md";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() != DialogResult.OK) return;

            foreach (var file in dialog.FileNames)
            {
                string content = File.ReadAllText(file);
                string title = Path.GetFileNameWithoutExtension(file);
                var note = new MarkdownNote(Guid.NewGuid().ToString(), title, content);
                repository.Add(note);
            }
        }

        private void lstNotes_MouseDown(object sender, MouseEventArgs e)
        {
            int index = lstNotes.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
                lstNotes.SelectedIndex = index;
        }
    }
}
