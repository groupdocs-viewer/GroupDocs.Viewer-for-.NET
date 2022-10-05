using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetMvc.Models
{
    public class LoadDocumentDescriptionRequest
    {
        /// <summary>
        /// File unique ID.
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; set; }

        /// <summary>
        /// File type e.g "docx".
        /// </summary>
        [JsonProperty("fileType")]
        public string FileType { get; set; }

        /// <summary>
        /// The password to open a document.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}