namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToGetFileTypeAndPagesCount;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetFileTypeAndPagesCount
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.pdf"))
        {
            // Get file information.
            ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForHtmlView();
            ViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions);

            // Display file type and pages count.
            Console.WriteLine("Document type is: " + viewInfo.FileType);
            Console.WriteLine("Pages count: " + viewInfo.Pages.Count);
        }
    }
}
