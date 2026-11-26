namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.ExcludeFonts;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class ExcludeAllFonts
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("exclude-all-fonts_{0}.html");    
            viewOptions.ExcludeFonts = true;
            viewer.View(viewOptions);
        }
    }
}
