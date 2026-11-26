namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.ReorderPages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class ReorderPages
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))            
        {     
            // Create view options.
            PdfViewOptions viewOptions = new PdfViewOptions();

            // Pass page numbers in the order you want to render them.                
            viewer.View(viewOptions, 2, 1);
        }
    }
}
