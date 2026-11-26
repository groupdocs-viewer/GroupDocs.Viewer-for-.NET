namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.OptimizeHtmlForPrinting;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class OptimizeHtmlForPrinting
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create view options.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources();

            // Render a file optimized for printing.
            viewOptions.ForPrinting = true;
            viewer.View(viewOptions);
        }
    }
}
