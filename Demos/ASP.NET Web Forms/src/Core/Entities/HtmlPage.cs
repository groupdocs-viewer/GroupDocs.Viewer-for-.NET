using System.Text;

namespace GroupDocs.Viewer.AspNetWebForms.Core.Entities
{
    public class HtmlPage : Page
    {
        public static string Extension => ".html";

        public override string GetContent() =>
            Encoding.UTF8.GetString(Data);

        public override void SetContent(string contents)
        {
            Data = Encoding.UTF8.GetBytes(contents);
        }

        public HtmlPage(int pageNumber, byte[] data) 
            : base(pageNumber, data)
        {
        }
    }
}