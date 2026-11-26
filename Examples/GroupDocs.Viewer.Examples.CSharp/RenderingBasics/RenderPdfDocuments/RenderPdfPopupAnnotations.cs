namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPdfPopupAnnotations
{
    public static void Run()
    {
        // ...

        // Preparing output options
        PngViewOptions pngOpt = new PngViewOptions("render-pdf-popup-annotations_{0}.png");
        JpgViewOptions jpegOpt = new JpgViewOptions();
        HtmlViewOptions htmlEmbeddedOpt = HtmlViewOptions.ForEmbeddedResources("render-pdf-popup-annotations_{0}.html");

        // Enabling "RenderNotes" for all options
        pngOpt.RenderNotes = jpegOpt.RenderNotes = htmlEmbeddedOpt.RenderNotes = true;

        // Loading sample PDF file
        using (Viewer viewer = new Viewer("sample.pdf"))
        {
            // Rendering to output formats
            viewer.View(pngOpt);
            viewer.View(jpegOpt);
            viewer.View(htmlEmbeddedOpt);
        }
    }
}
