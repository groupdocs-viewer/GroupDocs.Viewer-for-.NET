namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives._index;

using System.Collections.Generic;
using System.IO;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class ExtractFilesFromArchive
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("documents.zip"))
        {
            IList<Attachment> allAttachments = viewer.GetAttachments();

            //Iterate over all attachments and save them
            foreach (Attachment attachment in allAttachments)
            {
                Console.WriteLine("- {0} - {1} - {2} bytes", attachment.FilePath, attachment.FileType, attachment.Size);
        		MemoryStream destination = new MemoryStream();
                viewer.SaveAttachment(attachment, destination);
            }

            //Create one Attachment manually and save it
            Attachment oneAttachment = new Attachment("/Invoices/INV-26401-quayside-deli--cafe.pdf", "/Invoices/INV-26401-quayside-deli--cafe.pdf");
            using (FileStream extractedFile = File.Create("INV-26401-quayside-deli--cafe.pdf"))
            {
                viewer.SaveAttachment(oneAttachment, extractedFile);
            }
        }
    }
}
