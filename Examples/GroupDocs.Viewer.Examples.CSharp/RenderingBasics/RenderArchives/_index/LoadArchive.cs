namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives._index;

using System.IO;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadArchive
{
    public static void Run()
    {
        // ...

        string inputArchivePath = "documents.zip";
        using (Viewer viewer1 = new Viewer(inputArchivePath))
        {
            // view it
        }

        FileStream inputArchiveStream = File.OpenRead(inputArchivePath);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.Password = "password";

        using (Viewer viewer2 = new Viewer(inputArchiveStream, loadOptions))
        {
            // view it
        }
    }
}
