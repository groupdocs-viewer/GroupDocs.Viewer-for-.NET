#if !NETCOREAPP
using Azure.Storage.Blobs;
using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Loading.LoadingDocumentsFromDifferentSources
{
    /// <summary>
    /// This example demonstrates how to download document from Azure Blob storage and render document.
    /// </summary>
    class LoadDocumentFromAzureBlobStorage
    {
        public static void Run()
        {
            string blobName = "sample.docx";
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
            Stream stream = DownloadFile(blobName);
            using (Viewer viewer = new Viewer(stream))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);                
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
                
        public static Stream DownloadFile(string blobName)
        {
            BlobContainerClient containerClient = GetContainerClient();

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            MemoryStream memoryStream = new MemoryStream();
            blobClient.DownloadTo(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }

        private static BlobContainerClient GetContainerClient()
        {
            string accountName = "***";
            string accountKey = "***";
            string endpointSuffix = "core.windows.net";
            string containerName = "***";

            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={accountName};AccountKey={accountKey};EndpointSuffix={endpointSuffix}";

            // Create a BlobContainerClient object which will be used to create a container client
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);

            return blobContainerClient;
        }
    }
}

#endif