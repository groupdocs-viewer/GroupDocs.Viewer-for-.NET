namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPresentations;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPresentationToPng
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pptx"))
        {
            // Create a PNG image for each slide.
            // {0} is replaced with the current page number in the image name.
            var viewOptions = new PngViewOptions("output_{0}.png");
            // Set width and height.
            viewOptions.Width = 950;
            viewOptions.Height = 550;
            viewer.View(viewOptions);
        }
    }
}
