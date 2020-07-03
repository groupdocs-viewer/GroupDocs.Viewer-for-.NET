---
id: load-document-from-amazon-s3-storage
url: viewer/net/load-document-from-amazon-s3-storage
title: Load document from Amazon S3 Storage
weight: 1
description: "This article explains how to load a document from Amazon S3 Storage with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Following example demonstrates how to render document from Amazon S3 Storage.

```csharp
 		string key = "sample.docx";

        using (Viewer viewer = new Viewer(() => DownloadFile(key)))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();                

            viewer.View(viewOptions);
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
