namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg.SetImageSizeLimitsWhenRenderingToPngJpg;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LimitImageSizeInPngAndJpg
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.jpg"))
        {
            // Create a JPG or PNG file.
            JpgViewOptions viewOptions = new JpgViewOptions("result_{0}.jpg");
            // or PngViewOptions viewOptions = new PngViewOptions("result_{0}.png");

            // Specify the maximum width and height.
            viewOptions.MaxWidth = 800;
            viewOptions.MaxHeight = 600;

            viewer.View(viewOptions);
        }
    }
}
