namespace GroupDocs.Viewer.Examples.CSharp.ProductOverview;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class QuickExampleProtectedPdf
{
    public static void Run()
    {
        // Open a password-protected DOCX, render to PDF with a watermark.
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.Password = "secret";

        using (Viewer viewer = new Viewer("./protected.docx", loadOptions))
        {
            PdfViewOptions options = new PdfViewOptions("./protected.pdf");
            options.Watermark = new Watermark("CONFIDENTIAL");
            viewer.View(options);
        }
    }
}
