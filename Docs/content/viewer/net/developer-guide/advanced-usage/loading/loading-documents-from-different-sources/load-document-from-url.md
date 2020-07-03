---
id: load-document-from-url
url: viewer/net/load-document-from-url
title: Load document from URL
weight: 6
description: "This article explains how to load a document from URL with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Following example demonstrates how to render document from URL.

```csharp
 		public static void LoadDocumentFromUrl()
        {
            string url = "https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/blob/master/Examples/Resources/SampleFiles/sample.docx?raw=true";
            
			using (Viewer viewer = new Viewer(() => GetRemoteFile(url)))
            {
                HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();                
                viewer.View(viewOptions);
            }
        }
                
        private static Stream GetRemoteFile(string url)
        {
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = request.GetResponse())
                return GetFileStream(response);
        }

        private static Stream GetFileStream(WebResponse response)
        {
            MemoryStream fileStream = new MemoryStream();
            using (Stream responseStream = response.GetResponseStream())
                responseStream.CopyTo(fileStream);
            fileStream.Position = 0;
            return fileStream;
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