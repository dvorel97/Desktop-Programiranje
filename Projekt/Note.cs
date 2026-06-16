using Projekt.Services;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Projekt
{
    public abstract class Note : IExportable
    {
        protected string content;

        public string Id { get; set; }
        public string Title { get; set; }
        public NoteType Type { get; set; }
        public string[] Tags { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public string Content
        {
            get => content;
            set
            {
                content = value;
                LastModified = DateTime.Now;
                OnContentChanged?.Invoke(this);
            }
        }
        public Note(
            string id, 
            string title, 
            string content = "", 
            NoteType type=NoteType.Default, 
            string[] tags= null)
        {
            this.Id = id;
            this.Title = title;
            this.Type = type;
            this.Tags = tags ?? Array.Empty<string>();
            this.Content = content;
        }

        public Note() : this(
            Guid.NewGuid().ToString(),
            "",
            "",
            NoteType.Default,
            null){ }


        public abstract string GeneratePreview();
        public abstract string ExportToHTML();
        public abstract string ExportToTXT();
        public abstract string ExportToXML();

        public delegate void ContentChangedHandler(Note note);
        [field: XmlIgnore]
        public event ContentChangedHandler OnContentChanged;
    }
}
