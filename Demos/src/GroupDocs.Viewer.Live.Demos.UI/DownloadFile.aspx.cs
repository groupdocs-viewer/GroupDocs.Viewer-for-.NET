using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GroupDocs.Viewer.Live.Demos.UI.Models;
using GroupDocs.Viewer.Live.Demos.UI.Config;


namespace GroupDocs.Viewer.Live.Demos.UI
{
	public partial class WebForm1 : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";

            if (Request.QueryString["fileName"] != null)
			{
				string fileName = HttpUtility.UrlDecode(Request.QueryString["fileName"]);
				var result = FileManager.DownloadFile(fileName);

				if (result.IsSuccessStatusCode)
				{
					byte[] bytes = result.Content.ReadAsByteArrayAsync().Result;
					Response.Charset = "UTF-8";
					Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
					Response.ContentType = "application/octet-stream";
					string downFileName = fileName;

					if (fileName.Split('/').Length > 1)
						downFileName = fileName.Split('/')[fileName.Split('/').Length - 1];

					Response.AddHeader("Content-Disposition", "attachment; filename=\"" + downFileName + "\"");
					Response.BinaryWrite(bytes);
					Response.Flush();
					Response.End();
				}
			}
		}

	}
}
