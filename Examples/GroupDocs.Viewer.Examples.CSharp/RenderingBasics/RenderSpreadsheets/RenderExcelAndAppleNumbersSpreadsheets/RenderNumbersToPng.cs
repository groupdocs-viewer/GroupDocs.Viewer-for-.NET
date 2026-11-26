namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.RenderExcelAndAppleNumbersSpreadsheets;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderNumbersToPng
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.numbers"))
        {
            // Convert the spreadsheet to PNG.
            // {0} is replaced with the current page number in the file names.
            var viewOptions = new PngViewOptions("output_{0}.png");
            // Set width and height.
            viewOptions.Width = 800;
            viewOptions.Height = 900;
            viewer.View(viewOptions);
        }
    }
}
