namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingDocumentsFromDifferentSources.LoadDocumentFromLocalDisk;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadDocumentFromLocalDisk
{
    public static void Run()
    {
        // ...

        // Specify a path to a file.
        string filePath = "sample.docx";

        // Render the file.
        using (Viewer viewer = new Viewer(filePath))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }
    }
}
