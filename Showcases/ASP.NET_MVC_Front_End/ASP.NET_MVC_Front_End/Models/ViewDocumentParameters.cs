
namespace MvcSample.Models
{
    public class ViewDocumentParameters : WatermarkedDocumentParameters
    {
        public ViewDocumentParameters()
        {
            UsePdf = true;
        }

        public bool UseHtmlBasedEngine { get; set; }
        public bool UsePngImagesForHtmlBasedEngine { get; set; }
        public int? Count { get; set; }
        public int? Width { get; set; }
        public int? Quality { get; set; }
        public bool UsePdf { get; set; }
        public int? PreloadPagesCount { get; set; }
        public bool ConvertWordDocumentsCompletely { get; set; }
        public string FileDisplayName { get; set; }
        public bool IgnoreDocumentAbsence { get; set; }
        public bool SupportPageRotation { get; set; }
        public bool SupportListOfContentControls { get; set; }
        public bool SupportListOfBookmarks { get; set; }
        public bool EmbedImagesIntoHtmlForWordFiles { get; set; }
        public string InstanceIdToken { get; set; }
        public string Locale { get; set; }
        public string PasswordForOpening { get; set; }
        public bool SaveFontsInAllFormats { get; set; }
        public string Callback { get; set; }
        public bool PrintWithWatermark  { get; set; }
    }

    public abstract class WatermarkedDocumentParameters : DocumentParameters
    {
        public string WatermarkText { get; set; }
        public int? WatermarkColor { get; set; }
        public WatermarkPosition? WatermarkPosition { get; set; }
        public float? WatermarkWidth { get; set; }
        public byte WatermarkOpacity { get; set; }
    }

    public abstract class DocumentParameters
    {
        public string Path { get; set; }
    }

    /// <summary>
    /// Position of a watermark on a document page
    /// </summary>
    public enum WatermarkPosition
    {
        /// <summary>
        /// Default value - from bottom left to top right corner
        /// </summary>
        Diagonal,
        TopLeft, TopCenter, TopRight, BottomLeft, BottomCenter, BottomRight
    }

    public class ViewDocumentResponse : OperationStatusResponse
    {
        public string path { get; set; }
        public string docType { get; set; }
        public string fileType { get; set; }
        public string url { get; set; }
        public string pdfDownloadUrl { get; set; }
        public string name { get; set; }
        public string[] imageUrls { get; set; }
        public bool lic { get; set; }
        public string pdfPrintUrl { get; set; }
        public string[] pageHtml { get; set; }
        public string[] pageCss { get; set; }
        public string documentDescription { get; set; }
        public string urlForResourcesInHtml { get; set; }
        public string sharedCss { get; set; }
    }

    public class OperationStatusResponse
    {
        public OperationStatusResponse()
        {
            success = true;
        }

        public bool success { get; set; }
    }
}

