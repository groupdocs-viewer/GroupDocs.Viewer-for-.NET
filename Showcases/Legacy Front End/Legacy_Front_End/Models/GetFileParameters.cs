
namespace MvcSample.Models
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