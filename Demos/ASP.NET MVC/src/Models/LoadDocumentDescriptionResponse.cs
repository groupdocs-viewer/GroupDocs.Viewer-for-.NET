using System.Collections.Generic;
using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetMvc.Models
{
    public class LoadDocumentDescriptionResponse
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
        /// Indicates if printing of the document is allowed.
        /// </summary>
        [JsonProperty("printAllowed")]
        public bool PrintAllowed { get; set; }
        
        /// <summary>
        /// Document pages.
        /// </summary>
        [JsonProperty("pages")]
        public List<PageDescription> Pages { get; set; }
    }
}