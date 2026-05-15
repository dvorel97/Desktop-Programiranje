using Projekt.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

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
            NoteType.Personal,
            null){ }

        public virtual string GeneratePreview()
        {
            if (content == null) return string.Empty;
            return content.Length > 150
                ? content[..150] + "..."
                : content;
        }

        public string FormatMetadata()
        {
            int words = content?.Split(' ',
                StringSplitOptions.RemoveEmptyEntries).Length ?? 0;
            return $"Izmijenjeno: {LastModified:dd.MM.yyyy HH:mm}  |  " +
                   $"Rijeci: {words}  |  " +
                   $"Tagovi: {string.Join(", ", Tags)}";
        }

        public override string ToString()
        {
            return Title;
        }

        public abstract string ExportToHTML();
        public abstract string ExportToTXT();
        public abstract string ExportToXML();

        public delegate void ContentChangedHandler(Note note);
        [field: XmlIgnore]
        public event ContentChangedHandler OnContentChanged;
    }
}
