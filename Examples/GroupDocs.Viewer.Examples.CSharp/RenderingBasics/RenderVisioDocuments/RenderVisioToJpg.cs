namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderVisioDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderVisioToJpg
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.vsdx"))
        {
            // Create a JPEG image for each drawing page.
            // {0} is replaced with the current page number in the image name.
            var viewOptions = new JpgViewOptions("output_{0}.jpg");
            // Set width and height.
            viewOptions.Width = 950;
            viewOptions.Height = 800;
            viewer.View(viewOptions);
        }
    }
}
