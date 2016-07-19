namespace MvcSample.Models
{
    public class HtmlPageContent
    {
        public HtmlPageContent(string html, string css)
        {
            Html = html;
            Css = css;
        }

        public string Html { get; private set; }

        public string Css { get; private set; }
    }
}