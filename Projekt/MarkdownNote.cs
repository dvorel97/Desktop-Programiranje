using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Projekt.Services;

namespace Projekt
{
    public class MarkdownNote : Note
    {
        public MarkdownNote(
            string id, 
            string title,
            string content = "", 
            NoteType type = NoteType.Default,
            string[] tags = null)
            : base(id, title, content, type, tags) { }

        public MarkdownNote() : base(
            Guid.NewGuid().ToString(), "", "", NoteType.Default, null)
        { }

        public override string GeneratePreview()
        {
            string plain = MDParser.Plain(content ?? "");
            return plain.Length > 150 ? plain[..150] + "..." : plain;
        }

        public override string ExportToHTML()
        {
            return MDParser.HTML(content);
        }

        public override string ExportToTXT()
        {
            return $"{Title}\n{MDParser.Plain(content)}";
        }

        public override string ExportToXML()
        {
            XmlSerializer xs = new XmlSerializer(typeof(MarkdownNote));
            using StringWriter sw = new StringWriter();
            xs.Serialize(sw, this);
            return sw.ToString();
        }
    }
}
