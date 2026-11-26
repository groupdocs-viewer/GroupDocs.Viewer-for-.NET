namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderToPngImages
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create a PNG file.
            PngViewOptions viewOptions = new PngViewOptions();
            viewer.View(viewOptions);
        }
    }
}
