using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupDocs.Viewer.Live.Demos.UI.ViewerApp
{
	public partial class Default : System.Web.UI.Page
	{
		public string fileName = "";
		public string productName = "";
		public string featureName = "";
		public string folderName = "";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Page.RouteData.Values["filename"] != null)
				{
					fileName = Page.RouteData.Values["filename"].ToString();
				}
				if (Page.RouteData.Values["Product"] != null)
				{
					productName = Page.RouteData.Values["Product"].ToString();
				}
				if (Page.RouteData.Values["fileformat"] != null)
				{
					featureName = Page.RouteData.Values["fileformat"].ToString();
				}
				if (Page.RouteData.Values["foldername"] != null)
				{
					folderName = Page.RouteData.Values["foldername"].ToString();
				}
			}
		}
	}
}