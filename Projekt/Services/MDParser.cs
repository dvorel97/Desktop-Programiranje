using System.Text.RegularExpressions;

namespace Projekt.Services
{
    public class MDParser
    {
        /// <summary>
        /// Pretvara Markdown tekst u kompletan HTML dokument s inline CSS stilovima.
        /// Podržava naslove (h1-h3), podebljano, kurziv, precrtano, inline kod i liste.
        /// </summary>
        /// <param name="text">Markdown tekst koji se parsira.</param>
        /// <returns>Kompletan HTML dokument kao string, spreman za prikaz u WebView2.</returns>
        public static string HTML(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "<html><body></body></html>";

            string html = text;

            html = Regex.Replace(html, @"^### (.+)$", "<h3>$1</h3>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"^## (.+)$", "<h2>$1</h2>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"^# (.+)$", "<h1>$1</h1>", RegexOptions.Multiline);

            html = Regex.Replace(html, @"\*\*(.+?)\*\*", "<strong>$1</strong>");
            html = Regex.Replace(html, @"\*(.+?)\*", "<em>$1</em>");

            html = Regex.Replace(html, @"~~(.+?)~~", "<s>$1</s>");

            html = Regex.Replace(html, @"`(.+?)`", "<code>$1</code>");

            html = Regex.Replace(html, @"^- (.+)$", "<li>$1</li>", RegexOptions.Multiline);

            html = html.Replace("\r\n", "<br/>")
                       .Replace("\n", "<br/>");

            return "<html><head><style>" +
                    "body { font-family: Segoe UI; font-size: 14px; padding: 12px; word-wrap: break-word; overflow-wrap: break-word; }" +
                    "h1 { font-size: 24px; }" +
                    "h2 { font-size: 20px; }" +
                    "h3 { font-size: 16px; }" +
                    "code { background: #f0f0f0; padding: 2px 4px; border-radius: 3px; word-wrap: break-word; }" +
                    "li { margin: 4px 0; }" +
                    "</style></head>" +
                    $"<body>{html}</body></html>";
        }

        /// <summary>
        /// Uklanja sve Markdown oznake iz teksta i vraća čisti plaintext.
        /// Korisno za prikaz previewa bilješke bez formatiranja.
        /// </summary>
        /// <param name="text">Markdown tekst iz kojeg se uklanjaju oznake.</param>
        /// <returns>Čisti tekst bez Markdown sintakse.</returns>
        public static string Plain(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            string plain = text;

            plain = Regex.Replace(plain, @"^#{1,3} ", "", RegexOptions.Multiline);
            plain = Regex.Replace(plain, @"\*\*(.+?)\*\*", "$1");
            plain = Regex.Replace(plain, @"\*(.+?)\*", "$1");
            plain = Regex.Replace(plain, @"~~(.+?)~~", "$1");
            plain = Regex.Replace(plain, @"`(.+?)`", "$1");
            plain = Regex.Replace(plain, @"^- ", "", RegexOptions.Multiline);

            return plain.Trim();
        }
    }
}
