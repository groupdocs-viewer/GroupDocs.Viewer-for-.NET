namespace GroupDocs_Viewer_SharePoint.Layouts.GroupDocs_Viewer_SharePoint.BusinessLayer
{
    public class GetDocumentPageImageParameters : WatermarkedDocumentParameters
    {
        public int PageIndex { get; set; }
        public int? Width { get; set; }
        public int? Quality { get; set; }
        public bool UsePdf { get; set; }
        public bool IgnoreDocumentAbsence { get; set; }
        public bool UseHtmlBasedEngine { get; set; }
        public bool Rotate { get; set; }
        public string InstanceIdToken { get; set; }
        public string Locale { get; set; }
    }
}