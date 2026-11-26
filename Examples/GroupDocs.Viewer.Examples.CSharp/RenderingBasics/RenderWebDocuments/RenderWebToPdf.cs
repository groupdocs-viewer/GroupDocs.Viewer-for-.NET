namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWebDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWebToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("groupdocs-documentation.mhtml"))
        {
            // Create a PDF file for the document.
            // Specify the PDF file name.
            var viewOptions = new PdfViewOptions("render-web-to-pdf.pdf");
            viewer.View(viewOptions);
        }
    }
}
