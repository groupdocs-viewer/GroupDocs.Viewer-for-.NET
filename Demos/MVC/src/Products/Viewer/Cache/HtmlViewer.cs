using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using System;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Viewer.MVC.Products.Viewer.Cache
{
    class HtmlViewer : IDisposable, ICustomViewer
    {
        private readonly string filePath;
        private readonly IViewerCache cache;

        private readonly GroupDocs.Viewer.Viewer viewer;
        private readonly HtmlViewOptions htmlViewOptions;
        private readonly PdfViewOptions pdfViewOptions;
        private readonly ViewInfoOptions viewInfoOptions;
        private static readonly Common.Config.GlobalConfiguration globalConfiguration = new Common.Config.GlobalConfiguration();

        public HtmlViewer(string filePath, IViewerCache cache, LoadOptions loadOptions, int pageNumber = -1, int newAngle = 0)
        {
            this.cache = cache;
            this.filePath = filePath;
            this.viewer = new GroupDocs.Viewer.Viewer(filePath, loadOptions);
            this.htmlViewOptions = this.CreateHtmlViewOptions(pageNumber, newAngle);
            this.pdfViewOptions = this.CreatePdfViewOptions();
            this.viewInfoOptions = ViewInfoOptions.FromHtmlViewOptions(this.htmlViewOptions);
        }

        public GroupDocs.Viewer.Viewer GetViewer()
        {
            return this.viewer;
        }

        private HtmlViewOptions CreateHtmlViewOptions(int passedPageNumber = -1, int newAngle = 0)
        {
            HtmlViewOptions htmlViewOptions = HtmlViewOptions.ForExternalResources(
                pageNumber =>
                {
                    string fileName = $"p{pageNumber}.html";
                    string cacheFilePath = this.cache.GetCacheFilePath(fileName);

                    return File.Create(cacheFilePath);
                },
                (pageNumber, resource) =>
                {
                    string fileName = $"p{pageNumber}_{resource.FileName}";
                    string cacheFilePath = this.cache.GetCacheFilePath(fileName);

                    return File.Create(cacheFilePath);
                },
                (pageNumber, resource) =>
                {
                    var urlPrefix = "/viewer/resources/" + Path.GetFileName(this.filePath).Replace(".", "_");
                    return $"{urlPrefix}/p{ pageNumber}_{ resource.FileName}";
                });

            htmlViewOptions.SpreadsheetOptions = SpreadsheetOptions.ForOnePagePerSheet();
            htmlViewOptions.SpreadsheetOptions.TextOverflowMode = TextOverflowMode.HideText;
            htmlViewOptions.SpreadsheetOptions.RenderGridLines = globalConfiguration.Viewer.GetShowGridLines();
            htmlViewOptions.SpreadsheetOptions.RenderHeadings = true;

            SetWatermarkOptions(htmlViewOptions);

            if (passedPageNumber >= 0 && newAngle != 0)
            {
                Rotation rotationAngle = GetRotationByAngle(newAngle);
                htmlViewOptions.RotatePage(passedPageNumber, rotationAngle);
            }

            return htmlViewOptions;
        }

        private PdfViewOptions CreatePdfViewOptions()
        {
            PdfViewOptions pdfViewOptions = new PdfViewOptions(
                () =>
                {
                    string fileName = "f.pdf";
                    string cacheFilePath = this.cache.GetCacheFilePath(fileName);

                    return File.Create(cacheFilePath);
                });

            pdfViewOptions.SpreadsheetOptions = SpreadsheetOptions.ForOnePagePerSheet();
            pdfViewOptions.SpreadsheetOptions.TextOverflowMode = TextOverflowMode.HideText;
            pdfViewOptions.SpreadsheetOptions.RenderGridLines = globalConfiguration.Viewer.GetShowGridLines();
            pdfViewOptions.SpreadsheetOptions.RenderHeadings = true;

            SetWatermarkOptions(pdfViewOptions);

            return pdfViewOptions;
        }

        private static Rotation GetRotationByAngle(int newAngle)
        {
            switch (newAngle)
            {
                case 90:
                    return Rotation.On90Degree;
                case 180:
                    return Rotation.On180Degree;
                case 270:
                    return Rotation.On270Degree;
                default:
                    return Rotation.On90Degree;
            }
        }

        public void CreateCache()
        {
            ViewInfo viewInfo = this.GetViewInfo();

            using (new CrossProcessLock(this.filePath))
            {
                int[] missingPages = this.GetPagesMissingFromCache(viewInfo.Pages);

                if (missingPages.Length > 0)
                {
                    this.viewer.View(this.htmlViewOptions, missingPages);
                }
            }
        }

        public Stream GetPdf()
        {
            string cacheKey = "f.pdf";

            if (!this.cache.Contains(cacheKey))
            {
                using (new CrossProcessLock(this.filePath))
                {
                    if (!this.cache.Contains(cacheKey))
                    {
                        this.viewer.View(this.pdfViewOptions);
                    }
                }
            }

            return this.cache.GetValue<Stream>(cacheKey);
        }

        public void Dispose()
        {
            this.viewer?.Dispose();
        }

        private static void SetWatermarkOptions(ViewOptions options)
        {
            Watermark watermark = null;

            if (!string.IsNullOrEmpty(globalConfiguration.Viewer.GetWatermarkText()))
            {
                // Set watermark properties
                watermark = new Watermark(globalConfiguration.Viewer.GetWatermarkText())
                {
                    Color = System.Drawing.Color.Blue,
                    Position = Position.Diagonal,
                };
            }

            if (watermark != null)
            {
                options.Watermark = watermark;
            }
        }

        public ViewInfo GetViewInfo()
        {
            string cacheKey = "view_info.dat";

            if (!this.cache.Contains(cacheKey))
            {
                using (new CrossProcessLock(this.filePath))
                {
                    if (!this.cache.Contains(cacheKey))
                    {
                        return this.cache.GetValue(cacheKey, () => this.ReadViewInfo());
                    }
                }
            }

            return this.cache.GetValue<ViewInfo>(cacheKey);
        }

        private ViewInfo ReadViewInfo()
        {
            ViewInfo viewInfo = this.viewer.GetViewInfo(this.viewInfoOptions);
            return viewInfo;
        }

        private int[] GetPagesMissingFromCache(IList<Page> pages)
        {
            List<int> missingPages = new List<int>();
            foreach (Page page in pages)
            {
                string pageKey = $"p{page.Number}.html";
                if (!this.cache.Contains(pageKey))
                {
                    missingPages.Add(page.Number);
                }
            }

            return missingPages.ToArray();
        }
    }
}