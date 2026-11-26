namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.RenderWithResponsiveLayout;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderResponsiveHtml
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create view options.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources();

            // Render the file with responsive layout.
            viewOptions.RenderResponsive = true;
            viewer.View(viewOptions);
        }
    }
}
