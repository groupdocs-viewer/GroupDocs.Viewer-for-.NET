namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.ProcessingAttachments.HowToListAttachments;

using System.Collections.Generic;
using System;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class ListAttachments
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.msg"))
        {
            // Get list of attachments.
            IList<Attachment> attachments = viewer.GetAttachments();

            // Display list of attachments.
            Console.WriteLine("\nAttachments:");
            foreach (Attachment attachment in attachments)
                Console.WriteLine(attachment);
        }
    }
}
