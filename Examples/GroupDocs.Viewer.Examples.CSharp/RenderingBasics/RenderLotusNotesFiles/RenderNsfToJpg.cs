namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderLotusNotesFiles;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderNsfToJpg
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.nsf"))
        {
            // Convert the NSF file to JPEG.
            // {0} is replaced with the page numbers in the output image names.
            var viewOptions = new JpgViewOptions("output_{0}.jpg");
            //  Set width and height.
            viewOptions.Width = 800;
            viewOptions.Height = 1000;
            viewer.View(viewOptions);
        }
    }
}
