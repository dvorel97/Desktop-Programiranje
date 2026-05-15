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
    public class Note : IExportable
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

        public string ExportToHTML()
        {
            return $"<h1>{Title}</h1><p>{MDParser.HTML(content)}</p>";
        }
        
        public string ExportToTXT()
        {
            return $"{Title}\n{MDParser.Plain(content)}";
        }

        public string ExportToXML()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Note));

            using (StringWriter sw = new StringWriter())
            {
                xs.Serialize(sw, this);
                return sw.ToString();
            }
        }


        public delegate void ContentChangedHandler(Note note);
        [field: XmlIgnore]
        public event ContentChangedHandler OnContentChanged;
    }
}
