using GroupDocs.Viewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Viewer_Modren_UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static string _licensePath = "D:\\License\\GroupDocs.Total.lic";
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            License l = new License();
            if (System.IO.File.Exists(_licensePath))
            {
                try
                {
                    l.SetLicense(_licensePath);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
