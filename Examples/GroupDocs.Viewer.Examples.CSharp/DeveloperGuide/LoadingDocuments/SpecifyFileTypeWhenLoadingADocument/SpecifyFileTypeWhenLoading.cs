namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.SpecifyFileTypeWhenLoadingADocument;

using System.IO;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SpecifyFileTypeWhenLoading
{
    public static void Run()
    {
        // ...

        Stream stream = File.OpenRead("sample.docx");

        // Specify the file type.
        LoadOptions loadOptions = new LoadOptions(FileType.DOCX);

        //Render a file.
        using (Viewer viewer = new Viewer(stream, loadOptions))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }
    }
}
