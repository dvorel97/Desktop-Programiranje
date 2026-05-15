using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Projekt.Services;

namespace Projekt
{
    public class MarkdownNote : Note
    {
        public MarkdownNote(string id, string title,
            string content = "", NoteType type = NoteType.Personal,
            string[] tags = null)
            : base(id, title, content, type, tags) { }

        public MarkdownNote() : base(
            Guid.NewGuid().ToString(), "", "", NoteType.Personal, null)
        { }

        public override string GeneratePreview()
        {
            string plain = Services.MDParser.Plain(content ?? "");
            return plain.Length > 150 ? plain[..150] + "..." : plain;
        }

        public override string ExportToHTML()
        {
            return $"<h1>{Title}</h1><p>{MDParser.HTML(content)}</p>";
        }

        public override string ExportToTXT()
        {
            return $"{Title}\n{MDParser.Plain(content)}";
        }

        public override string ExportToXML()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Note));

            using (StringWriter sw = new StringWriter())
            {
                xs.Serialize(sw, this);
                return sw.ToString();
            }
        }
    }
}
