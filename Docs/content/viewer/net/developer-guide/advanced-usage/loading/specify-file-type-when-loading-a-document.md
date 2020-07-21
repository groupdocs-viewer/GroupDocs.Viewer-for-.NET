---
id: specify-file-type-when-loading-a-document
url: viewer/net/specify-file-type-when-loading-a-document
title: Specify file type when loading a document
weight: 1
description: "This article explains how to set the file type when loading a document with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---

When passing file path or [FileStream](https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream) into [Viewer](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/viewer) class constructor the GroupDocs.Viewer determines file type by file extension but when file passed as a stream the GroupDocs.Viewer tries to detect file type by file signature or file content and this may affect application performance. The API enables you to specify the file type of the processing document by passing [LoadOptions](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/loadoptions) object as the second parameter of [Viewer](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/viewer) class constructor. When you're passing file type it instructs GroupDocs.Viewer to skip file type detection feature and proceed with rendering.

The following code sample shows how to pass the file type when loading a document.

```csharp
LoadOptions loadOptions = new LoadOptions(FileType.DOCX);

using (Viewer viewer = new Viewer(() => GetFile("sample.docx"), () => loadOptions))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewer.View(viewOptions);
}
```

## More resources

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App

Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.
