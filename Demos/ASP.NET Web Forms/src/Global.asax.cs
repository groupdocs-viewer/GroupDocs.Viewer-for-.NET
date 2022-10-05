using System;
using System.Web;
using System.Web.Http;
using Unity.WebApi;
using Unity;
using GroupDocs.Viewer.AspNetWebForms.Core.Caching;
using GroupDocs.Viewer.AspNetWebForms.Core.Configuration;
using GroupDocs.Viewer.AspNetWebForms.Core.FileTypeResolution;
using GroupDocs.Viewer.AspNetWebForms.Core.Licensing;
using GroupDocs.Viewer.AspNetWebForms.Core.PageFormatting;
using GroupDocs.Viewer.AspNetWebForms.Core.Storage;
using GroupDocs.Viewer.AspNetWebForms.Core.Viewers;
using GroupDocs.Viewer.AspNetWebForms.Core;

namespace GroupDocs.Viewer.AspNetWebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            UnityContainer container = new UnityContainer();
            ConfigureServices(container);

            GlobalConfiguration.Configuration.DependencyResolver =
                new UnityDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
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