namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToDetermineFileType;

using System.IO;
using System;
using GroupDocs.Viewer;

public static class GetFileTypeFromMediaType
{
    public static void Run()
    {
        // ...

        string mediaType = "application/pdf";
        FileType fileType = FileType.FromMediaType(mediaType);
        Console.WriteLine($"Media-type {mediaType}; File type: {fileType}.");
    }
}
