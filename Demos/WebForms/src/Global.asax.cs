using System;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using GroupDocs.Viewer.WebForms.AppDomainGenerator;

namespace GroupDocs.Viewer.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Fix required to use several GroupDocs products in one project.
            // Set GroupDocs products assemblies names
            string viewerAssemblyName = "GroupDocs.Viewer.dll";

            // set GroupDocs.Viewer license
            DomainGenerator viewerDomainGenerator = new DomainGenerator(viewerAssemblyName, "GroupDocs.Viewer.License");
            viewerDomainGenerator.SetViewerLicense();

            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}