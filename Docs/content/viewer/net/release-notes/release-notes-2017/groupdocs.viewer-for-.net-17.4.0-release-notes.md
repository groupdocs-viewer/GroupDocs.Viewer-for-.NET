---
id: groupdocs-viewer-for-net-17-4-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-17-4-0-release-notes
title: GroupDocs.Viewer for .NET 17.4.0 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 17.4.0.{{< /alert >}}

## Major Features

There are 5 new features and 15 improvements and fixes in this regular monthly release. The most notable are:

*   Added ONE and DjVu file formats support
*   Added setting which allows specifying Layouts when rendering CAD documents
*   Added setting which allows specifying text overflow mode when rendering Cells documents
*   Implemented a setting that switches on more accurate rendering of PDF documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1166 | Implement a setting for specifying output quality for rendering DjVu documents | New Feature |
| VIEWERNET-1146 | Implement setting for specifying Layouts when rendering Cad documents | New Feature |
| VIEWERNET-1135 | Add setting which allows to specify text overflow mode when rendering Cells documents | New Feature |
| VIEWERNET-1111 | Add ONE file format support | New Feature |
| VIEWERNET-739 | DJVU format support | New Feature |
| VIEWERNET-1167 | CellsOptions.ShowGridLines property does not work when rendering Cells to PDF | Improvement |
| VIEWERNET-1161 | Implement a setting that switches on more accurate rendering of pdf documents | Improvement |
| VIEWERNET-1078 | Add code examples to CellsOptions class documentation comments | Improvement |
| VIEWERNET-1077 | Add code examples to PdfOptions class documentation comments | Improvement |
| WEB-1982 | Aspose.Pdf 10.7: incorrect rendering of hieroglyphs when converting PDF to JPEG and HTML | Bug |
| VIEWERNET-1162 | IgnoreResourcePrefixForCss is ignored when rendering PDF documents | Bug |
| VIEWERNET-1160 | Content is missing when rendering PDF document into HTML | Bug |
| VIEWERNET-1152 | Header of Word document is not rendered in output HTML or image | Bug |
| VIEWERNET-1133 | Overflow Text is Not Visible when Rendering Excel Sheet to HTML | Bug |
| VIEWERNET-1095 | Issue with Underline Text when Rendering PDF into HTML | Bug |
| VIEWERNET-1091 | Aspose.Slides 17.1.0: Black background when rendering pps or ppt to image | Bug |
| VIEWERNET-1047 | Issue in using the API with a Portable (PCL) Xamarin UWP Project | Bug |
| VIEWERNET-1038 | Incorrect resource relative path when rendering to Html | Bug |
| VIEWERNET-874 | HTMLSaveOptions.DefaultFont setting doesn't work properly | Bug |
| VIEWERNET-800 | Failed to convert djvu file to pdf in Asp.Net application. | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 17.4.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Support of ONE and DjVu File Formats

GroupDocs.Viewer for .NET 17.4.0 supports ONE and DjVu file formats.

### Setting Output Quality when Rendering DjVu into PDF

**How to adjust the quality and size when rendering DjVu into pdf**



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

### Rendering Layouts from CAD Documents

**Rendering Model and all non empty Layouts from CAD document**

When CAD documents are rendered, by default we get only Model representation. In order to render Model and all non-empty Layouts within CAD document, a new property CadOptions.RenderLayouts of an ImageOptions and HtmlOptions has been introduced in version 17.4.0.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.dwg";
  
// Set CAD options to render Model and all non empty Layouts
ImageOptions options = new ImageOptions();
options.CadOptions.RenderLayouts = true;
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
     Console.WriteLine("Page number: {0}", page.PageNumber); 
     Stream imageContent = page.Stream;
}
```

**Rendering specific Layout from Cad document**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.dwg";
  
// Set CAD options to render specific Layout
ImageOptions options = new ImageOptions();
options.CadOptions.LayoutName = "MyFirstLayout";
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
Console.WriteLine("Page number: {0}", pages[0].PageNumber); 
Stream imageContent = pages[0].Stream; 
```

**Getting the list of Layouts from CAD document**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.dwg";
  
// Set CAD options to get the full list of Layouts
DocumentInfoOptions documentInfoOptions = new DocumentInfoOptions();
documentInfoOptions.CadOptions.RenderLayouts = true;
 
// Get DocumentInfoContainer and iterate through pages 
DocumentInfoContainer documentInfoContainer = imageHandler.GetDocumentInfo(guid, documentInfoOptions);
foreach (PageData page in pages)
{
     Console.WriteLine("Page number: {0} - {1}", page.Number, page.Name);     
}
```

### Managing Text Overflow when Rendering Cells Documents to HTML

1.  To set the overflowed text to be hidden, set CellsOptions.TextOverflowMode of HtmlOption to TextOverflowMode.HideText as shown in the example below.
2.  To set the overflowed text to overlay subsequent cells untill it meets non empty cell, set CellsOptions.TextOverflowMode of HtmlOption to TextOverflowMode.OverlayIfNextIsEmpty. This is a default value of the CellsOptions.TextOverflowMode.
3.  To set the overflowed text to overlay subsequent cells even they are not empty, set CellsOptions.TextOverflowMode of HtmlOption to TextOverflowMode.Overlay.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.xlsx";
  
// Set Cells options to hide overflowing text
HtmlOptions options = new HtmlOptions();
options.CellsOptions.TextOverflowMode = TextOverflowMode.HideText;
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

### Enabling Precise Mode when Rendering PDF Documents

When pdf documents are rendered, we get similar representation in image and HTML formats, but sometimes result of rendering may contain shifted characters, symbols or document objects.To improve render result in such cases please use PdfOptions.EnablePreciseRendering as shown in the example below. This option includes technics for more accurate representation of documents both into HTML and image formats.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.pdf";
  
// Set pdf options to render content in a precise mode
HtmlOptions options = new HtmlOptions();
options.PdfOptions.EnablePreciseRendering = true; // Default value is false
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

### GroupDocs.Viewer.Converter.Options.FileDataOptions

#### Public CellsDocumentInfoOptions CellsDocumentInfoOptions obsolete property has been removed

Please use CellsOptions property instead.

#### Public WordsDocumentInfoOptions WordsDocumentInfoOptions obsolete property has been removed

Please use WordsOptions property instead. 

#### Public EmailDocumentInfoOptions EmailDocumentInfoOptions obsolete property has been removed

Please use EmailOptions property instead. 

### GroupDocs.Viewer.Converter.Options.PdfOptions

#### Public bool PreventGlyphsGrouping property has been set as obsolete

Please use EnablePreciseRendering property instead.

#### Public bool EnablePreciseRendering property added

Use this property to improve rendering pdf documents into HTML and image.

### GroupDocs.Viewer.Converter.Options.RenderOptions

#### Public int CountPagesToConvert property obsolete property compilation is set to fail

This property compilation is set to fail and will be removed in the version 17.5.0. As ImageOptions and HtmlOptions classes are inheriting from RenderOptions, this affects two classes as well. Please use CountPagesToRender property instead.

#### Public int JpegQuality property moved from child ImageOptions into base RenderOptions class

Since the version 17.4.0, all implementations of abstract RenderOptions class inherit this property.

### GroupDocs.Viewer.Domain.CachedPageDescription

#### Public CachedPageDescription(string guid, CacheFileType cacheFileType) obsolete constructor has been removed

Please use CachedPageDescription(string guid) or CachedPageDescription(string guid, string name) constructor instead.

### GroupDocs.Viewer.Domain.Containers.DocumentInfoContainer

#### Public List<ContentControl> ContentControls obsolete property has been removed

There is no replacement for this property.

### GroupDocs.Viewer.Domain.Containers.FileTreeContainer

#### Public GroupDocs.Viewer.Domain.Containers.FileTreeContainer obsolete class and class public members compilation is set to fail

Using this class in non-obsolete members will result in compilation error. Get ready for the change, this class will be completely deleted in the next version. Please use FileListContainer class instead, as shown in the example:



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
  
// Load file list sorted by Name and ordered Ascending for custom path 
FileListOptions options = new FileListOptions(@"D:\", FileListOptions.FileListSortBy.Name, FileListOptions.FileListOrderBy.Ascending);
FileListContainer container = imageHandler.GetFileList(options);
foreach (var node in container.Files)
{
    if (node.IsDirectory)
    {
        Console.WriteLine("Guid: {0} | Name: {1} | LastModificationDate: {2}",
            node.Guid,
            node.Name,
            node.LastModificationDate);
    }
    else
        Console.WriteLine("Guid: {0} | Name: {1} | Document type: {2} | File type: {3} | Extension: {4} | Size: {5} | LastModificationDate: {6}",
            node.Guid,
            node.Name,
            node.DocumentType,
            node.FileType,
            node.Extension,
            node.Size,
            node.LastModificationDate);
}
```

### GroupDocs.Viewer.Domain.Containers.RotatePageContainer

#### Public GroupDocs.Viewer.Domain.Containers.RotatePageContainer obsolete class and class public members compilation is set to fail

Using this class in non-obsolete members will result in compilation error. Get ready for the change, this class will be completely deleted in the next version. To get rotation angles use GetDocumentInfo method after calling RotatePage, as shown in the example:



```csharp
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler();
string guid = "word.doc";
   
// Set rotation angle 90 for page number 1
RotatePageOptions rotateOptions = new RotatePageOptions(1, 90);
   
// Perform page rotation
imageHandler.RotatePage(guid, rotateOptions);
 
// Get rotation angle of the first page
int angle = imageHandler.GetDocumentInfo(guid).Pages[0].Angle
```

### GroupDocs.Viewer.Domain.Options.CellsDocumentInfoOptions

#### Public GroupDocs.Viewer.Domain.Options.CellsDocumentInfoOptions obsolete class and class public members have been removed

Please use CellsOptions class instead.

### GroupDocs.Viewer.Domain.Options.DocumentInfoOptions

#### Public DocumentInfoOptions(string password) constructor has been added

Use this constructors as a replacement for constructor with guid parameter.

#### Public string Guid obsolete property has been removed

Please pass guid parameter separately as shown in the example below.

#### Public DocumentInfoOptions(string guid) constructor has been removed

Please use the empty constructor and pass guid parameter separately as shown in the example below.

#### Public DocumentInfoOptions(string guid, string password) constructor has been removed

Please use constructors without guid parameter instead as shown in the example below.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
 
string guid = "word.doc";
// Get document information
DocumentInfoOptions options = new DocumentInfoOptions();
DocumentInfoContainer documentInfo = htmlHandler.GetDocumentInfo(guid, options);
 
Console.WriteLine("DateCreated: {0}", documentInfo.DateCreated);
Console.WriteLine("DocumentType: {0}", documentInfo.DocumentType);
Console.WriteLine("DocumentTypeFormat: {0}", documentInfo.DocumentTypeFormat);
Console.WriteLine("Extension: {0}", documentInfo.Extension);
Console.WriteLine("FileType: {0}", documentInfo.FileType);
Console.WriteLine("Guid: {0}", documentInfo.Guid);
Console.WriteLine("LastModificationDate: {0}", documentInfo.LastModificationDate);
Console.WriteLine("Name: {0}", documentInfo.Name);
Console.WriteLine("PageCount: {0}", documentInfo.Pages.Count);
Console.WriteLine("Size: {0}", documentInfo.Size);
 
foreach (PageData pageData in documentInfo.Pages)
{
    Console.WriteLine("Page number: {0}", pageData.Number);
    Console.WriteLine("Page name: {0}", pageData.Name);
}
```

#### Public CellsDocumentInfoOptions CellsDocumentInfoOptions obsolete property has been removed

 Please use CellsOptions instead as shown in example below.

#### Public WordsDocumentInfoOptions WordsDocumentInfoOptions obsolete property has been removed

 Please use WordsOptions instead as shown in the example below.

#### Public EmailDocumentInfoOptions EmailDocumentInfoOptions obsolete property has been removed

 Please use EmailOptions instead as shown in the example below.



```csharp
//Initialize viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
 
//Initialize viewer handler
ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig);
 
//Set encoding
Encoding encoding = Encoding.GetEncoding("shift-jis");
 
//Get words document info with encoding
DocumentInfoOptions wordsDocumentInfoOptions = new DocumentInfoOptions();
wordsDocumentInfoOptions.WordsOptions.Encoding = encoding;
DocumentInfoContainer wordsDocumentInfoContainer = viewerImageHandler.GetDocumentInfo(wordsDocumentGuid, wordsDocumentInfoOptions);
 
//Get cells document info with encoding
DocumentInfoOptions cellsDocumentInfoOptions = new DocumentInfoOptions();
cellsDocumentInfoOptions.CellsOptions.Encoding = encoding;
DocumentInfoContainer cellsDocumentInfoContainer = viewerImageHandler.GetDocumentInfo(cellsDocumentGuid, cellsDocumentInfoOptions);
 
//Get email document info with encoding
DocumentInfoOptions emailDocumentInfoOptions = new DocumentInfoOptions();
emailDocumentInfoOptions.EmailOptions.Encoding = encoding;
DocumentInfoContainer emailDocumentInfoContainer = viewerImageHandler.GetDocumentInfo(emailDocumentGuid, emailDocumentInfoOptions);
```

### GroupDocs.Viewer.Domain.Options.EmailDocumentInfoOptions

#### Public GroupDocs.Viewer.Domain.Options.EmailDocumentInfoOptions obsolete class and class public memebers have been removed

Please use EmailOptions class instead.

### GroupDocs.Viewer.Domain.Options.PdfFileOptions

#### Public int JpegQuality property added

This property is intended for adjusting the size of resulting pdf document. In a current version 17.4.0 it only affects rendering from DjVu, but in future releases, we are planning support for other document types as well.

#### As a replacement for constructors with guid parameter, new constructors without guid parameter have been added, including following:

public PdfFileOptions(Transformation transformations) constructor added

public PdfFileOptions(Watermark watermark) constructor added

public PdfFileOptions(Transformation transformations, Watermark watermark) constructor added

public PdfFileOptions(string password) constructor added

public PdfFileOptions(string password, Transformation transformations) constructor added

public PdfFileOptions(string password, Watermark watermark) constructor added

public PdfFileOptions(string password, Transformation transformations, Watermark watermark) constructor added

#### Public string Guid obsolete property has been removed

Please pass guid parameter separately.

#### All obsolete public constructors with guid properties have been removed, including following:

public PdfFileOptions(string guid)

public PdfFileOptions(string guid, Transformation transformations)

public PdfFileOptions(string guid, Watermark watermark)

public PdfFileOptions(string guid, bool addPrintAction)

public PdfFileOptions(string guid, Transformation transformations, bool addPrintAction)

public PdfFileOptions(string guid, Transformation transformations, bool addPrintAction, Watermark watermark)

public PdfFileOptions(string guid, string password)

public PdfFileOptions(string guid, string password, Transformation transformations)

public PdfFileOptions(string guid, string password, Watermark watermark)

public PdfFileOptions(string guid, string password, bool addPrintAction)

public PdfFileOptions(string guid, string password, Transformation transformations, bool addPrintAction)

public PdfFileOptions(string guid, string password, Transformation transformations, bool addPrintAction, Watermark watermark)

Please use parameterless constructor or newly added constructors without guid parameter instead as shown in example below.

**Get original file in Pdf format with Watermark using PdfFileOptions**

Add watermark to Pdf document by setting **Watermark** property of **PdfFileOptions.**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
 
string guid = "word.doc";
 
// Set watermark properties
Watermark watermark = new Watermark("This is watermark text");
watermark.Color = System.Drawing.Color.Blue;
watermark.Position = WatermarkPosition.Diagonal;
watermark.Width = 100;
 
PdfFileOptions options = new PdfFileOptions();
options.Watermark = watermark;
  
// Get file as pdf with watermaks
FileContainer container = imageHandler.GetPdfFile(guid, options);
Console.WriteLine("Stream lenght: {0}", container.Stream.Length);
```

### GroupDocs.Viewer.Domain.Options.PrintableHtmlOptions

#### Public string Guid obsolete property compilation is set to fail

This property's compilation is set to fail and will be removed in the version 17.5.0, please use GetPrintableHtml method of corresponding ViewerHandler class with guid parameter.

**Using GetPrintableHtml method of the ViewerHandler class with guid parameter instead of Guid property**



```csharp
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler();
string guid = "word.doc";
  
// Get document html for print
var container = imageHandler.GetPrintableHtml(guid);
   
Console.WriteLine("Html content: {0}", container.HtmlContent);
```

#### Constructors with guid parameter compilation is set to fail:

##### public PrintableHtmlOptions(string guid, string css, Watermark watermark)

##### public PrintableHtmlOptions(string guid, Watermark watermark)

##### public PrintableHtmlOptions(string guid, string css)

##### public PrintableHtmlOptions(string guid)

The compilation of all constructors with guid parameter is set to fail, they will be removed in version 17.5.0, use parameterless constructor instead and pass guid to GetPrintableHtml method of corresponding ViewerHandler as shown in the example below.

**Using parameterless constructor instead of constructors with guid parameter**



```csharp
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler();
string guid = "word.doc";
  
// Setup watermark and style
Watermark watermark = new Watermark("Watermark text");
string css = "a { color: hotpink; }"; 
  
// Setup printable options
var options = new PrintableHtmlOptions();
options.Watermark = watermark;
options.Css = css;
  
// Get document html for print with custom css and watermark
var container = imageHandler.GetPrintableHtml(guid, options);
   
Console.WriteLine("Html content: {0}", container.HtmlContent);
```

### GroupDocs.Viewer.Domain.Options.ReorderPageOptions

#### Public string Guid obsolete property compilation is set to fail  

This property's compilation is set to fail and will be removed in the version 17.5.0, please, pass guid parameter to ReorderPage method of corresponding ViewerHandler instead as shown the example below.

#### Obsolete constructors with guid parameter compilations is set to fail:

##### public ReorderPageOptions(string guid, int pageNumber, int newPosition, string password)

##### public ReorderPageOptions(string guid, int pageNumber, int newPosition)

The compilation of two obsolete constructors with guid parameter is set to fail, they will be removed in version 17.5.0, use the overloaded constructor without guid instead and pass guid parameter to ReorderPage method of corresponding ViewerHandler as shown in the example below.

**Using constructors without guid instead of constructors with guid parameter.**



```csharp
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler();
string guid = "word.doc";
int pageNumber = 1;
int newPosition = 2;
   
// Perform page reorder
ReorderPageOptions options = new ReorderPageOptions(pageNumber, newPosition);
imageHandler.ReorderPage(guid, options);
```

### GroupDocs.Viewer.Domain.Options.RotatePageOptions

#### Public string Guid obsolete property compilation is set to fail

This property compilation is set to fail and it will be removed in the version 17.5.0, please, pass guid parameter to RotatePage method of corresponding ViewerHandler instead as shown in the example below.

#### Obsolete constructors with guid parameter compilation is set to fail:

##### public RotatePageOptions(string guid, int pageNumber, int rotationAngle, string password)

##### public RotatePageOptions(string guid, int pageNumber, int rotationAngle)

The compilation of two obsolete constructors with guid parameter is set to fail, they will be removed in version 17.5.0, use the overloaded constructor without guid instead and pass guid parameter to RotatePage method of corresponding ViewerHandler as shown in the example below.

**Using constructors without guid instead of constructors with guid parameter.**



```csharp
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler();
string guid = "word.doc";
   
// Set rotation angle 90 for page number 1
RotatePageOptions rotateOptions = new RotatePageOptions(1, 90);
   
// Perform page rotation
imageHandler.RotatePage(guid, rotateOptions);
```

{{< alert style="info" >}}To get final rotation angle of the document, please use GetDocumentInfo method of corresponding ViewerHandler class{{< /alert >}}

### GroupDocs.Viewer.Domain.Options.WordsDocumentInfoOptions

#### Public GroupDocs.Viewer.Domain.Options.WordsDocumentInfoOptions obsolete class and class public memebers have been removed

Please use WordsOptions class instead.

### GroupDocs.Viewer.Handler.Input.IInputDataHandler

#### Obsolete void SaveDocument(CachedDocumentDescription cachedDocumentDescription, Stream documentStream) method copilation is set to fail

If you have created your own implementation of  IInputDataHandler, please use AddFile(string guid, Stream content) method instead.

**Difference in implementation of IInputDataHandler obsolete SaveDocument and replacing AddFile methods for Azure input data handler.**

**Obsolete SaveDocument method (C#)**

```csharp
/// <summary>
/// Save document stream
/// </summary>
/// <param name="cachedDocumentDescription">Cached document description</param>
/// <param name="documentStream">Document stream</param>
public void SaveDocument(CachedDocumentDescription cachedDocumentDescription, Stream documentStream)
{
    try
    {
        string blobName = GetNormalizedBlobName(cachedDocumentDescription.Guid);
        ICloudBlob blob = _container.GetBlockBlobReference(blobName);
        blob.UploadFromStream(documentStream);
    }
    catch (StorageException ex)
    {
        throw new System.Exception("Unabled to add file.", ex);
    }
}
```

**Replacing AddFile method (C#)**

```csharp
/// <summary>
/// Adds file to storage.
/// </summary>
/// <param name="guid">This is user defined key that identifies file in the storage.</param>
/// <param name="content">Stream to save data to storage.</param>
public void AddFile(string guid, Stream content)
{
    try
    {
        string blobName = GetNormalizedBlobName(guid);
        ICloudBlob blob = _container.GetBlockBlobReference(blobName);
        blob.UploadFromStream(content);
    }
    catch (StorageException ex)
    {
        throw new System.Exception("Unabled to add file.", ex);
    }
}
```

### GroupDocs.Viewer.Handler.ViewerHandler

#### Public FileContainer GetPdfFile(PdfFileOptions pdfFileOptions) obsolete method has been removed

Please use overload with guid parameter instead.

#### Public DocumentInfoContainer GetDocumentInfo(DocumentInfoOptions documentInfoOptions) obsolete method has been removed

Please use overload with guid parameter instead.

#### Public PrintableHtmlContainer GetPrintableHtml(PrintableHtmlOptions printableHtmlOptions) obsolete method compilation is set to fail

Compilation for this method is set to fail and it will be removed in the version 17.5.0, please use GetPrintableHtml method of the ViewerHtmlHandler class with guid parameter.

#### Public RotatePageContainer RotatePage(RotatePageOptions rotatePageOptions) obsolete method compilation is set to fail

Compilation of this method is set to fail, it will be removed in the version 17.5.0, please use RotatePage method with guid parameter instead.

#### Public void ReorderPage(ReorderPageOptions reorderPageOptions) obsolete method  compilation is set to fail

Compilation of this method is set to fail, it will be removed in the version 17.5.0, please use ReorderPage method with guid parameter instead.
