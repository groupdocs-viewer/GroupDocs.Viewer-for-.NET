namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderXmlDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderXmlToPdf
{
    public static void Run()
    {
        PdfViewOptions pdfOptions = new PdfViewOptions("output.pdf");
        string inputXmlDocument = "sample.xml";
        using (Viewer viewer = new Viewer(inputXmlDocument))
        {
            viewer.View(pdfOptions);
        }
    }
}
