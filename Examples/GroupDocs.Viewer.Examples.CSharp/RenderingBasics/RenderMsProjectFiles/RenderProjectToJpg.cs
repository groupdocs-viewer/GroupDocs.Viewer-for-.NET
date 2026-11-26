namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderMsProjectFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderProjectToJpg
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.mpp"))
        {
            // Render the project's active view as JPEG.
            // {0} is replaced with the current page number in the output file names.
            var viewOptions = new JpgViewOptions("output_{0}.jpg");
            // Set width and height.
            viewOptions.Width = 1600;
            viewOptions.Height = 650;
            viewer.View(viewOptions);
        }
    }
}
