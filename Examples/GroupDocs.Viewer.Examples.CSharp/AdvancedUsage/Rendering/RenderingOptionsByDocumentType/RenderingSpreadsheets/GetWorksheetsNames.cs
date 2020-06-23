using System;
using System.IO;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingSpreadsheets
{
    /// <summary>
    /// This example demonstrates how to retrieve and print worksheets names.
    /// </summary>
    class GetWorksheetsNames
    {
        public static void Run()
        {
            using (Viewer viewer = new Viewer(TestFiles.THREE_SHEETS))
            {
                ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForHtmlView();
                viewInfoOptions.SpreadsheetOptions = SpreadsheetOptions.ForOnePagePerSheet();

                ViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions);

                Console.WriteLine("Worksheets:");
                foreach (Page page in viewInfo.Pages)
                {
                    Console.WriteLine($" - Worksheet {page.Number} name '{page.Name}'");
                }
            }
        }
    }
}

