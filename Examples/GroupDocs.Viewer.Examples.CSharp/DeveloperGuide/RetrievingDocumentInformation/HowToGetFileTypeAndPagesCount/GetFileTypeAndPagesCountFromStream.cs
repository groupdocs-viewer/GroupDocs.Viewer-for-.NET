namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToGetFileTypeAndPagesCount;

using System.IO;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetFileTypeAndPagesCountFromStream
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer(File.OpenRead("sample.pdf")))
        {
            ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForHtmlView();
            ViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions);

            Console.WriteLine("Document type is: " + viewInfo.FileType);
            Console.WriteLine("Pages count: " + viewInfo.Pages.Count);
        }
    }
}
