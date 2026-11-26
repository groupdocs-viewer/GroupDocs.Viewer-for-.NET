namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.ShowHiddenPages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class ShowHiddenPages
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.pptx"))
        {
            // Create view options.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources();

            // Enable rendering of hidden items.
            viewOptions.RenderHiddenPages = true;
            viewer.View(viewOptions);
        }
    }
}
