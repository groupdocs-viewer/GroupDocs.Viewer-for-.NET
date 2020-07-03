---
id: groupdocs-viewer-for-net-17-3-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-17-3-0-release-notes
title: GroupDocs.Viewer for .NET 17.3.0 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}} This page contains release notes for GroupDocs.Viewer for .NET 17.3.0.{{< /alert >}}

## Major Features

There are 7 new features and 6 improvements and fixes in this regular monthly release. The most notable are:

*   Metered Licensing support
*   Added support of VSTX and VSSX file formats
*   Added setting for adjusting the size when rendering CAD documents
*   Added setting to delete annotations when rendering PDF documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1110 | Add VSTX file format support | New Feature |
| VIEWERNET-1109 | Add VSSX file format support | New Feature |
| VIEWERNET-1106 | Implement settings for adjusting the size of CAD documents rendering | New Feature |
| VIEWERNET-1100 | Integrate Metered licensing | New Feature |
| VIEWERNET-1066 | Implement setting to delete annotations when rendering PDF documents | New Feature |
| VIEWERNET-797 | Hide tracked changes when converting Words documents | New Feature |
| VIEWERNET-796 | Remove slides comments when rendering Slides documents | New Feature |
| VIEWERNET-1084 | Remove members marked as obsolete in previous versions | Improvement |
| WEB-1152 | Color filling isn't displayed for some objects | Bug |
| VIEWERNET-1099 | IgnoreResourcePrefixForCss is ignored when rendering Words documents | Bug |
| VIEWERNET-1094 | Issue in HtmlResourcePrefix when Rendering .msg File | Bug |
| VIEWERNET-1025 | Character's size issue when rendering PDF document into HTML | Bug |
| VIEWERNET-793 | Email attachments are not found when setting UsePdf to true | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 17.3.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Support of VSTX and VSSX File Formats

GroupDocs.Viewer for .NET 17.3.0 supports VSTX and VSSX file formats.

### Settings for Adjusting the Size of CAD Documents Rendering

When Cad documents are rendered, the size of the render result is adjusted by API automatically depending on the size of initial document. You may adjust the size of resulting document by setting CadOptions property as show in example.

**Setting result image size when rendering Cad documents**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.dwg";
  
// Set Cad options to render content with a specified size
ImageOptions options = new ImageOptions();
options.CadOptions.Height = 750;
options.CadOptions.Width= 450;
 
// Get pages 
List<PageImage> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
     Console.WriteLine("Page number: {0}", page.PageNumber); 
     Stream imageContent = page.Stream;
}
```

{{< alert style="warning" >}}The following logic for sizing Cad document rendering is applied:If both CadOptions.Height and CadOptions.Width properties are set, the resulting image will have the same size in pixels.If only one of CadOptions.Height and CadOptions.Width is set, the value of another side will be calculated from ratio in the original document. If  CadOptions.Height is set as 600 and the ratio of the height to width in original cad document is 6 to 5, then the width of the resulting image will be 500 px.If none of CadOptions.Height and CadOptions.Width is set, or set as 0, the CadOptions.ScaleFactor will be used to form resulting image size. The data type of this property is float, values higher than 1 will enlarge resulting image and values between 0 and 1 will make image smaller. If the render result image size is equal to 200 px to 200 px, when CadOptions.ScaleFactor is equal to 1, then setting this value to 0.1 will provide image with 20 px to 20 px dimension.When CadOptions are not set size of resulting image is set by API.      The same logic is applied when rendering to HTML. When rendering to pdf, generally only height to width ratio matters.{{< /alert >}}

### Integrate Metered licensing

**Alternatively to set license from file, you may set Metered license.**



```csharp
// Create new instance of GroupDocs.Viewer.Metered class
GroupDocs.Viewer.Metered metered = new GroupDocs.Viewer.Metered();
 
// Set public and private keys
string publicKey = "***";
string privateKey = "***";
 
// Set public and private keys to metered instance
metered.SetMeteredKey(publicKey, privateKey);
 
// Get metered value before usage of the comparison
decimal amountBefore = GroupDocs.Viewer.Metered.GetConsumptionQuantity();
 
Console.WriteLine("Amount (MB) consumed before:" + amountBefore);
 
// Get pages
GroupDocs.Viewer.Handler.ViewerHtmlHandler htmlHandler = new GroupDocs.Viewer.Handler.ViewerHtmlHandler();
List<GroupDocs.Viewer.Domain.Html.PageHtml> pages = htmlHandler.GetPages("input.pdf");
 
// Get metered value after usage of the comparison
decimal amountAfter = GroupDocs.Viewer.Metered.GetConsumptionQuantity();
 
Console.WriteLine("Amount (MB) consumed after: " + amountAfter);
```

### Rendering pdf documents without Annotations

**How to render pdf documents and exclude annotations from rendering result**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "DocumentWithAnnotations.pdf";
  
// Set pdf options to render content without annotations
HtmlOptions options = new HtmlOptions();
options.PdfOptions.DeleteAnnotations = true; // Default value is false
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

  

**How to get original PDF document without annotations**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "DocumentWithAnnotations.pdf";
  
// Set pdf options to get original file without annotations
PdfFileOptions options = new PdfFileOptions();
options.PdfOptions.DeleteAnnotations = true; // Default value is false
 
// Get original pdf document without annotations
FileContainer fileContainer = imageHandler.GetPdfFile(guid, pdfFileOptions);
// Access result pdf document using fileContainer.Stream property
```

### Rendering Words Documents with Tracked Changes

**Rendering words documents with tracked changes**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.docx";
  
// Set pdf options to render content without annotations
HtmlOptions options = new HtmlOptions();
options.WordsOptions.ShowTrackedChanges = true; // Default value is false
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
```

**Get PDF representation of Words document with tracked changes**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "DocumentWithAnnotations.pdf";
  
// Set pdf options to get pdf file with tracked changes
PdfFileOptions options = new PdfFileOptions();
options.WordsOptions.ShowTrackedChanges = true; // Default value is false
 
// Get pdf document without tracked changes
FileContainer fileContainer = imageHandler.GetPdfFile(guid, pdfFileOptions);
// Access result pdf document using fileContainer.Stream property
```

### Removal of Members in GroupDocs.Viewer.Converter.Options.FileDataOptions

#### Public CellsDocumentInfoOptions CellsDocumentInfoOptions obsolete property compilation is set to fail

Using this member in not obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version. Please use CellsOptions property instead.

#### Public WordsDocumentInfoOptions WordsDocumentInfoOptions obsolete property compilation is set to fail 

Using this member in not obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version. Please use WordsOptions property instead. 

#### Public EmailDocumentInfoOptions EmailDocumentInfoOptions obsolete property compilation is set to fail

Using this member in not obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version. Please use EmailOptions property instead. 

### Removal of Members in GroupDocs.Viewer.Domain.CachedPageDescription

#### Public CachedPageDescription(string guid, CacheFileType cacheFileType) obsolete constructor compilation is set to fail

Using this constructor in not obsolete members will result in compilation error. Get ready for the change, this constructor will be completely deleted in the next version. Please use CachedPageDescription(string guid) or CachedPageDescription(string guid, string name) constructor instead.

### Removal of Members in GroupDocs.Viewer.Domain.Containers.DocumentInfoContainer

#### Public List<ContentControl> ContentControls obsolete property compilation is set to fail

Using this member in not obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version. 

### Removal of Members in GroupDocs.Viewer.Domain.ContentControl

#### Public GroupDocs.Viewer.Domain.ContentControl obsolete class and class public members compilation is set to fail

Using this class in non-obsolete members will result in compilation error. Get ready for the change, this class will be completely deleted in the next version.

### Removal of Members in GroupDocs.Viewer.Domain.Options.CellsDocumentInfoOptions

#### Public GroupDocs.Viewer.Domain.Options.CellsDocumentInfoOptions obsolete class and class public members compilation is set to fail

Using this class in not obsolete members will result in compilation error. Get ready for the change, this class will be completely deleted in the next version. Please use CellsOptions class instead.

### Removal of Members in GroupDocs.Viewer.Domain.Options.DocumentInfoOptions

#### Public string Guid obsolete property compilation is set to fail

Using this member in non-obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version. Please pass guid parameter separately to the method where you will pass DocumentInfoOptions as shown in example below.

#### Public DocumentInfoOptions(string guid) constructor compilation is set to fail

Using this constructor in non-obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version.Please use empty constructor  and pass guid parameter separately to the method where you will pass  DocumentInfoOptions as shown in example below.

#### Public DocumentInfoOptions(string guid, string password) constructor compilation is set to fail

Using this constructor in non-obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version.Please use constructors without guid parameter instead as shown in example below.

**How to get DocumentInfoContainer using DocumentInfoOptions**

**Before v3.3.0(C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

string guid = "word.doc";
// Get document information
DocumentInfoOptions options = new DocumentInfoOptions(guid);
DocumentInfoContainer documentInfo = htmlHandler.GetDocumentInfo(options);

Console.WriteLine("DateCreated: {0}", documentInfo.DateCreated);
Console.WriteLine("DocumentType: {0}", documentInfo.DocumentType);
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

**Since v3.3.0(C#)**

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

#### Public CellsDocumentInfoOptions CellsDocumentInfoOptions obsolete property compilation is set to fail

 Using this member in non-obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version.Please use CellsOptions instead as shown in example below.

#### Public WordsDocumentInfoOptions WordsDocumentInfoOptions obsolete property compilation is set to fail

 Using this member in non-obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version.Please use WordsOptions instead.

#### Public EmailDocumentInfoOptions EmailDocumentInfoOptions obsolete property compilation is set to fail

 Using this member in non-obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version.Please use EmailOptions instead.

**How to get document pages with Words, Cells and Email document encoding setting**

**Before v3.3.0 (C#)**

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
wordsDocumentInfoOptions.WordsDocumentInfoOptions.Encoding = encoding;
DocumentInfoContainer wordsDocumentInfoContainer = viewerImageHandler.GetDocumentInfo(wordsDocumentGuid, wordsDocumentInfoOptions);

//Get cells document info with encoding
DocumentInfoOptions cellsDocumentInfoOptions = new DocumentInfoOptions();
cellsDocumentInfoOptions.CellsDocumentInfoOptions.Encoding = encoding;
DocumentInfoContainer cellsDocumentInfoContainer = viewerImageHandler.GetDocumentInfo(cellsDocumentGuid, cellsDocumentInfoOptions);

//Get email document info with encoding
DocumentInfoOptions emailDocumentInfoOptions = new DocumentInfoOptions();
emailDocumentInfoOptions.EmailDocumentInfoOptions.Encoding = encoding;
DocumentInfoContainer emailDocumentInfoContainer = viewerImageHandler.GetDocumentInfo(emailDocumentGuid, emailDocumentInfoOptions);
```

**Since v3.3.0 (C#)**

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

### Removal of Members in GroupDocs.Viewer.Domain.Options.EmailDocumentInfoOptions

#### Public GroupDocs.Viewer.Domain.Options.EmailDocumentInfoOptions obsolete class and class public members compilation is set to fail

Using this class in not obsolete members will result in compilation error. Get ready for the change, this class will be completely deleted in the next version. Please use EmailOptions class instead.

### Removal of Members in GroupDocs.Viewer.Domain.Options.PdfFileOptions

#### Public string Guid obsolete property compilation is set to fail

Using this member in non-obsolete members will result in compilation error. Get ready for the change, this property will be completely deleted in the next version. Please pass guid parameter separately to the method where you will pass PdfFileOptions as shown in example below.

#### All obsolete public constructors with guid properties compilations are set to fail, including following:

#### public PdfFileOptions(string guid)

#### public PdfFileOptions(string guid, Transformation transformations)

#### public PdfFileOptions(string guid, Watermark watermark)

#### public PdfFileOptions(string guid, bool addPrintAction)

#### public PdfFileOptions(string guid, Transformation transformations, bool addPrintAction)

#### public PdfFileOptions(string guid, Transformation transformations, bool addPrintAction, Watermark watermark)

#### public PdfFileOptions(string guid, string password)

#### public PdfFileOptions(string guid, string password, Transformation transformations)

#### public PdfFileOptions(string guid, string password, Watermark watermark)

#### public PdfFileOptions(string guid, string password, bool addPrintAction)

#### public PdfFileOptions(string guid, string password, Transformation transformations, bool addPrintAction)

#### public PdfFileOptions(string guid, string password, Transformation transformations, bool addPrintAction, Watermark watermark)

Using this constructors in non obsolete memebers will result in compilation error. Get ready for the change, this constructors will be completely deleted in the next version. Please use parameterless constructor instead and set properties manually as shown in example below.

**Get original file in Pdf format with Watermark using PdfFileOptions**

Add watermark to Pdf document by setting **Watermark** property of **PdfFileOptions.**

**Before v3.5.0 (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);

PdfFileOptions options = new PdfFileOptions();
options.Guid = "word.doc";
 
// Set watermark properties
Watermark watermark = new Watermark("This is watermark text");
watermark.Color = System.Drawing.Color.Blue;
watermark.Position = WatermarkPosition.Diagonal;
watermark.Width = 100;
 
options.Watermark = watermark;
 
// Get file as pdf with watermaks
FileContainer container = imageHandler.GetPdfFile(options);
Console.WriteLine("Stream lenght: {0}", container.Stream.Length);

```

**v3.5.0 and higher (C#)**

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

### Removal of Members in GroupDocs.Viewer.Domain.Options.WordsDocumentInfoOptions

#### Public GroupDocs.Viewer.Domain.Options.WordsDocumentInfoOptions obsolete class and class public members compilation is set to fail

Using this class in not obsolete members will result in compilation error. Get ready for the change, this class will be completely deleted in the next version. Please use WordsOptions class instead.

### Removal of Members in GroupDocs.Viewer.Domain.WordsFileData

#### Public GroupDocs.Viewer.Domain.WordsFileData obsolete class and class public members compilation is set to fail

Using this class in non-obsolete members will result in compilation error. Get ready for the change, this class will be completely deleted in the next version.

### Removal of Members in GroupDocs.Viewer.Handler.ViewerHandler<T>

#### Public FileContainer GetPdfFile(PdfFileOptions pdfFileOptions) obsolete method compilation is set to fail

Using this method in non-obsolete members will result in compilation error. Get ready for the change, this method will be completely deleted in the next version. Please use overload with guid parameter instead as shown in example below.

**Get original file in Pdf format with Watermark**

Add watermark to Pdf document by setting **Watermark** property of **PdfFileOptions.**

**Before v3.5.0 (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);

PdfFileOptions options = new PdfFileOptions();
options.Guid = "word.doc";
 
// Set watermark properties
Watermark watermark = new Watermark("This is watermark text");
watermark.Color = System.Drawing.Color.Blue;
watermark.Position = WatermarkPosition.Diagonal;
watermark.Width = 100;
 
options.Watermark = watermark;
 
// Get file as pdf with watermaks
FileContainer container = imageHandler.GetPdfFile(options);
Console.WriteLine("Stream lenght: {0}", container.Stream.Length);

```

**v3.5.0 and higher (C#)**

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

#### Public DocumentInfoContainer GetDocumentInfo(DocumentInfoOptions documentInfoOptions) obsolete method compilation is set to fail

Using this method in non-obsolete members will result in compilation error. Get ready for the change, this method will be completely deleted in the next version. Please use overload with guid parameter instead as shown in example below.

**How to get DocumentInfoContainer using DocumentInfoOptions**

**Before v3.3.0(C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

string guid = "word.doc";
// Get document information
DocumentInfoOptions options = new DocumentInfoOptions(guid);
DocumentInfoContainer documentInfo = htmlHandler.GetDocumentInfo(options);

Console.WriteLine("DateCreated: {0}", documentInfo.DateCreated);
Console.WriteLine("DocumentType: {0}", documentInfo.DocumentType);
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

**Since v3.3.0(C#)**

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

### Removal of Members in GroupDocs.Viewer.Helper.FileDataJsonSerializer

#### Public GroupDocs.Viewer.Helper.FileDataJsonSerializer obsolete class and class public members compilation is set to fail

Using this class in non-obsolete members will result in compilation error. Get ready for the change, this class will be completely deleted in the next version.
