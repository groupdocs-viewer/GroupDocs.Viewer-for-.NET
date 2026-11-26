namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPresentations;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPresentationToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pptx"))
        {
            // Create an HTML file for each slide.
            // {0} is replaced with the current page number in the file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("page_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
