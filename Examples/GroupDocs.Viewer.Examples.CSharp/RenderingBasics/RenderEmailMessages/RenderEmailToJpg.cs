namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEmailMessages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderEmailToJpg
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.eml"))
        {
            // Create a JPG image.
            var viewOptions = new JpgViewOptions("output_{0}.jpg");
            // Set width and height.
            viewOptions.Width = 800;
            viewOptions.Height = 1000;
            viewer.View(viewOptions);
        }
    }
}
