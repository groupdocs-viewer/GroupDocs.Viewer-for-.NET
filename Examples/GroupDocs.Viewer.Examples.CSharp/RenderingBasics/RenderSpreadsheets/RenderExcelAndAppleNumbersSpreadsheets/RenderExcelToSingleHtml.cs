namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.RenderExcelAndAppleNumbersSpreadsheets;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderExcelToSingleHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("invoice.xlsx"))
        {
            // Convert all Excel worksheets to one HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("page.html");
            // Enable converting all worksheets to one file.
            viewOptions.RenderToSinglePage = true;
            viewer.View(viewOptions);
        }
    }
}
