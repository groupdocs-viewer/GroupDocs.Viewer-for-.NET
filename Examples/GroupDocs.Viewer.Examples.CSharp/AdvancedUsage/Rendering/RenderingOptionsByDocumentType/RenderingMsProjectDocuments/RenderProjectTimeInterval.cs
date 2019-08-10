using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingMsProjectDocuments
{
    /// <summary>
    /// This example demonstrates how to render project document within the specified time interval.
    /// </summary>
    class RenderProjectTimeInterval
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_MPP))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                options.ProjectManagementOptions.StartDate = new DateTime(2008, 6, 1);
                options.ProjectManagementOptions.EndDate = new DateTime(2008, 7, 1);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

