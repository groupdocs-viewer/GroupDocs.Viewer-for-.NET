---
id: groupdocs-viewer-for-net-18-11-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-11-release-notes
title: GroupDocs.Viewer for .NET 18.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.11.{{< /alert >}}

## Major Features

There are 13 features, improvements, and fixes in this regular monthly release. The most notable are:
*    Added following file formats support
    *   Printer Command Language(PCL)        
    *   Tab-separated values (TSV)        
*   Handling fonts while rendering MS OneNote documents
*   A new method for rendering attachments while working with source document's stream

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-128 | Add PCL file format support | Feature |
| VIEWERNET-1786 | Add TSV (Tab-separated values) file format support | Feature |
| VIEWERNET-1768 | Rendering comments from ODP presentation documents that has no author  | Improvement |
| VIEWERNET-1778 | Rendering attachments while working with source document's stream | Improvement |
| VIEWERNET-1787 | Extend support for ExcludeFonts setting of HtmlOptions class for MS OneNote documents | Improvement |
| VIEWERNET-1789 | Exporting font files as external resources when rendering MS OneNote documents | Improvement |
| VIEWERNET-1793 | Add support for DefaultFontName option when rendering MS OneNote documents | Improvement |
| VIEWERNET-1549 | Exception when rendering email message containing .msg file as attachment | Bug |
| VIEWERNET-133 | Issues when rendering Japanese PDF document to HTML  | Bug |
| VIEWERNET-1231 | Font lightness is ignored for rendering Presentations into HTML | Bug |
| VIEWERNET-1790 | Resources are not created in cache after GetPrintableHtml called | Bug |
| VIEWERNET-1801 | Unexpected behavior of cache when both Image and Html handlers instantiated | Bug |
| VIEWERNET-1803 | Missing pst and ost formats in GetSupportedDocumentFormats(); | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.11. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}{{< alert style="info" >}}Since version 18.11, despite using the ViewerConfig.EnableCaching = true option, GetPrintableHtml method of the ViewerHtmlHandler and ViewerImageHandler classes does not cache the rendering results.{{< /alert >}}

### Supported File Formats

Following are the file formats that are supported since v18.11.

*   Printer Command Language(PCL)    
*   Tab-separated values (TSV)    

### List of Changes in v18.11

In version 18.11, following public class members were added, marked as obsolete, removed or replaced.

#### GroupDocs.Viewer.Domain.Containers.DocumentInfoContainer

##### string DocumentType { get; } property compilation is set to fail

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

##### string FileType { get; } property compilation is set to fail

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

##### string DocumentTypeFormat { get; } property compilation is set to fail

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

#### GroupDocs.Viewer.Domain.FileDescription

##### string BaseName { get; } property compilation is set to fail

This property is obsolete and will be removed after v18.11. To get base name use following code: System.IO.Path.GetFileNameWithoutExtension(fileDescription.Name).

##### string DocumentType { get; } property compilation is set to fail

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

##### string FileType { get; } property compilation is set to fail

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

##### string DocumentTypeFormat { get; } property compilation is set to fail

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

#### GroupDocs.Viewer.Handler.Input.IInputDataHandler

##### DateTime GetLastModificationDate(string guid) method has been removed

GroupDocs.Viewer will rely on LastModificationDate field in FileDescription object returned by GetFileDescription method.

#### GroupDocs.Viewer.Handler.ViewerHtmlHandler

##### public FileContainer GetFile(Stream fileStream, AttachmentBase attachment) overload has been added

Use this overload ofGetFilemethod to obtain attachment from document stream as shown in the following example.

**Obtaining attachment original file using document stream (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create HTML handler object
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
 
// Create attachment object and print out its name and file type
Attachment attachment = new Attachment("document-with-attachments.msg", "attachment-image.png");
Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType);
 
// Get attachment original file using document stream
using (FileStream fileStream = new FileStream("document-with-attachments.msg", FileMode.Open))
using (FileContainer fileContainer = htmlHandler.GetFile(fileStream, attachment))
{
    Console.WriteLine("Attach stream lenght: {0}", fileContainer.Stream.Length);
}
```

##### public List<PageHtml> GetPages(Stream fileStream, AttachmentBase attachment) overload has been added

Use this overload of GetPages method to render attachment from document stream as shown below.

##### public List<PageHtml> GetPages(Stream fileStream, AttachmentBase attachment, HtmlOptions htmlOptions) overload has been added

Use this overload of GetPages method to render attachment from document stream as shown below.

**Rendering attachment using document stream (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
viewerConfig.UseCache = true;
 
using (FileStream fileStream = new FileStream("document-with-attachments.msg", FileMode.Open))
{
    // Init viewer HTML handler
    ViewerHtmlHandler handler = new ViewerHtmlHandler(viewerConfig);
 
    DocumentInfoContainer info = handler.GetDocumentInfo(fileStream);
 
    // Iterate over the attachments collection
    foreach (AttachmentBase attachment in info.Attachments)
    {
        Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType);
 
        // Get attachment document image representation
        List<PageHtml> pages = handler.GetPages(fileStream, attachment, htmlOptions);
        foreach (PageImage page in pages)
            Console.WriteLine("  Page: {0}, size: {1}", page.PageNumber, page.Stream.Length);
    }
}
```

#### GroupDocs.Viewer.Handler.ViewerImageHandler

##### public FileContainer GetFile(Stream fileStream, AttachmentBase attachment) overload has been added

Use this overload ofGetFilemethod to obtain attachment from the document stream as shown in the following example.

**Obtaining attachment original file using document stream (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create image handler object
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
 
// Create attachment object and print out its name and file type
Attachment attachment = new Attachment("document-with-attachments.msg", "attachment-image.png");
Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType);
 
// Get attachment original file using document stream
using (FileStream fileStream = new FileStream("document-with-attachments.msg", FileMode.Open))
using (FileContainer fileContainer = imageHandler.GetFile(fileStream, attachment))
{
    Console.WriteLine("Attach stream lenght: {0}", fileContainer.Stream.Length);
}
```

##### public List<PageHtml> GetPages(Stream fileStream, AttachmentBase attachment) overload has been added

Use this overload of GetPages method to render attachment from document stream as shown below.

##### public List<PageHtml> GetPages(Stream fileStream, AttachmentBase attachment, HtmlOptions htmlOptions) overload has been added

Use this overload of GetPages method to render attachment from document stream as shown below.

**Rendering attachment using document stream (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
viewerConfig.UseCache = true;
 
using (FileStream fileStream = new FileStream("document-with-attachments.msg", FileMode.Open))
{
    // Init viewer image handler
    ViewerImageHandler handler = new ViewerImageHandler(viewerConfig);
 
    DocumentInfoContainer info = handler.GetDocumentInfo(fileStream);
 
    // Iterate over the attachments collection
    foreach (AttachmentBase attachment in info.Attachments)
    {
        Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType);
 
        // Get attachment document image representation
        List<PageImage> pages = handler.GetPages(fileStream, attachment, htmlOptions);
        foreach (PageImage page in pages)
            Console.WriteLine("  Page: {0}, size: {1}", page.PageNumber, page.Stream.Length);
    }
}
```
