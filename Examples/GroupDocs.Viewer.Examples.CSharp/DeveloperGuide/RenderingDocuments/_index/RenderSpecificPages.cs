namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments._index;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderSpecificPages
{
    public static void Run()
    {
        // ...

        // Load the document
        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // {0} is replaced with the current page number in the file name.
            PngViewOptions viewOptions = new PngViewOptions("page_{0}.png");
            // Render pages 1 and 3 only.
            viewer.View(viewOptions, 1, 3);
        }
    }
}
