namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderTextFiles;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderTextToJpg
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("terms_of_service.txt"))
        {
            // Convert the text file to JPEG.
            // {0} is replaced with the current page number in the output image names.
            var viewOptions = new JpgViewOptions("output_{0}.jpg");
            // Set width and height.
            viewOptions.Width = 800;
            viewOptions.Height = 1000;
            viewer.View(viewOptions);
        }
    }
}
