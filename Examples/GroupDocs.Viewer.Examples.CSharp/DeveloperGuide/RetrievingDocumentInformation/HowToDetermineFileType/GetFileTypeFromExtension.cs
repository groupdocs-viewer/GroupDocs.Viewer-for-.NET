namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToDetermineFileType;

using System.IO;
using System;
using GroupDocs.Viewer;

public static class GetFileTypeFromExtension
{
    public static void Run()
    {
        // ...

        // Specify a file extension.
        string extension = ".docx";
        // Set a file type using the extension.
        FileType fileType = FileType.FromExtension(extension);
        // Display the extension and the file type.
        Console.WriteLine($"Extension {extension}; File type: {fileType}.");
    }
}
