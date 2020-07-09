---
id: groupdocs-viewer-for-net-17-5-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-17-5-0-release-notes
title: GroupDocs.Viewer for .NET 17.5.0 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 17.5.0.{{< /alert >}}

## Major Features

There are 2 new features and 20 improvements and fixes in this regular monthly release. The most notable are:

*   Added setting which allows showing comments when rendering Words (Text documents) and Cells (Spreadsheet documents)
*   JpegQuality setting allows adjusting quality and size when rendering as PDF
*   HtmlResourcePrefix setting accepts empty string to avoid setting default prefix for HTML resources (styles, fonts, and images)

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| WEB-2143 | Get print URl for document in JavaScript API | New Feature |
| VIEWERNET-1192 | Show comments when rendering Cells documents | New Feature |
| VIEWERNET-1184 | Show comments when rendering Words documents | New Feature |
| VIEWERNET-1194 | Create lower-case name when rendering document from stream | Improvement |
| VIEWERNET-1190 | Throw GroupDocsViewerException when file type can't be determined for passed stream | Improvement |
| VIEWERNET-1170 | Extend support for setting JpegQuality when rendering documents as pdf | Improvement |
| VIEWERNET-1164 | Improve look of comments in API reference documentation | Improvement |
| VIEWERNET-1163 | Do not set resource prefix when HtmlResourcePrefix is empty string | Improvement |
| VIEWERNET-1080 | Add code examples to EmailOptions class documentation comments | Improvement |
| VIEWERNET-1079 | Add code examples to DiagramOptions class documentation comments | Improvement |
| VIEWERNET-1076 | Remove obsolete CountPagesToConvert and PageNumbersToConvert RenderOptions properties | Improvement |
| WEB-1895 | Text selection flickers in converted HTML | Bug |
| VIEWERNET-1204 | Viewer creates temp folder when caching is disabled | Bug |
| VIEWERNET-1183 | Comments in Word document are not rendered in output HTML/image | Bug |
| VIEWERNET-1181 | File data file updated on each GetDocumentInfo call | Bug |
| VIEWERNET-1158 | Content of Excel document is jumbled up when rendering into HTML | Bug |
| VIEWERNET-1141 | Inline styles are used when styles are set to be saved separately | Bug |
| VIEWERNET-1026 | API is rendering PDF document into blank HTML pages | Bug |
| VIEWERNET-987 | Incomplete image when converting specific dwg | Bug |
| VIEWERNET-938 | Save method requires System.Web reference | Bug |
| VIEWERNET-760 | 3D effect of the text in a shape is lost while converting spreadsheet to HTML | Bug |
| VIEWERNET-756 | Incorrect Font Color in Rendering Excel to Html | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 17.5.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Show Comments when Rendering Cells and Words Documents

**Rendering Microsoft Word document with comments.**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.docx";
  
// Set words options to render content with comments
HtmlOptions options = new HtmlOptions();
options.RenderComments = true; // Default value is false
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

**Get PDF representation of Microsoft Word document with comments.**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.docx";
  
// Set pdf options to get pdf file with comments
PdfFileOptions options = new PdfFileOptions();
options.RenderComments = true; // Default value is false
 
// Get pdf document with comments
FileContainer fileContainer = imageHandler.GetPdfFile(guid, pdfFileOptions);
// Access result pdf document using fileContainer.Stream property
```

### Extend Support for Setting JpegQuality when Rendering Documents as PDF

**Set output quality when rendering documents into pdf**

When documents are rendered as pdf, sometimes we might be unhappy with a very big size of the resulting pdf, or we might intentionally want to reduce the quality of render result. For this purposes, you can use PdfFileOptions.JpegQuality property as shown in the example below. Valid values for this option are in the range between 1 and 100, where 100 stands for the best quality and biggest size and 1 stands for the lowest quality and lowest size of resulting pdf document. The default value is 90.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage\";
 
// Create image handler
 ViewerImageHandler handler = new ViewerImageHandler(config);
string guid = "document.djvu";
 
// Set pdf options JpegQuality in a range between 1 and 100
PdfFileOptions pdfFileOptions = new PdfFileOptions();
pdfFileOptions.JpegQuality = 5;
 
// Get file as pdf
using (FileContainer container = handler.GetPdfFile(guid, pdfFileOptions))
{
    Console.WriteLine("Stream lenght: {0}", container.Stream.Length);
}
```

##### List of formats affected by PdfFileOptions.JpegQuality property when rendered as PDF

| Format Name | Description |
| --- | --- |
| Microsoft Word | Affects JPEG images contained in Microsoft Word documents |
| Microsoft PowerPoint | Affects JPEG images contained in Microsoft PowerPoint documents |
| Microsoft Outlook | Affects JPEG images set as a background in email documents msg and eml formats |
| OpenDocument Formats | Affects JPEG images contained in OpenDocument presentation (odp) andOpenDocument text (odt) formats |
| Image files | Affects rendering from PSD, TIFF, multi-page TIFF, WebP and DjVu formats |
| Metafile | Affects rendering from WMF and EMF formats |
| Microsoft Visio | Affects JPEG images contained inside Microsoft Visio documents |

### Throw GroupDocsViewerException when File Type can't be Determined for Passed Stream

GroupDocs.Viewer will throw GroupDocsViewerException instead of EndOfStreamException when GroupDocs.Viewer can't determine file type.

### Create Lowercase Name when Rendering Document from Stream

GroupDocs.Viewer will create the lower-case name for the document. Name consists of 32 digits separated by hyphens: 00000000-0000-0000-0000-000000000000 (GUID) and extension e.g. 00000000-0000-0000-0000-000000000000.docx.

### List of changes in GroupDocs.Viewer for .NET 17.5.0

#### GroupDocs.Viewer.Converter.Options.FileDataOptions

##### Public bool UseCache property added

This property indicates whether the cache is used while obtaining file data.

#### GroupDocs.Viewer.Converter.Options.RenderOptions

##### Public int CountPagesToConvert property obsolete property has been removed

Please use CountPagesToRender property instead.

##### Public List<int> PageNumbersToConvert property obsolete property has been removed

Please use PageNumbersToRender property instead.

#### GroupDocs.Viewer.Domain.Containers.FileTreeContainer

##### Public GroupDocs.Viewer.Domain.Containers.FileTreeContainer obsolete class and class public members have been removed

Please use FileListContainer class instead.

#### GroupDocs.Viewer.Domain.Containers.RotatePageContainer

##### Public GroupDocs.Viewer.Domain.Containers.RotatePageContainer obsolete class and class public members removed

To get rotation angles use GetDocumentInfo method after calling RotatePage.

#### GroupDocs.Viewer.Domain.ContentControl

##### Public GroupDocs.Viewer.Domain.ContentControl obsolete class and class public members removed

This class has been completely deleted. There no alternative provided for this class.

#### GroupDocs.Viewer.Domain.EmailAttachment

##### Public GroupDocs.Viewer.Domain.EmailAttachment class and class members are set as obsolete

Please use GroupDocs.Viewer.Domain.Attachment class instead. This class is obsolete and will be removed in version 17.8.0.

#### GroupDocs.Viewer.Domain.EmailFileData

##### Public GroupDocs.Viewer.Domain.EmailFileData class and class members are set as obsolete

Please use FileData class instead. This class is obsolete and will be removed in version 17.8.0.

#### GroupDocs.Viewer.Domain.Options.FileTreeOptions

##### Public GroupDocs.Viewer.Domain.Options.FileTreeOptions obsolete class and class public members have been removed

Please use FileListOptions class instead.

#### GroupDocs.Viewer.Domain.Options.PrintableHtmlOptions

##### Public string Guid obsolete property removed

Please use GetPrintableHtml method of corresponding ViewerHandler class with guid parameter.

##### Constructors with guid parameter removed:

###### public PrintableHtmlOptions(string guid, string css, Watermark watermark)

###### public PrintableHtmlOptions(string guid, Watermark watermark)

###### public PrintableHtmlOptions(string guid, string css)

###### public PrintableHtmlOptions(string guid)

All constructors with guid parameter removed, use paramterless constructor instead and pass guid to GetPrintableHtml method of corresponding ViewerHandler.

#### GroupDocs.Viewer.Domain.Options.ReorderPageOptions

##### Public string Guid obsolete property removed

Please, pass guid parameter to ReorderPage method of corresponding ViewerHandler instead.

##### Obsolete constructors with guid parameter removed

###### public ReorderPageOptions(string guid, int pageNumber, int newPosition, string password)

###### public ReorderPageOptions(string guid, int pageNumber, int newPosition)

Two obsolete constructors with guid parameter removed, use the overloaded constructor without guid instead and pass guid parameter to ReorderPage method of corresponding ViewerHandler.

#### GroupDocs.Viewer.Domain.Options.RotatePageOptions

##### Public string Guid obsolete property removed

Please, pass guid parameter to RotatePage method of corresponding ViewerHandler instead.

##### Obsolete constructors with guid parameter removed:

###### public RotatePageOptions(string guid, int pageNumber, int rotationAngle, string password)

###### public RotatePageOptions(string guid, int pageNumber, int rotationAngle)

Two obsolete constructors with guid parameter removed, use overloaded constructor without guid instead and pass guid parameter to RotatePage method of corresponding ViewerHandler.

{{< alert style="info" >}}To get final rotation angle of the document, please use GetDocumentInfo method of corresponding ViewerHandler class.{{< /alert >}}

#### GroupDocs.Viewer.Domain.WordsFileData

##### Public GroupDocs.Viewer.Domain.WordsFileData obsolete class and class public members removed

This class has been completely removed. There is no substitution provided for this class.

#### GroupDocs.Viewer.Handler.Input.IInputDataHandler

##### Obsolete void SaveDocument(CachedDocumentDescription cachedDocumentDescription, Stream documentStream) method removed

Please implement AddFile(string guid, Stream content) method instead.

##### Obsolete List<FileDescription> LoadFileTree(FileTreeOptions fileTreeOptions) method removed

Please implement GetEntities(string path) method instead.

#### GroupDocs.Viewer.Handler.ViewerHandler

##### Public FileTreeContainer LoadFileTree () method is removed

Please use GetFileList() method instead.

##### Public FileTreeContainer LoadFileTree(FileTreeOptions fileTreeOptions) method is removed

Please use GetFileList(FileListOptions fileListOptions) method instead.

##### Public PrintableHtmlContainer GetPrintableHtml(PrintableHtmlOptions printableHtmlOptions) obsolete method removed

Please use GetPrintableHtml method of the ViewerHtmlHandler class with guid parameter.

##### Public RotatePageContainer RotatePage(RotatePageOptions rotatePageOptions) obsolete method removed

Please use RotatePage method with guid parameter instead.

##### Public void ReorderPage(ReorderPageOptions reorderPageOptions) obsolete method  removed

Please use ReorderPage method with guid parameter instead

#### GroupDocs.Viewer.Handler.ViewerHtmlHandler

##### Public PrintableHtmlContainer GetPrintableHtml(PrintableHtmlOptions printableHtmlOptions) removed

Please use GetPrintableHtml method of the ViewerHtmlHandler class with guid parameter.

#### GroupDocs.Viewer.Handler.ViewerImageHandler

##### Public PrintableHtmlContainer GetPrintableHtml(PrintableHtmlOptions printableHtmlOptions) method removed

Please use GetPrintableHtml method of the ViewerImageHandler class with guid parameter.

#### GroupDocs.Viewer.Helper.FileDataJsonSerializer

##### Public GroupDocs.Viewer.Helper.FileDataJsonSerializer obsolete class and class public members removed

This class has been completely removed. There is no alternative provided for this class.
