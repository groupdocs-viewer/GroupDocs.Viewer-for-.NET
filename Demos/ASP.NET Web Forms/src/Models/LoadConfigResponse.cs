using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetWebForms.Models
{
    public class LoadConfigResponse
    {
        /// <summary>
        /// Enables page selector control.
        /// </summary>
        [JsonProperty("pageSelector")]
        public bool PageSelector { get; set; }

        /// <summary>
        /// Enables download button.
        /// </summary>
        [JsonProperty("download")]
        public bool Download { get; set; }

        /// <summary>
        /// Enables upload.
        /// </summary>
        [JsonProperty("upload")]
        public bool Upload { get; set; }
        
        /// <summary>
        /// Enables printing.
        /// </summary>
        [JsonProperty("print")]
        public bool Print { get; set; }

        /// <summary>
        /// Enables file browser.
        /// </summary>
        [JsonProperty("browse")]
        public bool Browse { get; set; }

        /// <summary>
        /// Enables file rewrite.
        /// </summary>
        [JsonProperty("rewrite")]
        public bool Rewrite { get; set; }

        /// <summary>
        /// Enables right click.
        /// </summary>
        [JsonProperty("enableRightClick")]
        public bool EnableRightClick { get; set; }

        /// <summary>
        /// The default document to view.
        /// </summary>
        [JsonProperty("defaultDocument")]
        public string DefaultDocument { get; set; }

        /// <summary>
        /// Count pages to preload.
        /// </summary>
        [JsonProperty("preloadPageCount")]
        public int PreloadPageCount { get; set; }

        /// <summary>
        /// Enables zoom.
        /// </summary>
        [JsonProperty("zoom")]
        public bool Zoom { get; set; }

        /// <summary>
        /// Enables searching.
        /// </summary>
        [JsonProperty("search")]
        public bool Search { get; set; }

        /// <summary>
        /// Enables thumbnails.
        /// </summary>
        [JsonProperty("thumbnails")]
        public bool Thumbnails { get; set; }

        /// <summary>
        /// Image or HTML mode. 
        /// </summary>
        [JsonProperty("htmlMode")]
        public bool HtmlMode { get; set; }

        /// <summary>
        /// Enables printing
        /// </summary>
        [JsonProperty("printAllowed")]
        public bool PrintAllowed { get; set; }

        /// <summary>
        /// Enables rotation
        /// </summary>
        [JsonProperty("rotate")]
        public bool Rotate { get; set; }

        /// <summary>
        /// Enables saving of rotation state
        /// </summary>
        [JsonProperty("saveRotateState")]
        public bool SaveRotateState { get; set; }

        /// <summary>
        /// Default language e.g. "en".
        /// </summary>
        [JsonProperty("defaultLanguage")]
        public string DefaultLanguage { get; set; }

        /// <summary>
        /// Supported languages e.g. [ "en", "fr", "de" ]
        /// </summary>
        [JsonProperty("supportedLanguages")]
        public string[] SupportedLanguages { get; set; }

        /// <summary>
        /// Enables language menu.
        /// </summary>
        [JsonProperty("showLanguageMenu")]
        public bool ShowLanguageMenu { get; set; }
    }
}