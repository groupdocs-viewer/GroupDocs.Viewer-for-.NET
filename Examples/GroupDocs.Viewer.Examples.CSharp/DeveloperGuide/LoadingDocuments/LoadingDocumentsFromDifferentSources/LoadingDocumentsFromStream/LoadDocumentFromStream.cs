namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingDocumentsFromDifferentSources.LoadingDocumentsFromStream;

using System.IO;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadDocumentFromStream
{
    public static void Run()
    {
        // ...

        Stream stream = File.OpenRead("sample.docx");

        // Render a document from the stream.
        using (Viewer viewer = new Viewer(stream))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }
    }
}
