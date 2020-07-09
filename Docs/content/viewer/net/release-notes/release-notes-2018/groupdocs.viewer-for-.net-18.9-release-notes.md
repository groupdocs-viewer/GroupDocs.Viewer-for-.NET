---
id: groupdocs-viewer-for-net-18-9-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-9-release-notes
title: GroupDocs.Viewer for .NET 18.9 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.9.{{< /alert >}}

## Major Features

There are 12 features, improvements, and fixes in this regular monthly release. The most notable are:

*    Added following file formats support
    *   Computer Graphics Metafile (CGM)
    *   Microsoft Outlook Personal Storage Table (PST)
    *   Microsoft Outlook Offline Storage Table (OST)
*   Added support of rendering colored CAD drawings
*   Added support of rendering Microsoft Project documents as HTML with embedded resources

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1709 | Add CGM (Computer Graphics Metafile) file format support | New Feature |
| VIEWERNET-1676 | Add support for rendering PST file format | New Feature |
| VIEWERNET-1675 | Add support for rendering OST file format | New Feature |
| VIEWERNET-1674 | Obtaining start and end dates from MS Project document | New Feature |
| VIEWERNET-1729 | Extend support for HtmlOptions.ExcludeFonts setting when rendering MS Project documents as HTML | Improvement |
| VIEWERNET-1710 | Cleanup FileDescription and DocumentInfoContainer classes | Improvement |
| VIEWERNET-1706 | Include Photoshop file format (PSD) into the list of supported file formats | Improvement |
| VIEWERNET-1705 | Implement rendering color CAD drawings | Improvement |
| VIEWERNET-1673 | Improve output for printable HTML | Improvement |
| VIEWERNET-1200 | Extend support of HtmlOptions.IsResourceEmbedded option for Microsoft Project documents | Improvement |
| VIEWERNET-1715 | Exception: CAD document rendering failed | Bug |
| VIEWERNET-1640 | Issue when rendering email message having attachments with same name | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.9. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Obtaining start and end dates from MS Project document

MS Project documents can be of the various length. In some cases, it might be convenient to render Projects by dividing into parts with the equal period of time. Since the version 18.9 GroupDocs.Viewer API allows achieving that. First by obtaining the document overall length and then by splitting rendering with specified start and end date options.

#### How to get overall length of MS Project document

The overall length of MS Project document can be determined by the start and end date values returned from GetDocumentInfo of the ViewerHandler class as shown in the example below. 

**Obtaining the overall length of MS Project document**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
config.UseCache = true;
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "verylongdocument.mpp";
  
ProjectDocumentInfoContainer documentInfo = (ProjectDocumentInfoContainer) imageHandler.GetDocumentInfo(guid);
 
// Output document start and end dates
Console.WriteLine("Project start date: {0}", documentInfo.StartDate);
Console.WriteLine("Project end date: {0}", documentInfo.EndDate);
```

### List of Changes in v18.9

In the version 18.9, following public class members were added, marked as obsolete, removed or replaced.

#### GroupDocs.Viewer.Converter.Options.RenderOptions

##### Public OutlookOptions OutlookOptions property added

Use this property to set rendering options for Outlook Data File format (PST/OST) as shown in examples below:

**Rendering Outlook Data File documents with limit of items**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create HTML handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "sample.pst";
  
// Set Outlook options to render content with a specified limit.
HtmlOptions options = new HtmlOptions();
options.OutlookOptions.MaxItemsInFolder = 1000;
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
 Console.WriteLine("Page number: {0}", page.HtmlContent); 
```

**Get PDF representation of Outlook documents with specified limit of items**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "sample.pst";
  
// Set Project options to render content with a specified size and time unit.
PdfFileOptions options = new PdfFileOptions();
options.OutlookOptions.MaxItemsInFolder = 1000;
 
// Get PDF file 
FileContainer fileContainer = imageHandler.GetPdfFile(guid, options);
 
// Access PDF file stream.
Stream pdfFileStream = fileContainer.Stream;
```

#### GroupDocs.Viewer.Domain.CachedDocumentDescription

##### Public OutlookOptions OutlookOptions property added

This property is used for setting Outlook Data File document (PST/OST) rendering options.

#### GroupDocs.Viewer.Domain.CachedPageDescription

##### Public OutlookOptions OutlookOptions property added

This property is used for setting Outlook Data File document (PST/OST) rendering options.

#### GroupDocs.Viewer.Domain.Containers.DocumentInfoContainer

##### string FileFormat { get; } property added

Gets the file format e.g. "Microsoft Word".

##### string DocumentType { get; } property marked as obsolete

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

##### string FileType { get; } property marked as obsolete

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

##### string DocumentTypeFormat { get; } property marked as obsolete

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

#### GroupDocs.Viewer.Domain.Containers.ProjectDocumentInfoContainer

##### GroupDocs.Viewer.Domain.Containers.ProjectDocumentInfoContainer class has been added

This class represents a container for MS Project document description.

#### GroupDocs.Viewer.Domain.FileDescription

##### string FileFormat { get; } property added

Gets the file format e.g. "Microsoft Word".

##### string BaseName { get; } property marked as obsolete

This property is obsolete and will be removed after v18.11. To get base name use following code: System.IO.Path.GetFileNameWithoutExtension(fileDescription.Name).

##### string DocumentType { get; } property marked as obsolete

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

##### string FileType { get; } property marked as obsolete

This property is obsolete and will be removed after v18.11. Use FileFormat property instead.

#### GroupDocs.Viewer.Domain.Html.HtmlResource

##### Public OutlookOptions OutlookOptions property added

This property is used for setting Outlook Data File document (PST/OST) rendering options.

#### GroupDocs.Viewer.Domain.Options.DocumentInfoOptions

##### Public OutlookOptions OutlookOptions property added

This property is used for setting Outlook Data File document (PST/OST) rendering options.

#### GroupDocs.Viewer.Domain.Options.PdfFileOptions

##### Public OutlookOptions OutlookOptions property added

This property is used for setting Outlook Data File document (PST/OST) rendering options.

#### GroupDocs.Viewer.Domain.ProjectFileData

##### GroupDocs.Viewer.Domain.ProjectFileData class has been added

This class extends FileData class and contains properties specific to MS Project documents.
