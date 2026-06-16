using System;
using System.Windows;
using System.Windows.Input;
using Projekt.Services;
using System.Windows.Forms;

namespace Projekt.Forms
{
    public partial class NoteEditor : Window
    {
        private Note note;
        private readonly DBService _db = new();

        public bool Saved { get; private set; } = false;

        public delegate void AutoSavedHandler(Note note, DateTime savedAt);
        public event AutoSavedHandler OnAutoSaved;

        private System.Windows.Threading.DispatcherTimer autoSaveTimer;

        public NoteEditor()
        {
            InitializeComponent();
            webPreview.NavigationCompleted += (s, e) => { };
            webPreview.EnsureCoreWebView2Async();
        }

        public NoteEditor(Note note) : this()
        {
            this.note = note ?? throw new ArgumentNullException(nameof(note));

            txtEditor.Text = note.Content;
            txtTitle.Text = note.Title;
            txtTags.Text = string.Join(", ", note.Tags);

            autoSaveTimer = new System.Windows.Threading.DispatcherTimer();
            autoSaveTimer.Interval = TimeSpan.FromSeconds(30);
            autoSaveTimer.Tick += async (s, e) => await AutoSaveAsync();
            autoSaveTimer.Start();

            this.Closing += (s, e) => autoSaveTimer.Stop();
        }

        private async void txtEditor_TextChanged(object sender,
            System.Windows.Controls.TextChangedEventArgs e)
        {
            await webPreview.EnsureCoreWebView2Async();
            webPreview.NavigateToString(MDParser.HTML(txtEditor.Text));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ApplyChangesToNote();
            Saved = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Saved = false;
            this.Close();
        }

        private void ApplyChangesToNote()
        {
            note.Title = txtTitle.Text;
            note.Content = txtEditor.Text;
            note.Tags = txtTags.Text.Split(',',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            txtLastSaved.Text = $"Zadnje spremljeno: {DateTime.Now:HH:mm:ss}";
        }

        private void InsertMarkdown(string prefix, string suffix = "")
        {
            int start = txtEditor.SelectionStart;
            int len = txtEditor.SelectionLength;
            if (len > 0)
            {
                string selected = txtEditor.SelectedText;
                txtEditor.Text = txtEditor.Text.Remove(start, len)
                    .Insert(start, $"{prefix}{selected}{suffix}");
                txtEditor.SelectionStart = start;
                txtEditor.SelectionLength = len + prefix.Length + suffix.Length;
            }
            else
            {
                txtEditor.Text = txtEditor.Text.Insert(start, prefix + suffix);
                txtEditor.SelectionStart = start + prefix.Length;
            }
        }

        private void MenuBold_Click(object sender, RoutedEventArgs e) => InsertMarkdown("**", "**");
        private void MenuItalic_Click(object sender, RoutedEventArgs e) => InsertMarkdown("*", "*");
        private void MenuH1_Click(object sender, RoutedEventArgs e) => InsertMarkdown("# ");
        private void MenuH2_Click(object sender, RoutedEventArgs e) => InsertMarkdown("## ");
        private void MenuList_Click(object sender, RoutedEventArgs e) => InsertMarkdown("- ");
        private void MenuCode_Click(object sender, RoutedEventArgs e) => InsertMarkdown("`", "`");

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                ApplyChangesToNote();
                Saved = true;
            }
            else if (e.Key == Key.X && Keyboard.Modifiers == ModifierKeys.Control)
            {
                var result = System.Windows.Forms.MessageBox.Show(
                    "Zatvori NoteEditor?",
                    "NoteForge",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Close();
                }
            }
            else if (e.Key == Key.I && Keyboard.Modifiers == ModifierKeys.Control)
            {
                InsertMarkdown("*", "*");
            }
            else if (e.Key == Key.B && Keyboard.Modifiers == ModifierKeys.Control)
            {
                InsertMarkdown("**", "**");
            }
        }

        private async System.Threading.Tasks.Task AutoSaveAsync()
        {
            if (note == null) return;

            ApplyChangesToNote();

            await System.Threading.Tasks.Task.Run(() => _db.UpdateNote(note));

            OnAutoSaved?.Invoke(note, DateTime.Now);
        }
    }
}
