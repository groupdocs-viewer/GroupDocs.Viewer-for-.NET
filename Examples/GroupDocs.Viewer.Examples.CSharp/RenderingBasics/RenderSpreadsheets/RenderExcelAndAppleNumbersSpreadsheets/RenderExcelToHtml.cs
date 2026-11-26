namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.RenderExcelAndAppleNumbersSpreadsheets;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderExcelToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("invoice.xlsx"))
        {
            // Convert the spreadsheet to HTML.
            // {0} is replaced with the current page number in the file names.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("page_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
