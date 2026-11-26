namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives.OldArchiveRendering;

using System.IO;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class LegacyArchiveFoldersInfo
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("documents.zip"))
        {
            var viewInfoOptions = ViewInfoOptions.ForHtmlView();
            var viewInfo = viewer.GetViewInfo(viewInfoOptions) as ArchiveViewInfo;

            if (viewInfo != null)
            {
                Console.WriteLine($"File type: {viewInfo.FileType}");
                Console.WriteLine($"The number of pages: {viewInfo.Pages.Count}");
                Console.WriteLine("Folders: ");
                // Display the list of folders in the archive file.
                foreach (string folder in viewInfo.Folders)
                    Console.WriteLine($" - {folder}");
            }
        }
    }
}
