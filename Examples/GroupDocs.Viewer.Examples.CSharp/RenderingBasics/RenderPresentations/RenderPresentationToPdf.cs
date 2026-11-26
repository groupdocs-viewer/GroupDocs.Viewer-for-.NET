namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPresentations;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPresentationToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pptx"))
        {
            // Create a PDF file for the presentation.
            // Specify the PDF file name.
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
