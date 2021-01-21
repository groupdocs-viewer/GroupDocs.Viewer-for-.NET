using System;
using System.IO;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.ProcessingAttachments
{
    /// <summary>
    /// This example demonstrates how to render attachment into HTML.
    /// </summary>
    class RenderDocumentAttachments
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            Attachment attachment = new Attachment("attachment-word.doc");
            MemoryStream attachmentStream = new MemoryStream();

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_MSG_WITH_ATTACHMENTS))
            {
                viewer.SaveAttachment(attachment, attachmentStream);
            }

            using (Viewer viewer = new Viewer(attachmentStream))
            {
                HtmlViewOptions options =
                    HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nAttachment rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

