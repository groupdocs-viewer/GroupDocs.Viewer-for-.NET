using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using GroupDocs.Viewer.Live.Demos.UI.Config;
using System.Web.Http;

namespace GroupDocs.Viewer.Live.Demos.UI
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{     
            /*
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );
            */

            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );

            // Set language name to load at application start
            //string _language = "EN";
            //SetResourceFile(_language, Request.Url.Host.Trim());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			RegisterCustomRoutes(RouteTable.Routes);

		}
		void Session_Start(object sender, EventArgs e)
		{
			//Check URL to set language resource file
			string _language = "EN";
			if (Request.Url.ToString().ToLower().Contains("zh."))
			{
				_language = "ZH";
			}
			SetResourceFile(_language, Request.Url.Host.Trim().Replace(".", ""));
		}

		private void SetResourceFile(string strLanguage, string HostName)
		{
			if (Session["GroupDocsAppResources"] == null)
				Session["GroupDocsAppResources"] = new GlobalAppHelper(HttpContext.Current, Application, "GroupDocsApps" + HostName, strLanguage);
		}

		void RegisterCustomRoutes(RouteCollection routes)
		{
            routes.Ignore("{resource}.axd/{*pathInfo}");
            

            routes.MapPageRoute(
                "GroupDocsAppsViewerRoute",
                "viewer",
                "~/ViewerApp/ViewerFileApp.aspx"
            );

            routes.MapPageRoute(
                "GroupDocsAppsViewerRouteTotal",
                "viewer/total",
                "~/ViewerApp/ViewerFileApp.aspx"
            );

            routes.MapPageRoute(
                "GroupDocsAppsViewerRoute2",
                "viewer/{fileformat}",
                "~/ViewerApp/ViewerFileApp.aspx"
            );

            routes.MapPageRoute(
                "GroupDocsAppsViewerAppRoute",
                "viewer/{foldername}/{filename}",
                "~/ViewerApp/Default.aspx"
            );

            routes.MapPageRoute(
                "GroupDocsAppsViewerAppRoute2",
                "viewer/{fileformat}/{foldername}/{filename}",
                "~/ViewerApp/Default.aspx"
            );
        }
	}
}