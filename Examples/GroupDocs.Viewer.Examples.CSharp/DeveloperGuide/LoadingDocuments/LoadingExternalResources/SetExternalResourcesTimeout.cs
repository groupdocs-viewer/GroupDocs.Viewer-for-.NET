namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingExternalResources;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SetExternalResourcesTimeout
{
    public static void Run()
    {
        // ...

        // Specify a timeout.
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.ResourceLoadingTimeout = TimeSpan.FromSeconds(5);
        // Render a file.
        using (Viewer viewer = new Viewer("business-flyer.docx", loadOptions))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources("set-external-resources-timeout_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
