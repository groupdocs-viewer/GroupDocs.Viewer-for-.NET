namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderOutlookDataFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderOutlookWithFilters
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pst"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources();
            // Set filters.
            viewOptions.OutlookOptions.TextFilter = "invoice";
            viewOptions.OutlookOptions.AddressFilter = "northwindroasters.example";
            viewer.View(viewOptions);
        }
    }
}
