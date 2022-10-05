using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetMvc.Models
{
    public class ErrorResponse
    {
        /// <summary>
        /// The error message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        public ErrorResponse(string message)
        {
            this.Message = message;
        }
    }
}