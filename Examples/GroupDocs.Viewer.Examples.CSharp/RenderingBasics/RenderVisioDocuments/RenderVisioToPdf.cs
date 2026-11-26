namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderVisioDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderVisioToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.vsdx"))
        {
            // Create a PDF file for the document.
            // Specify the PDF file name.
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
