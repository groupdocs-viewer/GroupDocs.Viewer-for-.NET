namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderOutlookDataFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderOutlookWithMaxItems
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pst"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("render-outlook-with-max-items_{0}.html");
            // Specify the maximum number of folder items.
            viewOptions.OutlookOptions.MaxItemsInFolder = 30;
            viewer.View(viewOptions);
        }
    }
}
