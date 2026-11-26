namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class ExtractPdfText
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pdf"))
        {
            var viewInfoOptions = ViewInfoOptions.ForHtmlView();
            viewInfoOptions.ExtractText = true;
            var viewInfo = viewer.GetViewInfo(viewInfoOptions) as PdfViewInfo;

            // Retrieve text from the PDF file.
            Console.WriteLine("Extracted document text:");
            foreach (Page page in viewInfo.Pages)
                foreach (Line line in page.Lines)
                {
                    Console.WriteLine(line.Value);
                }
        }
    }
}
