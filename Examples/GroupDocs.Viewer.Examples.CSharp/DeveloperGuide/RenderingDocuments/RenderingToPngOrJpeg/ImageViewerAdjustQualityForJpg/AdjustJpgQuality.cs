namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg.ImageViewerAdjustQualityForJpg;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class AdjustJpgQuality
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create a JPG file.
            JpgViewOptions viewOptions = new JpgViewOptions();

            // Specify the JPG image quality.
            viewOptions.Quality = 50;    
            viewer.View(viewOptions);
        }
    }
}
