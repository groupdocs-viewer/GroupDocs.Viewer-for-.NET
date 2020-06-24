using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.HowTo
{
    /// <summary>
    /// This example demonstrates how to determine file type when you have file extension, media-type or stream.
    /// </summary>
    public static class HowToDetermineFileType
    {
        public static void FromFileExtension()
        {
            string extension = ".docx";
            FileType fileType = FileType.FromExtension(extension);

            Console.WriteLine($"\nExtension {extension}; File type: {fileType}.");
        }

        public static void FromMediaType()
        {
            string mediaType = "application/pdf";
            FileType fileType = FileType.FromMediaType(mediaType);

            Console.WriteLine($"\nMedia-type {mediaType}; File type: {fileType}.");
        }

        public static void FromStream()
        {
            using (Stream stream = File.OpenRead(TestFiles.SAMPLE_DOCX))
            {
                FileType fileType = FileType.FromStream(stream);

                Console.WriteLine($"\nFile path {TestFiles.SAMPLE_DOCX}; File type: {fileType}.");
            }
        }
    }
}