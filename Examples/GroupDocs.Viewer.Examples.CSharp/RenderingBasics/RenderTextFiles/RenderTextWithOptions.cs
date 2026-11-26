namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderTextFiles;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderTextWithOptions
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("terms_of_service.txt"))
        {
            // Convert the text file to HTML.
            // {0} is replaced with the current page number in the output file names.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("render-text-with-options_{0}.html");
            // Set the maximum number of rows per page.
            viewOptions.TextOptions.MaxRowsPerPage = 30;
            viewer.View(viewOptions);
        }
    }
}
