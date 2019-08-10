using System;
using System.Collections.Generic;
using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.ProcessingAttachments
{
    /// <summary>
    /// This example demonstrates how to retrieve and print all attachments.
    /// </summary>
    class RetrieveAndPrintDocumentAttachments
    {
        public static void Run()
        {
            using (Viewer viewer = new Viewer(Constants.SAMPLE_MSG_WITH_ATTACHMENTS))
            {
                IList<Attachment> attachments = viewer.GetAttachments();

                Console.WriteLine("\nAttachments:");
                foreach(Attachment attachment in attachments)
                    Console.WriteLine(attachment);
            }

            Console.WriteLine($"\nAttachments retrieved successfully.");
        }
    }
}

