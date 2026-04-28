using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            RefreshNotes();
        }

        private void btnNewNote_Click(object sender, EventArgs e) {
            Notes.AddNote(new Note(tbNote.Text, tbNewNote.Text));
            RefreshNotes();
        }

        private void RefreshNotes() {
            var notes = Notes.GetNotes();
            //reset forme za unos
            lbNotes.Items.Clear();
            tbNote.Text = "";
            tbNewNote.Text = "";
            foreach (var note in notes) {
                lbNotes.Items.Add(note);
            }
        }

        private void lbNotes_MouseDoubleClick(object sender, MouseEventArgs e) {
            var note = Notes.GetNote(((Note)lbNotes.Items[lbNotes.SelectedIndex]).Id);
            tbNote.Text = note.Content;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            bool result = Notes.UpdateNote((Note)lbNotes.Items[lbNotes.SelectedIndex], tbNote.Text);
            if (result == false) {
                MessageBox.Show("Greška prilikom pohrane");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = Notes.DeleteNote((Note)lbNotes.Items[lbNotes.SelectedIndex]);
            if (result == false)
            {
                MessageBox.Show("Greška prilikom brisanja");
            }
            RefreshNotes();
        }
    }
}
