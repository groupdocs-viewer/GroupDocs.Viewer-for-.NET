namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEbooks;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderEbookToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.epub"))
        {
            // Create an HTML file for each document page.
            // {0} is replaced with the current page number in the file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("render-ebook-to-html_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
