using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingArchiveFiles
{
    /// <summary>
    /// This example demonstrates how to render RAR document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingRar
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "RAR_result_{0}.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_RAR_WITH_FOLDERS))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "RAR_result_{0}.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_RAR_WITH_FOLDERS))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "RAR_result_{0}.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_RAR_WITH_FOLDERS))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "RAR_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_RAR_WITH_FOLDERS))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            GetViewInfoForRar();
            RenderSpecificArchiveFolder();

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");

        }

        /// <summary>
        /// This example demonstrates how to get view info for Archive files.
        /// </summary>
        private static void GetViewInfoForRar()
        {
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_RAR_WITH_FOLDERS))
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

        /// <summary>
        /// This example demonstrates how to render folder of archive file.
        /// </summary>
        private static void RenderSpecificArchiveFolder()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "archive_folder_page_{0}.html");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_RAR_WITH_FOLDERS))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.ArchiveOptions.Folder = "ThirdFolderWithItems";

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
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