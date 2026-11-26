namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives;

using System.IO;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetArchiveInfo
{
    public static void Run()
    {
        // ...

        ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForPdfView();

        using (Viewer viewer = new Viewer("documents.zip"))
        {
            GroupDocs.Viewer.Results.FileInfo fileInfo = viewer.GetFileInfo();
            Console.WriteLine("Encrypted: {0}", fileInfo.Encrypted ? "yes" : "no");

            ArchiveViewInfo viewInfo = (ArchiveViewInfo)viewer.GetViewInfo(viewInfoOptions);

            Console.WriteLine("Archive format: {0}", viewInfo.FileType);
            Console.WriteLine("Number of pages when saving to PDF: {0}", viewInfo.Pages.Count);

            Console.WriteLine("List of all pages with their metadata, when rendering to PDF:");
            foreach (Page page in viewInfo.Pages)
            {
                Console.WriteLine(" - Page #{0} - {1}x{2}px", page.Number, page.Width, page.Height);
            }

            Console.WriteLine("List of folders in the archive document:");
            foreach (string folder in viewInfo.Folders)
            {
                Console.WriteLine(" - {0}", folder);
            }
        }
    }
}
