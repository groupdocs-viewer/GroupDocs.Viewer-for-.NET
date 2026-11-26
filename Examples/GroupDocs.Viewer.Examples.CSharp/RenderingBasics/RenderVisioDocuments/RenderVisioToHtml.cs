namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderVisioDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderVisioToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.vsdx"))
        {
            // Create an HTML file for each drawing page.
            // {0} is replaced with the current page number in the file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("render-visio-to-html_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
