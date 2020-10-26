using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GroupDocs.Viewer.Logging;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.HowTo
{
    /// <summary>
    /// This example demonstrates how to logging to file or console.
    /// </summary>
    public static class HowToLogging
    {
        /// <summary>
        /// Logging to console.
        /// </summary>
        public static void ToConsole()
        {
            ViewerSettings viewerSettings = new ViewerSettings(new ConsoleLogger());

            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_PDF, viewerSettings))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// Logging to file.
        /// </summary>
        public static void ToFile()
        {
            ViewerSettings viewerSettings = new ViewerSettings(new FileLogger("output.log"));

            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_PDF, viewerSettings))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
