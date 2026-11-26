namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.FlipOrRotatePages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class FlipOrRotatePages
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create a PDF file.
            PdfViewOptions viewOptions = new PdfViewOptions();
            // Rotate the first page.
            viewOptions.RotatePage(1, Rotation.On90Degree);
            viewer.View(viewOptions);
        }
    }
}
