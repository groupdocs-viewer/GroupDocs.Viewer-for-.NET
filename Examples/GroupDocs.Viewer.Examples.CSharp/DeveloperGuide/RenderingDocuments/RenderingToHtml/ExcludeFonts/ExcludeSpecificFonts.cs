namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.ExcludeFonts;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class ExcludeSpecificFonts
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.pptx"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources();    
            viewOptions.FontsToExclude.Add("Times New Roman");// Exclude the Times New Roman font.
            viewOptions.FontsToExclude.Add("Arial");// Exclude the Arial font.
            viewer.View(viewOptions);
        }
    }
}
