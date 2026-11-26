namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderToHtmlExternal
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create view options.
            var viewOptions = HtmlViewOptions.ForExternalResources("render-to-html-external_{0}.html", "render-to-html-external_{0}_{1}", "render-to-html-external_{0}_{1}");
            viewer.View(viewOptions);
        }
    }
}
