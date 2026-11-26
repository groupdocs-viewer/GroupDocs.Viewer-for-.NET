namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.RenderCadDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderCadToPdf
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.dwg"))
        {
            // Create a PDF file for the drawing.
            // Specify the PDF file name.
            PdfViewOptions viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
