namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderXmlDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetXmlViewInfo
{
    public static void Run()
    {
        ViewInfoOptions viewInfoOptionsHtmlSingle = ViewInfoOptions.ForHtmlView(true);
        ViewInfoOptions viewInfoOptionsPdf = ViewInfoOptions.ForPdfView();
        ViewInfoOptions viewInfoOptionsPng = ViewInfoOptions.ForPngView();

        string inputXmlDocument = "sample.xml";
        using (Viewer viewer = new Viewer(inputXmlDocument))
        {
            ViewInfo resultHtmlSingle = viewer.GetViewInfo(viewInfoOptionsHtmlSingle);
            ViewInfo resultPdf = viewer.GetViewInfo(viewInfoOptionsPdf);
            ViewInfo resultPng = viewer.GetViewInfo(viewInfoOptionsPng);

            Console.WriteLine("HTML (single page): " + resultHtmlSingle.Pages.Count + " page(s)");
            Console.WriteLine("PDF: " + resultPdf.Pages.Count + " page(s)");
            Console.WriteLine("PNG: " + resultPng.Pages.Count + " page(s)");
        }
    }
}
