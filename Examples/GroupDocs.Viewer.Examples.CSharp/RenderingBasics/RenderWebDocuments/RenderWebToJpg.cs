namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWebDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWebToJpg
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("groupdocs-documentation.mhtml"))
        {
            // Convert the web file to JPEG.
            // {0} is replaced with the page numbers in the output image names.
            var viewOptions = new JpgViewOptions("output_{0}.jpg");
            viewer.View(viewOptions);
        }
    }
}
