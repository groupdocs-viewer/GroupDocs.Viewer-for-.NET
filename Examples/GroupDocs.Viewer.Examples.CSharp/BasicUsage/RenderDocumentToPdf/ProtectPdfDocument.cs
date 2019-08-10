using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToPdf
{
    /// <summary>
    /// This example demonstrates how to protect output PDF document.
    /// </summary>
    class ProtectPdfDocument
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string filePath = Path.Combine(outputDirectory, "output.pdf");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {
                Security security = new Security
                {
                    DocumentOpenPassword = "o123",
                    PermissionsPassword = "p123",
                    Permissions = Permissions.AllowAll ^ Permissions.DenyPrinting
                };

                PdfViewOptions options = new PdfViewOptions(filePath)
                {
                    Security = security
                };

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}