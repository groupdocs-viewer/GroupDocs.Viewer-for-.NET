---
id: load-document-from-azure-blob-storage
url: viewer/net/load-document-from-azure-blob-storage
title: Load document from Azure Blob Storage
weight: 2
description: "This article explains how to load a document from Azure Blob Storage with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Following example demonstrates how to render document from Azure Blob Storage.

```csharp
 		string blobName = "sample.docx";

        using (Viewer viewer = new Viewer(() => DownloadFile(blobName)))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();                

            viewer.View(viewOptions);
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
```

## More resources
### GitHub Examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)    
*   [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)    
*   [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)     
*   [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)    
*   [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)    
*   [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App
Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.