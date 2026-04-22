using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    public class Note
    {
        // ── Polja ─────────────────────────────────────
        protected string content;

        // ── Svojstva ──────────────────────────────────
        public Guid Id { get; private set; }
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
            }
        }
        public Note(string title, NoteType type)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Type = type;
            this.Tags = Array.Empty<string>();
            this.Created = DateTime.Now;
            this.LastModified = DateTime.Now;
        }

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
    }
}
