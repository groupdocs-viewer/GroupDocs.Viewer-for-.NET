using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingArchiveFiles
{
    /// <summary>
    /// This example demonstrates how to get view info for Archive files.
    /// </summary>
    class GetViewInfoForArchiveFile
    {
        public static void Run()
        {
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_ZIP_WITH_FOLDERS))
            {
                ViewInfo info = viewer.GetViewInfo(ViewInfoOptions.ForHtmlView());

                Console.WriteLine("File type: " + info.FileType);
                Console.WriteLine("Pages count: " + info.Pages.Count);

                Console.WriteLine("Folders: ");
                Console.WriteLine(" - /");

                string rootFolder = string.Empty;
                ReadFolders(viewer, rootFolder);
            }

            Console.WriteLine("\nView info retrieved successfully.");
        }

        private static void ReadFolders(Viewer viewer, string folder)
        {
            ViewInfoOptions options = ViewInfoOptions.ForHtmlView();
            options.ArchiveOptions.Folder = folder;

            ArchiveViewInfo viewInfo = viewer.GetViewInfo(options) as ArchiveViewInfo;

            foreach (string subFolder in viewInfo.Folders)
            {
                Console.WriteLine($" - {subFolder}");

                ReadFolders(viewer, subFolder);
            }
        }
    }
}
