namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderLotusNotesFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderNsfToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.nsf"))
        {
            // Create a PDF file.
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
