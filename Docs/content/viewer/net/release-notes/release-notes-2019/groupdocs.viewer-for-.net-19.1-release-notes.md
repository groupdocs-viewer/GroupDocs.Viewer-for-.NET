---
id: groupdocs-viewer-for-net-19-1-release-notes
url: viewer/net/groupdocs-viewer-for-net-19-1-release-notes
title: GroupDocs.Viewer for .NET 19.1 Release Notes
weight: 12
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 19.1.{{< /alert >}}

## Major Features

There are 11 features, improvements, and fixes in this regular monthly release. The most notable are:

*   Added VCF file format support
*   Simplified caching interface
*   Obtaining statuses of layers contained in CAD documents
*   Obtaining email messages contained in Outlook Data File documents as attachments

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1781 | Add support for VCF format  | Feature |
| VIEWERNET-1782 | Obtaining email messages contained in OST/PST formats as attachments | Feature |
| VIEWERNET-1783 | Settings for filtering messages from OST/PST documents by subject and content  | Feature |
| VIEWERNET-1784 | Settings for filtering messages from OST/PST formats by sender | Feature |
| VIEWERNET-1831 | Obtaining layers statuses for CAD documents | Feature |
| VIEWERNET-1792 | Add support for rendering password protected ODS documents | Improvement |
| VIEWERNET-1812 | Simplify caching interface | Improvement |
| VIEWERNET-1798 | Descriptive Exception message when non-existing default font name is set | Improvement |
| VIEWERNET-1800 | Header is missing when rendering Word document  | Bug |
| VIEWERNET-1832 | Exception when getting document info of .msg file using MemoryStream | Bug |
| VIEWERNET-1842 | Images are not visible in Chrome browser when rendering OneNote documents | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 19.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Obtaining and rendering email messages contained in Outlook Data File documents 

Since version 19.1, GroupDocs.Viewer for .NET allows getting the list of email messages contained in Outlook Data File documents (OST/PST formats). Email messages are listed as **Attachments** in **DocumentInfoContainer** object returned by **GetDocumentInfo** method of the corresponding viewer handler. They can be obtained through the **GetFile** method as shown in the example below:

**C# (Obtaining attachment from document that is stored on the disk)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create image handler object and get the list of email messages as attachments.
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
DocumenInfoContainer documentInfo = imageHandler.GetDocumentInfo("archive.pst")
foreach(Attachment attachment in documentInfo.Attachments)
{
    //Print out attachment name and file type.
    Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType);
 
    // Get attachment original file and print out Stream length
    using (FileContainer fileContainer = imageHandler.GetFile(attachment))
    {
        Console.WriteLine("Attach stream lenght: {0}", fileContainer.Stream.Length);
    }
}
```

Attachments can be rendered as shown in examples below:



```csharp
// Setup HTML conversion options
HtmlOptions htmlOptions = new HtmlOptions();
  
// Initialize viewer html handler
ViewerHtmlHandler handler = new ViewerHtmlHandler(viewerConfig); 
DocumentInfoContainer info = handler.GetDocumentInfo("archive.pst");
 
// Iterate over the attachments collection
foreach (AttachmentBase attachment in info.Attachments)
{
    // Get attachment document html representation
    List<PageHtml> pages = handler.GetPages(attachment, htmlOptions);
    foreach (PageHtml page in pages)
    {
        Console.WriteLine("  Page: {0}, size: {1}", page.PageNumber, page.HtmlContent.Length);
    }
}
```

### Filtering Outlook messages when rendering into HTML, image, and PDF

![](viewer/net/images/groupdocs-viewer-for-net-19-1-release-notes.png)

Since version 19.1, GroupDocs.Viewer for .NET allows filtering rendered messages by subject and content or by sender and recipient email address. As an example, when you set **OutlookOptions.TextFilter** as 'Susan' you get rendered all messages that contain text 'Susan' in the message subject or body. When you set **OutlookOptions.AddressFilter** as 'susan' you are filtering messages that contain 'susan' as a part of the sender or recipient address. The examples below show how to filter the rendered items.

**Filtering messages that are rendered into image or HTML**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler or use ViewerHtmlHandler to render into HTML
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "sample.pst";
  
// Create image options with specified folder name (use HtmlOptions to render into HTML)
ImageOptions options = new ImageOptions();
options.OutlookOptions.TextFilter = "Susan";
 
// Render document into image (List<PageHtml> is returned when rendering into HTML)
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
    // use page.Stream to work with rendering result
}
```

**Filtering messages that are rendered into PDF**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "sample.pst";
  
// Create pdf options with specified address filter
PdfFileOptions options = new PdfFileOptions();
options.OutlookOptions.AddressFilter = "susan";
 
// Get pdf document
FileContainer fileContainer = imageHandler.GetPdfFile(guid, options);
  
// Access result PDF document using fileContainer.Stream property
```

### Obtaining layers visibility information from CAD drawings

Prior to version 19.1, GroupDocs.Viewer for .NET API allowed to obtain the list of layer names. This feature provides you with the ability to render certain layers. Since version 19.1, along with the layer name you are getting layer visibility status (visible/invisible) as well. The layers are invisible when they are frozen or switched off in the original CAD drawing, otherwise, they are visible. This additional information allows deciding which layer to render relying on layer visibility status. The example below shows how to get layers visibility status:

**Obtaining the list of all existing layers from CAD document**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "withLayers.dwg";
  
CadDocumentInfoContainer documentInfo = (CadDocumentInfoContainer) imageHandler.GetDocumentInfo(guid);
 
// Loop through all layers contained in the drawing 
foreach (CadLayer layer in documentInfo.Layers)
    Console.WriteLine("Layer name and visibility: {0}-{1}", layer.Name, layer.Visible); 
```

### List of Changes in v19.1

In version 19.1, following public class members were added, marked as obsolete, removed or replaced.

#### GroupDocs.Viewer.Config.ViewerConfig

##### public string LocalesPath property has been set as obsolete 

This property is obsolete and will be removed after v19.2. GroupDocs.Viewer no longer provides localization supports.

#### GroupDocs.Viewer.Handler.Cache.ICacheDataHandler

##### public DateTime? GetLastModificationDate method has been set as obsolete 

This property is obsolete and will be removed after v19.3. GroupDocs.Viewer will no longer rely on document last modification date while caching or retrieving render results from cache.
