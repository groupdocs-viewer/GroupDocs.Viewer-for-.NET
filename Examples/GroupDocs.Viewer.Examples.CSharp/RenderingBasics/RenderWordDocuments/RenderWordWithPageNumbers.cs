namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordWithPageNumbers
{
    public static void Run()
    {
        // ...

        PdfViewOptions pdfOpt = new PdfViewOptions();
        pdfOpt.WordProcessingOptions.PageNumberLocation = WordsPageNumberLocation.TopLeft;

        HtmlViewOptions htmlEmbeddedOpt = HtmlViewOptions.ForEmbeddedResources();
        htmlEmbeddedOpt.WordProcessingOptions.PageNumberLocation = WordsPageNumberLocation.BottomCenter;

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            viewer.View(pdfOpt);
            viewer.View(htmlEmbeddedOpt);
        }
    }
}
