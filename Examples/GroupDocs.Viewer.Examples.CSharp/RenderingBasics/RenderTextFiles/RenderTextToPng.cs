namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderTextFiles;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderTextToPng
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("terms_of_service.txt"))
        {
            // Convert the text file to PNG.
            // {0} is replaced with the current page number in the output image names.
            var viewOptions = new PngViewOptions("output_{0}.png");
            // Set width and height.
            viewOptions.Width = 800;
            viewOptions.Height = 900;
            viewer.View(viewOptions);
        }
    }
}
