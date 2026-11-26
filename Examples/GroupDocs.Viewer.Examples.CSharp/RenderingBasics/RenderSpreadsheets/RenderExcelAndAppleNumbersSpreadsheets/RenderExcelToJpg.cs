namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.RenderExcelAndAppleNumbersSpreadsheets;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderExcelToJpg
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("invoice.xlsx"))
        {
            // Convert the spreadsheet to JPEG.
            // {0} is replaced with the current page number in the file names.
            var viewOptions = new JpgViewOptions("output_{0}.jpg");
            // Set width and height.
            viewOptions.Width = 800;
            viewOptions.Height = 900;
            viewer.View(viewOptions);
        }
    }
}
