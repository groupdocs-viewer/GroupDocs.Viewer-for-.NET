using System;
using System.IO;
using GroupDocs.Viewer.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

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

            using (Viewer viewer = new Viewer(() => DownloadFile(blobName)))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);                
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
                
        public static Stream DownloadFile(string blobName)
        {
            CloudBlobContainer container = GetContainer();

            CloudBlob blob = container.GetBlobReference(blobName);
            MemoryStream memoryStream = new MemoryStream();
            blob.DownloadToStream(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }

        private static CloudBlobContainer GetContainer()
        {
            string accountName = "***";
            string accountKey = "***";
            string endpoint = $"https://{accountName}.blob.core.windows.net/";
            string containerName = "***";

            StorageCredentials storageCredentials = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(
                storageCredentials, new Uri(endpoint), null, null, null);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = cloudBlobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();

            return container;
        }
    }
}
