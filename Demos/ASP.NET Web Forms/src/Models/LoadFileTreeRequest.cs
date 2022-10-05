using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetWebForms.Models
{
    public class LoadFileTreeRequest
    {
        /// <summary>
        /// Folder path.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; } = string.Empty;
    }
}