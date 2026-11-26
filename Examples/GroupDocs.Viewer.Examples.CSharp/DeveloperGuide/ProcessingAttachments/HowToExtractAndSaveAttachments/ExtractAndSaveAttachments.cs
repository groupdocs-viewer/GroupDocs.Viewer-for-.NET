namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.ProcessingAttachments.HowToExtractAndSaveAttachments;

using System.Collections.Generic;
using System.IO;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class ExtractAndSaveAttachments
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("with_attachments.msg"))
        {
            // Get list of attachments.
            IList<Attachment> attachments = viewer.GetAttachments();
            // Save each attachment to the output folder.
            Directory.CreateDirectory("output");
            foreach (Attachment attachment in attachments)
            {
                string filePath = Path.Combine("output", attachment.FileName);
                using (FileStream stream = File.Create(filePath))
                {
                    viewer.SaveAttachment(attachment, stream);
                }
            }
        }
    }
}
