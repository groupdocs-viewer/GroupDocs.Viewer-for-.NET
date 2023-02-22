using System;
using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to check if the file is encrypted.
    /// </summary>
    class CheckFileIsEncrypted
    {
        public static void Run()
        {            
            using (Viewer viewer = new Viewer(TestFiles.ENCRYPTED))
            {
                Results.FileInfo fileInfo = viewer.GetFileInfo();

                Console.WriteLine("File type is: " + fileInfo.FileType);
                Console.WriteLine("File encrypted: " + fileInfo.Encrypted);
            }

            Console.WriteLine("\nFile info retrieved successfully.");
        }
    }
}
