using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Projekt.Services
{
    public class ExportService
    {
        public static async Task ExportToHtml(IEnumerable<Note> notes, string outputDir)
        {
            await Task.Run(() =>
            {
                foreach (var note in notes)
                {
                    string html = note.ExportToHTML();
                    string fileName = $"{note.Title}.html";
                    string path = Path.Combine(outputDir, fileName);
                    File.WriteAllText(path, html);
                }
            });
        }

        public static async Task ExportToMd(IEnumerable<Note> notes, string outputDir)
        {
            await Task.Run(() =>
            {
                foreach (var note in notes)
                {
                    string path = Path.Combine(outputDir, $"{note.Title}.md");
                    File.WriteAllText(path, note.Content ?? "");
                }
            });
        }

        public static async Task ExportToZip(IEnumerable<Note> notes, string zipPath)
        {
            await Task.Run(() =>
            {
                using var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create);
                foreach (var note in notes)
                {
                    var htmlEntry = zip.CreateEntry($"{note.Title}.html");
                    using (var writer = new StreamWriter(htmlEntry.Open()))
                        writer.Write(note.ExportToHTML());

                    var mdEntry = zip.CreateEntry($"{note.Title}.md");
                    using (var writer = new StreamWriter(mdEntry.Open()))
                        writer.Write(note.Content ?? "");
                }
            });
        }
    }
}
