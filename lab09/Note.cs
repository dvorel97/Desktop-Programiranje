using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp {
    class Note {
        public Note() {

        }
        public Note(object id, object content, object name) {
            Id = (int)id;
            Content = (string)content;
            Name = (string)name;
        }

        public Note(string content, string name) {
            Content = content;
            Name = name;
        }

        public override string ToString() {
            return Name;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }

    }
}
