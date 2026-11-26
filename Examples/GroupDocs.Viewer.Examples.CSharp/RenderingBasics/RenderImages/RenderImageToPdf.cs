namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderImages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderImageToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("vector-image.svg"))
        {
            // Create a PDF file.
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
