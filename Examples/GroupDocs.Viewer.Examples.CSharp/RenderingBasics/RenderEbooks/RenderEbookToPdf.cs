namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEbooks;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderEbookToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.epub"))
        {
            // Create a PDF file for the document.
            // Specify the PDF file name.
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
