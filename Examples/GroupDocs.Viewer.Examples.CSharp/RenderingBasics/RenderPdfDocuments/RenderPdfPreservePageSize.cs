namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPdfPreservePageSize
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pdf"))
        {
            // Create a PNG image for each PDF page.
            // {0} is replaced with the current page number in the image name.
            var viewOptions = new PngViewOptions("render-pdf-preserve-page-size_{0}.png");
            // Preserve the size of document pages.
            viewOptions.PdfOptions.RenderOriginalPageSize = true;
            viewer.View(viewOptions);
        }
    }
}
