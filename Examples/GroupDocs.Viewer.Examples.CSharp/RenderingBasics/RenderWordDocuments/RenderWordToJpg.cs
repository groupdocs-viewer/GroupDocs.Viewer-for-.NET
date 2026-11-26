namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordToJpg
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.docx"))
        {
            // Create a JPEG image for each document page.
            // {0} is replaced with the current page number in the image name.
            var viewOptions = new JpgViewOptions("output_{0}.jpg");
            // Set width and height.
            viewOptions.Width = 800;
            viewOptions.Height = 900;
            viewer.View(viewOptions);
        }
    }
}
