namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToCheckIfFileIsEncrypted;

using System.IO;
using System;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class CheckIfFileIsEncrypted
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("protected.pdf"))
        {
            // Get file information.
            var fileInfo = viewer.GetFileInfo();

            // Display the file type and flag if the file is encrypted.
            Console.WriteLine("File type is: " + fileInfo.FileType);
            Console.WriteLine("File encrypted: " + fileInfo.Encrypted);
        }
    }
}
