namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments._index;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderDocumentToPng
{
    public static void Run()
    {
        // ...

        // Load the document
        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create a PNG image for each page.
            // {0} is replaced with the current page number in the file name.
            PngViewOptions viewOptions = new PngViewOptions("page_{0}.png");
            viewer.View(viewOptions);
        }
    }
}
