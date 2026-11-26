namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderImages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderImageToHtmlExternal
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("vector-image.svg"))
        {
            // Specify the HTML file name and location of external resources.
            // {0} is replaced with the resource name in the output file name.
            var viewOptions = HtmlViewOptions.ForExternalResources("render-image-to-html-external.html", "output/resource_{0}", "output/resource_{0}");
            viewer.View(viewOptions);
        }
    }
}
