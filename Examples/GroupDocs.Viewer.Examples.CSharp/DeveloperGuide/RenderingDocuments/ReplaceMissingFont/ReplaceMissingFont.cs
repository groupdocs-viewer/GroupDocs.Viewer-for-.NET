namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.ReplaceMissingFont;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class ReplaceMissingFont
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("missing_font.pptx"))
        {
            // Create options for rendering HTML document with embedded resources
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();

            // Specify a default font name is the options
            viewOptions.DefaultFontName = "Courier New";

            // Render input PPTX to output HTML
            viewer.View(viewOptions);
        }
    }
}
