using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This examples demonstrates how to print out all supported file types.
    /// </summary>
    class GetSupportedFileFormats
    {
        public static void Run()
        {
            IEnumerable<FileType> fileTypes = FileType
                    .GetSupportedFileTypes()
                    .OrderBy(fileType => fileType.Extension);

            foreach (FileType fileType in fileTypes)
                Console.WriteLine(fileType);

            Console.WriteLine("\nSupported file types retrieved successfully.");
        }
    }
}
