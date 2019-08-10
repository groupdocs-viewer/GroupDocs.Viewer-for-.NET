using System;
using System.IO;
using Amazon.S3;
using Amazon.S3.Model;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Loading.LoadingDocumentsFromDifferentSources
{
    /// <summary>
    /// This example demonstrates how to download document from Amazon S3 storage and render document.
    /// </summary>
    class LoadDocumentFromAmazonS3
    {
        public static void Run()
        {
            string key = "sample.docx";
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(() => DownloadFile(key)))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);                
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
                
        public static Stream DownloadFile(string key)
        {
            AmazonS3Client client = new AmazonS3Client();
            string bucketName = "my-bucket";

            GetObjectRequest request = new GetObjectRequest
            {
                Key = key,
                BucketName = bucketName
            };
            using (GetObjectResponse response = client.GetObject(request))
            {
                MemoryStream stream = new MemoryStream();
                response.ResponseStream.CopyTo(stream);
                stream.Position = 0;
                return stream;
            }
        }
    }
}
