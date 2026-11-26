namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderToHtmlEmbedded
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create view options.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("render-to-html-embedded_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
