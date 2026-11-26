namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives._index;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderArchiveToPdf
{
    public static void Run()
    {
        // ...

        PdfViewOptions pdfOptions = new PdfViewOptions("Output.pdf");

        using (Viewer viewer = new Viewer("documents.zip"))
        {
            viewer.View(pdfOptions);
        }
    }
}
