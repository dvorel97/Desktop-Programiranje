using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace lab10
{
    class Notes
    {
        public Notes() { db = new NotesModel(); }

        public void addXML(string data)
        {
            var settings = new XmlReaderSettings();
            settings.Schemas.Add(null, "C:\\Users\\vub.ABSVUB\\Documents\\dvorel\\DesktopAplikacije\\lab10\\note.xsd");
            settings.ValidationType = ValidationType.Schema;

            var errors = new List<string>();
            settings.ValidationEventHandler += (s, e) => errors.Add(e.Message);

            


                using (XmlReader xmlReader = XmlReader.Create(new StringReader(data), settings))
                {
                    while (xmlReader.Read()) { }
                }


                if (errors.Any())
                {
                    string er = "";
                    foreach (var e in errors)
                        er += e.ToString() + " ";

                    MessageBox.Show(er);
                }
                else
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Note));
                    using (StringReader sr = new StringReader(data))
                    {
                        Note newNote = (Note)xs.Deserialize(sr);
                        db.Notes.Add(newNote);
                        db.SaveChanges();
                    }
                    
                    MessageBox.Show("Validan!");
                }
        }

        public string loadXMLdb()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Note>));

            using (StringWriter sw = new StringWriter())
            {
                xs.Serialize(sw, db.Notes.ToList());
                return sw.ToString();
            }
        }
        
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
