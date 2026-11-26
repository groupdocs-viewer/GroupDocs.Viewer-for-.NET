namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives.OldArchiveRendering;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LegacyArchiveToJpeg
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("documents.zip"))
        {
            // Create a JPEG image for the top folder and each subfolder in the archive.
            // {0} is replaced with the current page number in the image name.
            var viewOptions = new JpgViewOptions("output_{0}.jpg");
            // Set width and height.
            viewOptions.Width = 800;
            viewOptions.Height = 1000;
            viewer.View(viewOptions);
        }
    }
}
