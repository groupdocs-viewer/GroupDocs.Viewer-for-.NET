namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPdfToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pdf"))
        {
            // Create an HTML file for each PDF page.
            // {0} is replaced with the current page number in the file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("page_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
