namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.ViewSpecificPages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class ViewSpecificPages
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create view options.
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources("view-specific-pages_{0}.html");

            // Specify the page numbers.
            viewer.View(viewOptions, 1, 3);
        }
    }
}
