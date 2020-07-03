---
id: how-to-list-and-print-all-supported-file-types
url: viewer/net/how-to-list-and-print-all-supported-file-types
title: How to list and print all supported file types
weight: 5
description: "This article explains how to list and print file types supported by GroupDocs.Viewer for .NET using .NET / C#."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Get supported file formats

Here is the full list of [supported file formats]({{< ref "viewer/net/getting-started/supported-document-formats.md" >}}). In case you need to list or print out all of the supported file formats in your application you can do the following:

*   Call [GetSupportedFileTypes](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/filetype/methods/getsupportedfiletypes) methodof [FileType](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/filetype) class;
*   Enumerate through the collection of [FileType](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/filetype) objects. 

The following code sample demonstrates how to print all supported file formats list to the console.

```csharp
IEnumerable<FileType> supportedFileTypes = FileType.GetSupportedFileTypes();

foreach (FileType fileType in supportedFileTypes)
	Console.WriteLine(fileType);
```

## More resources
### Advanced Usage Topics
To learn more about document viewing features, please refer to the [advanced usage section]({{< ref "viewer/net/developer-guide/advanced-usage/_index.md" >}}).

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