using System;
using System.Diagnostics;
using System.IO;
using GroupDocs.Viewer.Caching;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Caching
{
    /// <summary>
    /// This example demonstrates how to enable cache when render document.
    /// </summary>
    class UseCacheWhenProcessingDocuments
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string cachePath = Path.Combine(outputDirectory, "cache");
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            FileCache cache = new FileCache(cachePath);
            ViewerSettings settings = new ViewerSettings(cache);

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DOCX, settings))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                Stopwatch stopWatch = Stopwatch.StartNew();
                viewer.View(options);
                stopWatch.Stop();

                Console.WriteLine("Time taken on first call to View method {0} (ms).", stopWatch.ElapsedMilliseconds);

                stopWatch.Restart();
                viewer.View(options);
                stopWatch.Stop();

                Console.WriteLine("Time taken on second call to View method {0} (ms).", stopWatch.ElapsedMilliseconds);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
