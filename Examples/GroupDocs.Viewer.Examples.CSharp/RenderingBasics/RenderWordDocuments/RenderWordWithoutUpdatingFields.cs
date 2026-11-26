namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordWithoutUpdatingFields
{
    public static void Run()
    {
        // ...

        HtmlViewOptions htmlViewOptions = HtmlViewOptions.ForEmbeddedResources("render-word-without-updating-fields_{0}.html");
        htmlViewOptions.WordProcessingOptions.UpdateFields = false;

        PdfViewOptions pdfViewOptions = new PdfViewOptions("render-word-without-updating-fields.pdf");
        pdfViewOptions.WordProcessingOptions.UpdateFields = false;

        using (var viewer = new Viewer("handbook.docx"))
        {    
            viewer.View(htmlViewOptions);
        	viewer.View(pdfViewOptions);
        }
    }
}
