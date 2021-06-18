using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupDocs.Viewer.Live.Demos.UI.Models
{
    public class BarCodeResponse
    {
        public string BarCodeFileorText { get; set; }
        public int StatusCode { get; set; }
        public String Status { get; set; }
    }
}