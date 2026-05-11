using System.Drawing.Printing;
using System.Text.RegularExpressions;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Projekt.Services
{
    public class MDParser
    {
        public static string HTML(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "<html><body></body></html>";

            string html = text;

            // ── Naslovi ───────────────────────────────
            html = Regex.Replace(html, @"^### (.+)$", "<h3>$1</h3>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"^## (.+)$", "<h2>$1</h2>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"^# (.+)$", "<h1>$1</h1>", RegexOptions.Multiline);

            // ── Podebljano i kurziv ───────────────────
            html = Regex.Replace(html, @"\*\*(.+?)\*\*", "<strong>$1</strong>");
            html = Regex.Replace(html, @"\*(.+?)\*", "<em>$1</em>");

            // ── Precrtano ─────────────────────────────
            html = Regex.Replace(html, @"~~(.+?)~~", "<s>$1</s>");

            // ── Inline kod ────────────────────────────
            html = Regex.Replace(html, @"`(.+?)`", "<code>$1</code>");

            // ── Lista ─────────────────────────────────
            html = Regex.Replace(html, @"^- (.+)$", "<li>$1</li>", RegexOptions.Multiline);

            // ── Novi redovi ───────────────────────────
            html = html.Replace("\r\n", "<br/>")
                       .Replace("\n", "<br/>");

            return  "<html><head><style>" +
                    "body { font-family: Segoe UI; font-size: 14px; padding: 12px; word-wrap: break-word; overflow-wrap: break-word; }" +
                    "h1 { font-size: 24px; }" +
                    "h2 { font-size: 20px; }" +
                    "h3 { font-size: 16px; }" +
                    "code { background: #f0f0f0; padding: 2px 4px; border-radius: 3px; word-wrap: break-word; }" +
                    "li { margin: 4px 0; }" +
                    "</style></head>" +
                    $"<body>{html}</body></html>";
        }
        public static string Plain(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            string plain = text;

            // Ukloni naslove
            plain = Regex.Replace(plain, @"^#{1,3} ", "", RegexOptions.Multiline);

            // Ukloni podebljano i kurziv
            plain = Regex.Replace(plain, @"\*\*(.+?)\*\*", "$1");
            plain = Regex.Replace(plain, @"\*(.+?)\*", "$1");

            // Ukloni precrtano
            plain = Regex.Replace(plain, @"~~(.+?)~~", "$1");

            // Ukloni inline kod
            plain = Regex.Replace(plain, @"`(.+?)`", "$1");

            // Ukloni liste
            plain = Regex.Replace(plain, @"^- ", "", RegexOptions.Multiline);

            return plain.Trim();
        }
    }
}