namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWebDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWebToPng
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("groupdocs-documentation.mhtml"))
        {
            // Convert the web file to PNG.
            // {0} is replaced with the page numbers in the output image names.
            var viewOptions = new PngViewOptions("output_{0}.png");
            viewer.View(viewOptions);
        }
    }
}
