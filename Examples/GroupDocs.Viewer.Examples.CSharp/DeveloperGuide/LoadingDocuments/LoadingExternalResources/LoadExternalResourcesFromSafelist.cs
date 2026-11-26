namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingExternalResources;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadExternalResourcesFromSafelist
{
    public static void Run()
    {
        // ...

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.SkipExternalResources = true; // Skip loading of all external resources
        loadOptions.WhitelistedResources.Add("blog.groupdocs.com"); // Load the resources whose URL contains "blog.groupdocs.com"

        using (Viewer viewer = new Viewer("business-flyer.docx", loadOptions))
        {
            HtmlViewOptions viewOptions = 
                HtmlViewOptions.ForEmbeddedResources();

            viewer.View(viewOptions);
        }
    }
}
