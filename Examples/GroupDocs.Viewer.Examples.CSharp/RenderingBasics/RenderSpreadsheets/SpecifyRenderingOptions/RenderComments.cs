namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SpecifyRenderingOptions;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderComments
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("with_comments.xlsx"))
        {
            // Convert the spreadsheet to PNG.
            // {0} is replaced with the current page number in the file names.
            var viewOptions = new PngViewOptions("output_{0}.png");
            // Enable rendering comments.
            viewOptions.RenderComments = true;
            viewer.View(viewOptions);
        }
    }
}
