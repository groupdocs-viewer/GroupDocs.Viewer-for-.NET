using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetWebForms.Models
{
    public class PageDescription : PageContent
    {
        /// <summary>
        /// Page with in pixels.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Page height in pixels.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Worksheet name for spreadsheets.
        /// </summary>
        [JsonProperty("sheetName")]
        public string SheetName { get; set; }
    }
}