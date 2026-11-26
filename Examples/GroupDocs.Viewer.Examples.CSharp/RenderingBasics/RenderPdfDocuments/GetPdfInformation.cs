namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using System.IO;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetPdfInformation
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pdf"))
        {
            var viewInfoOptions = ViewInfoOptions.ForHtmlView();
            var viewInfo = viewer.GetViewInfo(viewInfoOptions) as PdfViewInfo;

            // Display information about the PDF document.
            Console.WriteLine($"File type: {viewInfo.FileType}");
            Console.WriteLine($"The number of pages: {viewInfo.Pages.Count}");
            Console.WriteLine($"Is printing allowed: {viewInfo.PrintingAllowed}");

            // Display information about all document pages.
            Console.WriteLine("Page information:");
            foreach (Page page in viewInfo.Pages)
            {
                // The Page.ToString method is overriden to display the following page information: 
                // "Page {Number} ({visibility}) {Width}x{Height}px with {Lines.Count} line(s)."
                Console.WriteLine(page);
            }
        }
    }
}
