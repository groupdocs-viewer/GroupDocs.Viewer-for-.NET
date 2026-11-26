namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToListAndPrintAllSupportedFileTypes;

using System.Collections.Generic;
using System;
using GroupDocs.Viewer;

public static class ListSupportedFileTypes
{
    public static void Run()
    {
        // ...

        // Get list of file types.
        IEnumerable<FileType> supportedFileTypes = FileType.GetSupportedFileTypes();

        // Display list of file types
        foreach (FileType fileType in supportedFileTypes)
        {
            Console.WriteLine(fileType);
        }
    }
}
