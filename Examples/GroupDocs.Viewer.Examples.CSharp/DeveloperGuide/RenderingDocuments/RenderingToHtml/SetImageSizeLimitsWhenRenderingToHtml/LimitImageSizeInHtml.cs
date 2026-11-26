namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.SetImageSizeLimitsWhenRenderingToHtml;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LimitImageSizeInHtml
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.jpeg"))
        {
            // Create view options.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources();
            // Specify the maximum width and height.
            viewOptions.ImageMaxWidth = 800;
            viewOptions.ImageMaxHeight = 600;
            viewer.View(viewOptions);
        }
    }
}
