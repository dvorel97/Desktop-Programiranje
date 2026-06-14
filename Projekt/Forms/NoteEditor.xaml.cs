using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projekt.Services;


namespace Projekt.Forms
{
    

    public partial class NoteEditor : Window
    {
        private Note note;
        public bool Saved { get; private set; } = true;

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
            if(note == null)
            {
                throw new ArgumentNullException(nameof(note));
                this.Close();
            }

            this.note = note;
            txtEditor.Text = note.Content;
            txtTitle.Text = note.Title;
            txtTags.Text = string.Join(", ", note.Tags);

            // Pokreni timer
            autoSaveTimer = new System.Windows.Threading.DispatcherTimer();
            autoSaveTimer.Interval = TimeSpan.FromSeconds(30);
            autoSaveTimer.Tick += async (s, e) => await AutoSaveAsync();
            autoSaveTimer.Start();

            //zaustavi timer kod zatvaranja
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
            note.Title = txtTitle.Text;
            note.Content = txtEditor.Text;
            note.Tags = txtTags.Text.Split(',',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Saved = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Saved = false;
            this.Close();
        }

        private async Task AutoSaveAsync()
        {
            if (note == null) return;

            note.Title = txtTitle.Text;
            note.Content = txtEditor.Text;
            note.Tags = txtTags.Text.Split(',',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            await Task.Run(() =>
            {
                var db = new Services.DBService();
                db.UpdateNote(note);
            });

            txtLastSaved.Text = $"Zadnje spremljeno: {DateTime.Now:HH:mm:ss}";
            OnAutoSaved?.Invoke(note, DateTime.Now);
        }
    }
}
