namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.RenderExcelAndAppleNumbersSpreadsheets;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderNumbersToHtmlExternal
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.numbers"))
        {
            // Convert the spreadsheet to HTML.
            // Specify the HTML file names and location of external resources.
            // {0} and {1} are replaced with the current page number and resource name, respectively.
            var viewOptions = HtmlViewOptions.ForExternalResources("render-numbers-to-html-external_{0}.html", "render-numbers-to-html-external_{0}/resource_{0}_{1}", "render-numbers-to-html-external_{0}/resource_{0}_{1}");
            viewer.View(viewOptions);
        }
    }
}
