using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    public class Note
    {
        protected string content;

        public string Id { get; private set; }
        public string Title { get; set; }
        public NoteType Type { get; set; }
        public string[] Tags { get; set; }
        public DateTime Created { get; private set; }
        public DateTime LastModified { get; private set; }

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

        public delegate void ContentChangedHandler(Note note);
        public event ContentChangedHandler OnContentChanged;
    }
}
