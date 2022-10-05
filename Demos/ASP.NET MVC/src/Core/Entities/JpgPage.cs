using System;
using System.Text;

namespace GroupDocs.Viewer.AspNetMvc.Core.Entities
{
    public class JpgPage : Page
    {
        const string DATA_IMAGE = "data:image/jpeg;base64,";

        public static string Extension => ".jpeg";

        public override string GetContent()
        {
            return DATA_IMAGE + Convert.ToBase64String(Data);
        }

        public override void SetContent(string content)
        {
            this.Data = content.StartsWith(DATA_IMAGE) 
                ? Encoding.UTF8.GetBytes(content) 
                : Encoding.UTF8.GetBytes(content.Substring(DATA_IMAGE.Length - 1));
        }

        public JpgPage(int pageNumber, byte[] data) 
            : base(pageNumber, data)
        {
            
        }
    }
}