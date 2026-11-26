namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToDetermineFileType;

using System.IO;
using System;
using GroupDocs.Viewer;

public static class GetFileTypeFromStream
{
    public static void Run()
    {
        // ...

        using (Stream stream = File.OpenRead("sample.docx"))
        {
            FileType fileType = FileType.FromStream(stream);
            Console.WriteLine($"File type: {fileType}.");
        }
    }
}
