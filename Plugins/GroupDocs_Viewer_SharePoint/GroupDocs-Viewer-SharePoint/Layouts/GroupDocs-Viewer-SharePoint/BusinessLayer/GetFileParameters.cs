
namespace GroupDocs_Viewer_SharePoint.Layouts.GroupDocs_Viewer_SharePoint.BusinessLayer
{
    public class GetFileParameters : WatermarkedDocumentParameters
    {
        public bool GetPdf { get; set; }
        public bool IsPrintable { get; set; }
        public string DisplayName { get; set; }
        public bool IgnoreDocumentAbsence { get; set; }
        public bool UseHtmlBasedEngine { get; set; }
        public bool SupportPageRotation { get; set; }
        public string InstanceIdToken { get; set; }
    }
}