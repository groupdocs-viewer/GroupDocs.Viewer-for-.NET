using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetWebForms.Models
{
    public class UploadFileResponse
    {
        /// <summary>
        /// Unique file ID.
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; }

        /// <summary>
        /// .ctor
        /// </summary>
        public UploadFileResponse(string filePath)
        {
            Guid = filePath;
        }
    }
}