---
id: how-to-determine-file-type
url: viewer/net/how-to-determine-file-type
title: How to determine file type
weight: 4
description: "This article explains how to get a type of a file with GroupDocs.Viewer for .NET using .NET / C#."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Introduction
**File type** or **file format** is the way to classify and differentiate one kind of file from another. For example, Microsoft Excel and Adobe PDF are two different **file types**. The common way to determine the file type is by its extension, so when you have a file e.g. sample.docx you expect that this file will be opened by some text processing application like Microsoft Word. But there are the cases when you don't know the file type e.g. when the file came from the Internet but you don't know its name or filename doesn't have an extension.

## Determining file type
**GroupDocs.Viewer** enables you to determine the file type by file extension, media-type, or raw bytes. The code snippets provided in this article can also be found in [our public examples at GitHub.](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/blob/master/Examples/GroupDocs.Viewer.Examples.CSharp/HowTo/HowToDetermineFileType.cs)

### Determining file-type from the file extension
To determine file type from the file extension use [FromExtension()](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype/methods/fromextension) method of [FileType](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype) class.

```csharp
string extension = ".docx";
FileType fileType = FileType.FromExtension(extension);
Console.WriteLine($"\nExtension {extension}; File type: {fileType}.");
```

As you can see from the screenshot below the file type detected correctly.
![](viewer/net/images/how-to-determine-file-type.png)

### Determining file-type from the media-type
In case you receive a file from the Internet and you have only its media-type use [FromMediaType()](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype/methods/frommediatype) method of [FileType](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype) class.
```csharp
string mediaType = "application/pdf";
FileType fileType = FileType.FromMediaType(mediaType);
Console.WriteLine($"\nMedia-type {mediaType}; File type: {fileType}.");
```

The media-type will be mapped to the file type as shown on the screenshot below.
![](viewer/net/images/how-to-determine-file-type_1.png)

### Determining file type form stream or bytes
When you don't know the name of a file or media-type you can try determining file type by passing stream to [FromStream()](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype/methods/fromstream) method of [FileType](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype). GroupDocs.Viewer will try reading the file signature and map it to the file type.
```csharp
using (Stream stream = File.OpenRead("sample.docx"))
{
    FileType fileType = FileType.FromStream(stream);

    Console.WriteLine($"\nFile path {TestFiles.SAMPLE_DOCX}; File type: {fileType}.");
}
```

A similar output would be printed in case of GroupDocs.Viewer detected the file type successfully.
![](viewer/net/images/how-to-determine-file-type_2.png)

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
You are welcome to view your documents with free to use online [GroupDocs Viewer App](https://products.groupdocs.app/viewer).