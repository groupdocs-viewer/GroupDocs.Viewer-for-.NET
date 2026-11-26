namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWebDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderChmToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.chm"))
        {
            // Convert the CHM file to HTML.
            // {0} is replaced with the page numbers in the output file names.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("chm_result_{0}.html");
            // Enable the following option to display all CHM content on a single HTML page.
            // options.RenderToSinglePage = true;
            viewer.View(viewOptions);
        }
    }
}
