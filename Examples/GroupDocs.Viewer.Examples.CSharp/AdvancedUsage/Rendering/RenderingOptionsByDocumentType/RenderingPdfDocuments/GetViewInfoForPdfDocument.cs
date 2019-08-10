using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingPdfDocuments
{
    /// <summary>
    /// This example demonstrates how to get view info for PDF document.
    /// </summary>
    class GetViewInfoForPdfDocument
    {
        public static void Run()
        {            
            using (Viewer viewer = new Viewer(Constants.SAMPLE_PDF))
            {
                ViewInfoOptions options = ViewInfoOptions.ForHtmlView();
                PdfViewInfo info = viewer.GetViewInfo(options) as PdfViewInfo;

                Console.WriteLine("Document type is: " + info.FileType);
                Console.WriteLine("Pages count: " + info.Pages.Count);
                Console.WriteLine("Printing allowed: " + info.PrintingAllowed);
            }

            Console.WriteLine("\nView info retrieved successfully.");
        }
    }
}
