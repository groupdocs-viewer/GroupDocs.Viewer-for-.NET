using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupDocs.Viewer.Live.Demos.UI.Models
{
    public class FileUploadResult
    {
        public string LocalFilePath { get; set; }
        public string FileName { get; set; }
        public string FolderId { get; set; }
        public long FileLength { get; set; }
    }
}