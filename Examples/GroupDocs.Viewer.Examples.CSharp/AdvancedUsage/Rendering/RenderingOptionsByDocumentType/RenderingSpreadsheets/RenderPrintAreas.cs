using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingSpreadsheets
{
    /// <summary>
    /// This example demonstrates how to render print area(s).
    /// </summary>
    class RenderPrintAreas
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_XLSX_WITH_PRINT_AREAS))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.SpreadsheetOptions = SpreadsheetOptions.ForRenderingPrintArea();

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

