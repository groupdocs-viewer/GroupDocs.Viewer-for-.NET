namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives.OldArchiveRendering;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LegacyArchiveToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("documents.zip"))
        {
            // Create a PDF file.
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
