using GroupDocs.Viewer.Domain;
using System.Collections.Generic;

namespace GroupDocs.Viewer.WebForm.FrontEnd.BusinessLayer
{
    public class FileBrowserTreeDataResponse
    {
        public FileBrowserTreeNode[] nodes { get; set; }
        public int count { get; set; }
    }

    public class FileBrowserTreeNode
    {
        public string path { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string docType { get; set; }
        public string fileType { get; set; }
        public long size { get; set; }
        public long modifyTime { get; set; }

        public List<FileBrowserTreeNode> nodes { get; set; }
    }

    public class LoadFileBrowserTreeDataParameters : DocumentParameters
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public bool OrderAsc { get; set; }
        public string Filter { get; set; }
        public string FileTypes { get; set; }
        public bool Extended { get; set; }
        public string InstanceIdToken { get; set; }
        public string Callback { get; set; }
    }
}