using System.IO;
using System.Threading.Tasks;
using GroupDocs.Viewer.AspNetWebForms.Core.Configuration;
using GroupDocs.Viewer.AspNetWebForms.Core.Entities;
using GroupDocs.Viewer.AspNetWebForms.Core.FileTypeResolution;
using GroupDocs.Viewer.AspNetWebForms.Core.Licensing;
using GroupDocs.Viewer.AspNetWebForms.Core.Viewers.Extensions;
using GroupDocs.Viewer.Options;
using Page = GroupDocs.Viewer.AspNetWebForms.Core.Entities.Page;

namespace GroupDocs.Viewer.AspNetWebForms.Core.Viewers
{
    internal class HtmlWithEmbeddedResourcesViewer : BaseViewer
    {
        private readonly ViewerConfig _config;

        public HtmlWithEmbeddedResourcesViewer(ViewerConfig config, 
            IViewerLicenser licenser, 
            IFileStorage fileStorage, 
            IFileTypeResolver fileTypeResolver, 
            IPageFormatter pageFormatter)
            : base(config, licenser, fileStorage, fileTypeResolver, pageFormatter)
        {
            _config = config;
        }

        public override string PageExtension => HtmlPage.Extension;

        public override Page CreatePage(int pageNumber, byte[] data)
            => new HtmlPage(pageNumber, data);

        public override Task<byte[]> GetPageResourceAsync(
            FileCredentials fileCredentials, int pageNumber, string resourceName) =>
            throw new System.NotImplementedException(
                $"{nameof(HtmlWithEmbeddedResourcesViewer)} does not support retrieving external HTML resources.");

        protected override ViewInfoOptions CreateViewInfoOptions() =>
            ViewInfoOptions.FromHtmlViewOptions(_config.HtmlViewOptions);

        protected override Page RenderPage(Viewer viewer, string filePath, int pageNumber)
        {
            var pageStream = new MemoryStream();
            var viewOptions = CreateViewOptions(pageStream);

            viewer.View(viewOptions, pageNumber);

            var bytes = pageStream.ToArray();
            var page = CreatePage(pageNumber, bytes);

            return page;
        }

        private HtmlViewOptions CreateViewOptions(MemoryStream pageStream)
        {
            var viewOptions = HtmlViewOptions.ForEmbeddedResources(_ => pageStream,
                (_, __) => { /*NOTE: Do nothing here*/ });

            viewOptions.CopyViewOptions(_config.HtmlViewOptions);

            return viewOptions;
        }
    }
}