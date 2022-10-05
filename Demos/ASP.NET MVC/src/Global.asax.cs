using GroupDocs.Viewer.AspNetMvc.Core.Configuration;
using GroupDocs.Viewer.AspNetMvc.Core.FileTypeResolution;
using GroupDocs.Viewer.AspNetMvc.Core.Licensing;
using GroupDocs.Viewer.AspNetMvc.Core.PageFormatting;
using GroupDocs.Viewer.AspNetMvc.Core.Viewers;
using GroupDocs.Viewer.AspNetMvc.Core;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using GroupDocs.Viewer.AspNetMvc.Core.Caching;
using GroupDocs.Viewer.AspNetMvc.Core.Storage;
using Unity;
using Unity.WebApi;

namespace GroupDocs.Viewer.AspNetMvc
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            UnityContainer container = new UnityContainer();
            ConfigureServices(container);

            GlobalConfiguration.Configuration.DependencyResolver = 
                new UnityDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void ConfigureServices(UnityContainer container)
        {
            var viewerType = ViewerType.HtmlWithEmbeddedResources;

            //Temporary license can be requested at https://purchase.groupdocs.com/temporary-license
            var licensePath = Server.MapPath("~/GroupDocs.Viewer.lic");
            var filesPath = Server.MapPath("~/Storage/Files");
            var cachePath = Server.MapPath("~/Storage/Cache");

            var uiConfig = UIConfig.Instance
                .SetViewerType(viewerType);
            var viewerConfig = ViewerConfig.Instance
                .SetLicensePath(licensePath);
            
            container.RegisterFactory<ViewerConfig>(c => viewerConfig);
            container.RegisterFactory<UIConfig>(c => uiConfig);
            container.RegisterFactory<IFileStorage>(c => new LocalFileStorage(filesPath));
            container.RegisterFactory<IFileCache>(c => new LocalFileCache(cachePath));
            container.RegisterType<IPageFormatter, NoopPageFormatter>();
            container.RegisterType<IViewerLicenser, LicenseFileViewerLicenser>();
            container.RegisterType<IFileTypeResolver, FileExtensionFileTypeResolver>();
            container.RegisterType<IAsyncLock, AsyncDuplicateLock>();

            container.RegisterFactory<IViewer>(c =>
            {
                IViewer viewer;
                switch (uiConfig.ViewerType)
                {
                    case ViewerType.HtmlWithExternalResources:
                        viewer = c.Resolve<HtmlWithExternalResourcesViewer>();
                        break;
                    case ViewerType.Jpg:
                        viewer = c.Resolve<JpgViewer>();
                        break;
                    case ViewerType.Png:
                        viewer = c.Resolve<PngViewer>();
                        break;
                    default:
                        viewer = c.Resolve<HtmlWithEmbeddedResourcesViewer>();
                        break;
                }

                var fileCache = c.Resolve<IFileCache>();
                var asyncLock = c.Resolve<IAsyncLock>();

                return new CachingViewer(viewer, fileCache, asyncLock);
            });
        }
    }
}
