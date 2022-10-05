using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetWebForms.Models
{
    public class PrintPdfRequest
    {
        /// <summary>
        /// Unique file ID.
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; set; }

        /// <summary>
        /// File type e.g. "docx".
        /// </summary>
        [JsonProperty("fileType")]
        public string FileType { get; set; }

        /// <summary>
        /// Password to open the document.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}