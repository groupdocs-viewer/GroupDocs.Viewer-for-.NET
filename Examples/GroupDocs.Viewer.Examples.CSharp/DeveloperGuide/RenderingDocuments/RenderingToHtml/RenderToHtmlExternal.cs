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
            var viewOptions = HtmlViewOptions.ForExternalResources();
            viewer.View(viewOptions);
        }
    }
}
