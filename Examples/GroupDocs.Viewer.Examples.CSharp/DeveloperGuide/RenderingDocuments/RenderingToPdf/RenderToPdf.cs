namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderToPdf
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
        	// Create a PDF file.
        	PdfViewOptions viewOptions = new PdfViewOptions();
        	viewer.View(viewOptions);
        }
    }
}
