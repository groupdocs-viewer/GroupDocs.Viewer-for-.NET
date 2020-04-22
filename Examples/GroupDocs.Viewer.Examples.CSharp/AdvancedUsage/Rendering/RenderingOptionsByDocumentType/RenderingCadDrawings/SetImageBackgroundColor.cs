using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingCadDrawings
{
    /// <summary>
    /// This example demonstrates how to adjust output image size when rendering CAD drawings.
    /// </summary>
    class SetImageBackgroundColor
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DWG_WITH_LAYOUTS_AND_LAYERS))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
                options.CadOptions = CadOptions.ForRenderingByWidth(800);
                options.CadOptions.BackgroundColor = System.Drawing.Color.Green;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
