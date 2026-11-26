namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg.ImageViewerAdjustImageSize;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class AdjustImageSize
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create a JPG file.
            JpgViewOptions viewOptions = new JpgViewOptions();

            // Specify the width and height.
            viewOptions.Width = 600;
            viewOptions.Height = 800;

            viewer.View(viewOptions);
        }
    }
}
