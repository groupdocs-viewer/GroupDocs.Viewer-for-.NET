namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderImages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderImageToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("vector-image.svg"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("output.html");
            viewer.View(viewOptions);
        }
    }
}
