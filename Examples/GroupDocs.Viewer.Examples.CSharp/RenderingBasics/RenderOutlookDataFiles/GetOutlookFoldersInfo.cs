namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderOutlookDataFiles;

using System.IO;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetOutlookFoldersInfo
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pst"))
        {
            // Create an HTML file.
            var viewInfoOptions = ViewInfoOptions.ForHtmlView();
            var viewInfo = viewer.GetViewInfo(viewInfoOptions) as OutlookViewInfo;

            if (viewInfo != null)
            {
                // Display information about the PST file.
                Console.WriteLine($"File type: {viewInfo.FileType}");
                Console.WriteLine($"The number of pages: {viewInfo.Pages.Count}");

                // Display the list of folders that the PST file contains.
                Console.WriteLine("The file contains the following folders:");
                foreach (string folder in viewInfo.Folders)
                    Console.WriteLine(folder);
            }
        }
    }
}
