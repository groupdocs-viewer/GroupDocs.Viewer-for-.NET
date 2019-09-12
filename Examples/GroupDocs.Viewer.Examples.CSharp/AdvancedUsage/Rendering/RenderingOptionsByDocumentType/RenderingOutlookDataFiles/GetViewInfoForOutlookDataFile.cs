using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingOutlookDataFiles
{
    /// <summary>
    /// This example demonstrates how to get view info for Outlook data file.
    /// </summary>
    class GetViewInfoForOutlookDataFile
    {
        public static void Run()
        {
            using (Viewer viewer = new Viewer(Utils.SAMPLE_OST_SUBFOLDERS))
            {
                ViewInfoOptions options = ViewInfoOptions.ForHtmlView();
                OutlookViewInfo rootFolderInfo = viewer.GetViewInfo(options)
                    as OutlookViewInfo;

                Console.WriteLine("File type is: " + rootFolderInfo.FileType);
                Console.WriteLine("Pages count: " + rootFolderInfo.Pages.Count);

                foreach (string folder in rootFolderInfo.Folders)
                    Console.WriteLine(folder);
            }

            Console.WriteLine("\nView info retrieved successfully.");
        }
    }
}

