namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderOutlookDataFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderOutlookSpecificFolder
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pst"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("render-outlook-specific-folder_{0}.html");
            // Render messages from the "Inbox" folder and its subfolders.
            viewOptions.OutlookOptions.Folder = "Inbox";
            // Render messages from a specific subfolder in the "Inbox" folder.
            // viewOptions.OutlookOptions.Folder = "Inbox\\Work\\Urgent";
            viewer.View(viewOptions);
        }
    }
}
