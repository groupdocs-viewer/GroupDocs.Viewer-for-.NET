namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderVisioDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderVisioToHtmlExternal
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.vsdx"))
        {
            // Create an HTML file for each drawing page.
            // Specify the HTML file names and location of external resources.
            // {0} and {1} are replaced with the current page number and resource name, respectively.
            var viewOptions = HtmlViewOptions.ForExternalResources(
                "page_{0}.html", "page_{0}/resource_{0}_{1}", "page_{0}/resource_{0}_{1}");
            viewer.View(viewOptions);
        }
    }
}
