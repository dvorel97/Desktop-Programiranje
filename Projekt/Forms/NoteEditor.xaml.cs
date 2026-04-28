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


namespace Projekt.Forms
{
    public partial class NoteEditor : Window
    {
        // ── Polja ─────────────────────────────────────
        private Note _note;
        public bool Saved { get; private set; } = false;

        // ── Konstruktori ──────────────────────────────
        public NoteEditor()
        {
            InitializeComponent();
            _note = null;
        }

        public NoteEditor(Note note) : this()
        {
            _note = note;
            txtTitle.Text = note.Title;
            txtEditor.Text = note.Content ?? "";
            txtTags.Text = string.Join(", ", note.Tags);
            cmbType.SelectedIndex = (int)note.Type;
        }

        // ── Event handleri ────────────────────────────
        private void txtEditor_TextChanged(object sender,
            System.Windows.Controls.TextChangedEventArgs e)
        {
            txtPreview.Text = txtEditor.Text;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                System.Windows.MessageBox.Show("Upiši naslov!", "NoteForge",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_note == null)
                _note = new Note(txtTitle.Text, GetSelectedType());

            _note.Title = txtTitle.Text;
            _note.Content = txtEditor.Text;
            _note.Tags = txtTags.Text.Split(',',
                StringSplitOptions.RemoveEmptyEntries);

            Saved = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // ── Metode ────────────────────────────────────
        public Note GetNote() => _note;

        private NoteType GetSelectedType()
        {
            return cmbType.SelectedIndex switch
            {
                0 => NoteType.Personal,
                1 => NoteType.Work,
                2 => NoteType.Study,
                3 => NoteType.Idea,
                4 => NoteType.Project,
                _ => NoteType.Personal
            };
        }
    }
}