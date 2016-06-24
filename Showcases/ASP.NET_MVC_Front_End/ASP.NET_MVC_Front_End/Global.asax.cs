using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private string _licensePath = "D:\\GroupDocs.Total.lic";
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            GroupDocs.Viewer.License lic = new GroupDocs.Viewer.License();
            lic.SetLicense(_licensePath);
        }
    }
}
