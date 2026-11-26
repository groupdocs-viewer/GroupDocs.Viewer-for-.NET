namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderImages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderImageToPng
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("vector-image.svg"))
        {
            // Create a PNG image.
            var viewOptions = new PngViewOptions("output.png");
            // Set width and height.
            viewOptions.Width = 1600;
            viewOptions.Height = 900;
            viewer.View(viewOptions);
        }
    }
}
