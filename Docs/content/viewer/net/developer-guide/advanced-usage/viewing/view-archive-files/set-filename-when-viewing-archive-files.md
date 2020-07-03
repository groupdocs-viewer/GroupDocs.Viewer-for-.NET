---
id: set-filename-when-viewing-archive-files
url: viewer/net/set-filename-when-viewing-archive-files
title: Set filename when viewing archive files
weight: 3
description: "This article explains how to specify a filename when viewing archive files GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
![](viewer/net/images/set-filename-when-viewing-archive-files.png)

When viewing the archive files GroupDocs.Viewer displays an archive filename in the header of each page, like it is shown on the screenshot above. By default, the name of the original file is used. The GroupDocs.Viewer enables you to change or hide filename by setting [FileName](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/archiveoptions/properties/filename) option of the [ArchiveOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/archiveoptions) class. The [FileName](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/archiveoptions/properties/filename) option can be set to: 

*   [FileName.Source](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/archiveoptions/properties/filename/source) - the default value, the name of the source file will be used;
*   [FileName.Empty](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/archiveoptions/properties/filename/empty) - empty filename, use it when you want to hide filename;
*   [new FileName("my filename")](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/archiveoptions/properties/filename/constructors/main) - custom filename.

The following code snippet shows how to set "my filename" instead of source filename when viewing an archive file.

```csharp
using (Viewer viewer = new Viewer("sample.zip"))
{
    PdfViewOptions viewOptions = new PdfViewOptions();
    viewOptions.ArchiveOptions.FileName = new FileName("my filename");

    viewer.View(viewOptions);
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