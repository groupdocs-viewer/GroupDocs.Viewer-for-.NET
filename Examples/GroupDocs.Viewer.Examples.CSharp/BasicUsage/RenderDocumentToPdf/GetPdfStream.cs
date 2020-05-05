using System;
using System.IO;
using GroupDocs.Viewer.Interfaces;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToPdf
{
    /// <summary>
    /// This example demonstrates how to convert file to PDF and get PDF file stream.
    /// </summary>
    class GetPdfStream
    {
        public static void Run()
        {
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DOCX))
            {
                MemoryFileStreamFactory streamFactory = new MemoryFileStreamFactory();
                PdfViewOptions options = new PdfViewOptions(streamFactory);

                viewer.View(options);

                // Return or write stream
                MemoryStream stream = streamFactory.Stream;
            }

            Console.WriteLine("\nSource document rendered successfully.");
        }

        private class MemoryFileStreamFactory : IFileStreamFactory
        {
            public MemoryStream Stream { get; }

            public MemoryFileStreamFactory()
            {
                Stream = new MemoryStream();
            }

            public Stream CreateFileStream()
            {
                return Stream;
            }

            public void ReleaseFileStream(Stream fileStream)
            {
                //Do not dispose stream here
            }
        }
    }
}
