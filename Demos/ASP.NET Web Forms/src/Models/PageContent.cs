using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetWebForms.Models
{
    public class PageContent
    {
        /// <summary>
        /// Page number.
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// Page contents. It can be HTML or base64-encoded image.
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}