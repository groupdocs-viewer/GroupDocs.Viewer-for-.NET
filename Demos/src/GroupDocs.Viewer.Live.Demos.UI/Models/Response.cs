using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;


namespace GroupDocs.Viewer.Live.Demos.UI.Models
{
	public class Response
	{
		public string DownloadFileLink { get; set; }
		public int StatusCode { get; set; }
		public string FileName { get; set; }
		public string FolderName { get; set; }
		public string ProductName { get; set; }
		public string OutputType { get; set; }
		public String Status { get; set; }
		public string Text { get; set; }
		public Collection<string> Results;
		public Exception exc { get; set; }
	}
}