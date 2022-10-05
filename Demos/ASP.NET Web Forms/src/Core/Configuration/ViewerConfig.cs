using System;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.AspNetWebForms.Core.Configuration
{
    public class ViewerConfig
    {
        public static ViewerConfig Instance = new ViewerConfig();

        internal string LicensePath = string.Empty;
        internal readonly HtmlViewOptions HtmlViewOptions = HtmlViewOptions.ForEmbeddedResources();
        internal readonly PngViewOptions PngViewOptions = new PngViewOptions();
        internal readonly JpgViewOptions JpgViewOptions = new JpgViewOptions();
        internal readonly PdfViewOptions PdfViewOptions = new PdfViewOptions();

        private ViewerConfig() { }

        public ViewerConfig SetLicensePath(string licensePath)
        {
            LicensePath = licensePath;
            return this;
        }

        public ViewerConfig ConfigureHtmlViewOptions(Action<HtmlViewOptions> setupOptions)
        {
            setupOptions?.Invoke(HtmlViewOptions);
            return this;
        }

        public ViewerConfig ConfigurePngViewOptions(Action<PngViewOptions> setupOptions)
        {
            setupOptions?.Invoke(PngViewOptions);
            return this;
        }
     
        public ViewerConfig ConfigureJpgViewOptions(Action<JpgViewOptions> setupOptions)
        {
            setupOptions?.Invoke(JpgViewOptions);
            return this;
        }

        public ViewerConfig ConfigurePdfViewOptions(Action<PdfViewOptions> setupOptions)
        {
            setupOptions?.Invoke(PdfViewOptions);
            return this;
        }
    }
}
