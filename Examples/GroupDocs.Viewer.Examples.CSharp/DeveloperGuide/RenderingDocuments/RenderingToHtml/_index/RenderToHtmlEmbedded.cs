namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml._index;

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
            var viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }
    }
}
