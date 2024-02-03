using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.CommonRenderingOptions
{
    /// <summary>
    /// This example demonstrates how set output image size limits when rendering documents to JPG/PNG.
    /// </summary>
    class SetImageSizeLimits
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string outputFile = Path.Combine(outputDirectory, "result_image_size_limit.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DOCX))
            {
                JpgViewOptions options =
                   new JpgViewOptions(outputFile);

                options.MaxWidth = 400;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
