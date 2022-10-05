using System;
using System.Text;

namespace GroupDocs.Viewer.AspNetWebForms.Core.Entities
{
    public class PngPage : Page
    {
        const string DATA_IMAGE = "data:image/png;base64,";

        public static string Extension => ".png";

        public override string GetContent() =>
            DATA_IMAGE + Convert.ToBase64String(Data);

        public override void SetContent(string content)
        {
            this.Data = content.StartsWith(DATA_IMAGE) 
                ? Encoding.UTF8.GetBytes(content) 
                : Encoding.UTF8.GetBytes(content.Substring(DATA_IMAGE.Length - 1));
        }

        public PngPage(int pageNumber, byte[] data) 
            : base(pageNumber, data)
        {
            
        }
    }
}