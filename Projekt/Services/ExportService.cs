using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
    }
}
