namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWebDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderChmToHtmlExternal
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.chm"))
        {
            // Convert the CHM file to HTML.
            // Specify the output file names and location of external resources.
            // {0} and {1} are replaced with the current page number and resource name, respectively.
            var viewOptions = HtmlViewOptions.ForExternalResources("page_{0}.html", "page_{0}/resource_{0}_{1}", "page_{0}/resource_{0}_{1}");
            viewer.View(viewOptions);
        }
    }
}
