namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderTextFiles;

using System.IO;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderTextWithLoadOptions
{
    public static void Run()
    {
        // ...

        Stream stream = File.OpenRead("terms_of_service.md");

        // Specify the file encoding. 
        LoadOptions loadOptions = new LoadOptions(FileType.MD);

        // Convert the document to PDF.
        using (var viewer = new Viewer(stream, loadOptions))
        {
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
