using System;
using System.IO;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.ProcessingAttachments
{
    /// <summary>
    /// This example demonstrates how to render email message attachments into HTML.
    /// </summary>
    class RenderDocumentAttachments
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_MSG_WITH_ATTACHMENTS))
            {
                var attachments = viewer.GetAttachments();

                foreach (var attachment in attachments)
                {
                    MemoryStream attachmentStream = new MemoryStream();
                    viewer.SaveAttachment(attachment, attachmentStream);
                    attachmentStream.Position = 0;

                    RenderAttachment(attachment, attachmentStream, outputDirectory);
                }
            }

            Console.WriteLine($"\nAttachment rendered successfully.\nCheck output in {outputDirectory}.");
        }

        private static void RenderAttachment(Attachment attachment, MemoryStream attachmentStream, 
            string outputDirectory)
        {
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            string extension = Path.GetExtension(attachment.FileName);
            FileType fileType = FileType.FromExtension(extension);
            LoadOptions loadOptions = new LoadOptions(fileType);
            
            using (Viewer viewer = new Viewer(attachmentStream, loadOptions))
            {
                HtmlViewOptions options =
                    HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }
        }
    }
}

