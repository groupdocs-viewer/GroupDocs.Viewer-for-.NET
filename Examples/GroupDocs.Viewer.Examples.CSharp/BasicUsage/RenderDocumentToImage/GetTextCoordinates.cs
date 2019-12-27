using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToImage
{
    /// <summary>
    /// This example demonstrates how to extract text from a document.
    /// </summary>
    class GetTextCoordinates
    {
        public static void Run()
        {               
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DOCX))
            {
                ViewInfoOptions options = ViewInfoOptions.ForPngView(true);
                ViewInfo viewInfo = viewer.GetViewInfo(options);

                foreach(Page page in viewInfo.Pages)
                {
                    Console.WriteLine($"Page: {page.Number}");
                    Console.WriteLine("Text lines/words/characters:");
                                        
                    foreach (Line line in page.Lines)
                    {
                        Console.WriteLine(line);
                        foreach (Word word in line.Words)
                        {
                            Console.WriteLine("\t" + word);
                            foreach (Character character in word.Characters)
                                Console.WriteLine("\t\t" + character);
                        }
                    }
                }
            }

            Console.WriteLine("\nDocument text extracted successfully.\n");
        }
    }
}
