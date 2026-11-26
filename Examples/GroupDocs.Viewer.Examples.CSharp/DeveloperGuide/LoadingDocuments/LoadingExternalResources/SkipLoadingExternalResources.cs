namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingExternalResources;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SkipLoadingExternalResources
{
    public static void Run()
    {
        // ...

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.SkipExternalResources = true; // Skip loading of external resources

        using (Viewer viewer = new Viewer("business-flyer.docx", loadOptions))
        {
            HtmlViewOptions viewOptions = 
                HtmlViewOptions.ForEmbeddedResources();

            viewer.View(viewOptions);
        }
    }
}
