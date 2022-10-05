using System.Web.Http;

namespace GroupDocs.Viewer.AspNetWebForms
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.EnableCors();
            config.MapHttpAttributeRoutes();
        }
    }
}
