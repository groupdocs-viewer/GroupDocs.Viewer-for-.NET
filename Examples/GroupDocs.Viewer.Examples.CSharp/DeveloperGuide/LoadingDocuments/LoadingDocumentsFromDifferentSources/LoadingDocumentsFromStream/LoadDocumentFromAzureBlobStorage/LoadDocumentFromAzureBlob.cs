namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingDocumentsFromDifferentSources.LoadingDocumentsFromStream.LoadDocumentFromAzureBlobStorage;

using System.IO;
using Azure.Storage.Blobs;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadDocumentFromAzureBlob
{
    public static void Run()
    {
        // ...

        string blobName = "sample.docx";
        Stream stream = DownloadFile(blobName);
        LoadOptions loadOptions = new LoadOptions(FileType.DOCX);

        using (Viewer viewer = new Viewer(stream, loadOptions))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }

        static Stream DownloadFile(string blobName)
        {
            BlobContainerClient containerClient = GetContainerClient();

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            MemoryStream memoryStream = new MemoryStream();
            blobClient.DownloadTo(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }

        static BlobContainerClient GetContainerClient()
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
