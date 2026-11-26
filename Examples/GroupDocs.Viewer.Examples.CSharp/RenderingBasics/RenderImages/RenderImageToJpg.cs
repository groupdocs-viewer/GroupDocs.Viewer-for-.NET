namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderImages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderImageToJpg
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("vector-image.svg"))
        {
            // Create a JPEG image.
            var viewOptions = new JpgViewOptions("output.jpg");
            // Set width and height.
            viewOptions.Width = 1600;
            viewOptions.Height = 900;
            viewer.View(viewOptions);
        }
    }
}
