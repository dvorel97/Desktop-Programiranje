using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Notes
    {
        public Notes() { db = new NotesModel(); }
        
        public IEnumerable<Note> getAllNotes(){
            return db.Notes;
        }

        public void delete(Note note)
        {
            db.Notes.Remove(note);
            db.SaveChanges();
        }

        public void update(Note note)
        {
            note.Content = "Novi content";
            db.Notes.AddOrUpdate(note);
            db.SaveChanges();
        }

        public void add()
        {
            Note nn = new Note();
            nn.Content = "Ovo je novi note";
            nn.Name = "Novi note";
            db.Notes.Add(nn);
            db.SaveChanges();
        }

        public override string ToString()
        {
            string notesString = "";

            foreach (Note note in db.Notes)
            {
                notesString += note.Id.ToString() + " " + note.Name.ToString() + " " + note.Content.ToString() + "\n";
            }

            return notesString;
        }

        private NotesModel db;
    
    }
}
