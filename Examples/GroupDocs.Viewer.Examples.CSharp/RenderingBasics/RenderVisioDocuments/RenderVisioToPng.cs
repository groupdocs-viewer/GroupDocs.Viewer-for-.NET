namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderVisioDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderVisioToPng
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.vsdx"))
        {
            // Create a PNG image for each drawing page.
            // {0} is replaced with the current page number in the image name.
            var viewOptions = new PngViewOptions("output_{0}.png");
            // Set width and height.
            viewOptions.Width = 950;
            viewOptions.Height = 800;
            viewer.View(viewOptions);
        }
    }
}
