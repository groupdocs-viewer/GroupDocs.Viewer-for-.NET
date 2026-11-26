namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderToJpegImages
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create a JPG file.
            JpgViewOptions viewOptions= new JpgViewOptions();                  
            viewer.View(viewOptions);
        }
    }
}
