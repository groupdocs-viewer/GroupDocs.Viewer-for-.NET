namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.docx"))
        {
            // Create a PDF file for the document.
            // Specify the PDF file name.
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
