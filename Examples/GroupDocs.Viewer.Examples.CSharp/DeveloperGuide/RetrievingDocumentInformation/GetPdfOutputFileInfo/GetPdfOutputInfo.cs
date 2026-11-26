namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.GetPdfOutputFileInfo;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetPdfOutputInfo
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.pdf"))
        {
            // Get file information.
            ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForPdfView();
            ViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions);

            // Display page count.
            Console.WriteLine("Pages count: " + viewInfo.Pages.Count);

            // Display width and height of each page.
            foreach (Page page in viewInfo.Pages)
            {
                Console.WriteLine($"Page: {page.Number}; Width: {page.Width}, pixels");
                Console.WriteLine($"Page: {page.Number}; Height: {page.Height}, pixels");
            }
        }
    }
}
