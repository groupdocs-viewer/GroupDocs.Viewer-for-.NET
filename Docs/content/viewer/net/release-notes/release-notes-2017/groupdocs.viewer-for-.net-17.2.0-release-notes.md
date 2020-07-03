---
id: groupdocs-viewer-for-net-17-2-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-17-2-0-release-notes
title: GroupDocs.Viewer for .NET 17.2.0 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 17.2.0.{{< /alert >}}

## Major Features

There are 2 new features and 11 improvements and fixes in this regular monthly release. The most notable are:

*   Rendering password-protected MPP(2003) files
*   LaTeX file format support
*   Add {resource-name} pattern to HtmlOptions.HtmlResourcePrefix
*   Implement setting which allows to render pdf document layers separately

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1022 | Rendering password-protected MPP(2003) files | New Feature |
| VIEWERNET-785 | LaTeX file format support | New Feature |
| VIEWERNET-1075 | Implement saving fonts and styles separately when converting Words to Html | Improvement |
| VIEWERNET-1071 | Add {resource-name} pattern to HtmlOptions.HtmlResourcePrefix | Improvement |
| VIEWERNET-1061 | Add CountPagesToRender and PageNumbersToRender properties to RenderOptions class | Improvement |
| VIEWERNET-1060 | Implement IDisposable for container classes | Improvement |
| VIEWERNET-1055 | Implement setting which allows render pdf document layers separately | Improvement |
| VIEWERNET-1021 | Add code examples to documentation comments | Improvement |
| WEB-2377 | Incorrect conversion from DOCX to PDF | Bug |
| WEB-756 | Header-links in PDF files do not work | Bug |
| VIEWERNET-1035 | Input stream must be FileStream exception when loading Tex file from stream | Bug |
| VIEWERNET-688 | Getting GroupDocs.Foundation Dependency Exception in SharePoint 2013 | Bug |
| VIEWERNET-505 | Background image is missing when converting to image. | Bug |

   
 

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 17.2.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### LaTeX file format support

LaTeX file format is supported starting from version 17.2.0.

### Addition of {resource-name} pattern in HtmlOptions.HtmlResourcePrefix

**HtmlResourcePrefix setting supports replacement patterns: {page-number} and {resource-name}.**



```csharp
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.IsResourcesEmbedded = false;
htmlOptions.HtmlResourcePrefix = "http://example.com/api/pages/{page-number}/resources/{resource-name}";
//The {page-number} and {resource-name} patterns will be replaced with current processing page number and resource name accordingly.

```

### Addition of CountPagesToRender and PageNumbersToRender properties to RenderOptions class

**Public int CountPagesToRender property is added.**

Please use this property as a replacement for CountPagesToConvert as shown in example.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "word.doc";

// Options to render 5 consecutive pages starting from page number 2
ImageOptions options = new ImageOptions();
options.PageNumber = 2;
options.CountPagesToRender = 5;

List<PageImage> pages = imageHandler.GetPages(guid, options);

foreach (PageImage page in pages)
{
     Console.WriteLine("Page number: {0}", page.PageNumber);

     // Page image stream
     Stream imageContent = page.Stream;
}

```

**Public List<int> PageNumbersToRender property is added.**

Please use this property as a replacement for PageNumbersToConvert as shown in example.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "word.doc";

// Options to render 1, 3, 5, 6, 8 page numbers
HtmlOptions options = new HtmlOptions();
options.PageNumbersToRender = new List<int>() { 1, 3, 5, 6, 8 };

List<PageHtml> pages = htmlHandler.GetPages(guid, options);

foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}

```

### Implementation of settings which allows rendering of pdf document's layers separately

When rendering layered Pdf documents into HTML, since the version 17.2.0 by default all layers are rendered as one, and you are unable to distinguish between them. If you want pdf layers to be separated into different HTML elements, so that you can manipulate them using Javascript or Javascript libraries, set PdfOptions.RenderLayersSeparately property of HtmlOptions object to true as shown in below example. 



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "layered_document.pdf";

// Set pdf options to render pdf layers into separate html elements
HtmlOptions options = new HtmlOptions();
options.PdfOptions.RenderLayersSeparately = true; // Default value is false

// Get pages
List<PageHtml> pages = htmlHandler.GetPages(guid, options);

foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}

```

### List of changes in GroupDocs.Viewer for .NET 17.2.0

#### Changes in GroupDocs.Viewer.Config.ViewerConfig class

##### Public string TempFolderName property removed

**This property was removed, use CacheFolderName instead.**



```csharp
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
config.CacheFolderName = "cachefolder";

```

#### Changes in GroupDocs.Viewer.Converter.Options.RenderOptions class

##### Public int CountPagesToConvert property is set as obsolete

This property is set as obsolete and will be removed in the version 17.5.0. As ImageOptions and HtmlOptions classes are inheriting from RenderOptions, this affects two classes as well. Please use CountPagesToRender property instead.

##### Public List<int> PageNumbersToConvert property is set as obsolete

This property is set as obsolete and will be removed in the version 17.5.0. As ImageOptions and HtmlOptions classes are inheriting from RenderOptions, this affects this two classes as well. Please use PageNumbersToRender property instead.

##### Public string GUID property is set as obsolete

This property is set as obsolete and will be removed in the version 17.5.0, please use GetPrintableHtml method of corresponding ViewerHandler class with guid parameter.



```csharp
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler();
string guid = "word.doc";

// Get document html for print
var container = imageHandler.GetPrintableHtml(guid);

Console.WriteLine("Html content: {0}", container.HtmlContent);

```

#### Changes in GroupDocs.Viewer.Domain.Options.PrintableHtmlOptions class

##### Constructors with guid parameter are set as obsolete

**public PrintableHtmlOptions(string guid, string css, Watermark watermark)**  
**public PrintableHtmlOptions(string guid, Watermark watermark)**  
**public PrintableHtmlOptions(string guid, string css)**  
**public PrintableHtmlOptions(string guid)**

All constructors with guid parameter became obsolete and will be removed in version 17.5.0, use parameterless constructor instead and pass guid to GetPrintableHtml method of corresponding ViewerHandler as shown in example below.

**Public PrintableHtmlOptions() parameterless constructor added**  
Use parameterless constructor instead of constructors with guid parameter.



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

#### Changes in GroupDocs.Viewer.Domain.Options.ReorderPageOptions class

##### Public string Guid property set as obsolete

This property was set as obsolete and will be removed in the version 17.5.0, please, pass guid parameter to ReorderPage method of corresponding ViewerHandler instead as shown in example below.

**Constructors with guid parameter became obsolete:**  
public ReorderPageOptions(string guid, int pageNumber, int newPosition, string password)  
public ReorderPageOptions(string guid, int pageNumber, int newPosition)

Two constructors with guid parameter became obsolete and will be removed in version 17.5.0, use overloaded constructor without guid instead and pass guid parameter to ReorderPage method of corresponding ViewerHandler as shown in example below.

**Two new public constructors without guid parameter are added:**  
public ReorderPageOptions(int pageNumber, int newPosition, string password)  
public ReorderPageOptions(int pageNumber, int newPosition)

Use constructors without guid instead of constructors with guid parameter.



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

#### Changes in GroupDocs.Viewer.Domain.Options.RotatePageOptions class

##### Public string Guid property set as obsolete

This property was set as obsolete and will be removed in the version 17.5.0, please, pass guid parameter to RotatePage method of corresponding ViewerHandler instead as shown in example below.

**Constructors with guid parameter became obsolete:**  
public RotatePageOptions(string guid, int pageNumber, int rotationAngle, string password)  
public RotatePageOptions(string guid, int pageNumber, int rotationAngle)

Two constructors with guid parameter became obsolete and will be removed in version 17.5.0, use overloaded constructor without guid instead and pass guid parameter to RotatePage method of corresponding ViewerHandler as shown in example below.

**Two new public constructors without guid parameter are added:**  
public RotatePageOptions(int pageNumber, int rotationAngle, string password)  
public RotatePageOptions(int pageNumber, int rotationAngle)

Use constructors without guid instead of constructors with guid parameter.



```csharp
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler();
string guid = "word.doc";

// Set rotation angle 90 for page number 1
RotatePageOptions rotateOptions = new RotatePageOptions(1, 90);

// Perform page rotation
imageHandler.RotatePage(guid, rotateOptions);

```

{{< alert style="info" >}}To get final rotation angle of the document, please use GetDocumentInfo method of corresponding ViewerHandler class.{{< /alert >}}

#### Changes in GroupDocs.Viewer.Handler.Input.IInputDataHandler interface

##### void SaveDocument(CachedDocumentDescription cachedDocumentDescription, Stream documentStream) method removed

If you have created your own implementation of IInputDataHandler, please use AddFile(string guid, Stream content) method instead.

**Difference in the implementation of IInputDataHandler obsolete SaveDocument and replacing AddFile methods for Azure input data handler.**

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

##### List<FileDescription> LoadFileTree(FileTreeOptions fileTreeOptions) method removed

If you have created your own implementation of IInputDataHandler, please use GetEntities(string path) method instead.

**Difference in implementation of IInputDataHandler obsolete LoadFileTree and replacing GetEntities methods for Azure input data handler.**

**Obsolete LoadFileTree method (C#)**

```csharp
/// <summary>
/// Loads files/folders structure for specified path
/// </summary>
/// <param name="fileTreeOptions">The file tree options.</param>
/// <returns>System.Collections.Generic.List&lt;GroupDocs.Viewer.Domain.FileDescription&gt;.</returns>
public List<FileDescription> LoadFileTree(FileTreeOptions fileTreeOptions)
{
    try
    {
        string path = GetNormalizedBlobName(fileTreeOptions.Path);
        List<FileDescription> fileTree = GetFilesAndDirectories(path);
        switch (fileTreeOptions.OrderBy)
        {
            case FileTreeOptions.FileTreeOrderBy.Name:
                fileTree = fileTreeOptions.OrderAsc
                    ? fileTree.OrderBy(_ => _.Name).ToList()
                    : fileTree.OrderByDescending(_ => _.Name).ToList();
                break;
            case FileTreeOptions.FileTreeOrderBy.LastModificationDate:
                fileTree = fileTreeOptions.OrderAsc
                    ? fileTree.OrderBy(_ => _.LastModificationDate).ToList()
                    : fileTree.OrderByDescending(_ => _.LastModificationDate).ToList();
                break;
            case FileTreeOptions.FileTreeOrderBy.Size:
                fileTree = fileTreeOptions.OrderAsc
                    ? fileTree.OrderBy(_ => _.Size).ToList()
                    : fileTree.OrderByDescending(_ => _.Size).ToList();
                break;
            default:
                break;
        }
        return fileTree;
    }
    catch (StorageException ex)
    {
        throw new System.Exception("Failed to load file tree.", ex);
    }
}

```

**Replacing GetEntities method (C#)**

```csharp
/// <summary>
/// Gets files and folders for specified path.
/// </summary>
/// <param name="path">The path.</param>
/// <returns>System.Collections.Generic.List&lt;GroupDocs.Viewer.Domain.FileDescription&gt;.</returns>
public List<FileDescription> GetEntities(string path)
{
    try
    {
        string normalizedPath = GetNormalizedBlobName(path);
        return GetFilesAndDirectories(normalizedPath);
    }
    catch (StorageException ex)
    {
        throw new System.Exception("Failed to load file tree.", ex);
    }
}

```

#### Changes in GroupDocs.Viewer.Handler.ViewerHtmlHandler

##### Public PrintableHtmlContainer GetPrintableHtml(PrintableHtmlOptions printableHtmlOptions) is set as obsolete

This method is set as obsolete and will be removed in the version 17.5.0, please use GetPrintableHtml method of the ViewerHtmlHandler class with guid parameter as shown in examples below.

##### Public PrintableHtmlContainer GetPrintableHtml(string guid) is added

Use this method as a replacement for obsolete method as shown in example below.

**Using GetPrintableHtml method of the ViewerHtmlHandler class with guid instead of GetPrintableHtml method without guid parameter.**



```csharp
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler();
string guid = "word.doc";

// Get document html for print
var container = htmlHandler.GetPrintableHtml(guid);

Console.WriteLine("Html content: {0}", container.HtmlContent);

```

##### Public PrintableHtmlContainer GetPrintableHtml(string guid, PrintableHtmlOptions printableHtmlOptions) is added

Use this method as a replacement for obsolete method as shown in example below.

**Using GetPrintableHtml method of the ViewerHtmlHandler class with guid instead of GetPrintableHtml method without guid parameter**



```csharp
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler();
string guid = "word.doc";

// Setup watermark and style
Watermark watermark = new Watermark("Watermark text");
string css = "a { color: hotpink; }";

// Setup printable options
var options = new PrintableHtmlOptions();
options.Watermark = watermark;
options.Css = css;

// Get document html for print with custom css and watermark
var container = htmlHandler.GetPrintableHtml(guid, options);

Console.WriteLine("Html content: {0}", container.HtmlContent);

```

##### Public RotatePageContainer RotatePage(RotatePageOptions rotatePageOptions) method is set as obsolete

This method is set as obsolete and will be removed in the version 17.5.0, please use RotatePage method with guid parameter instead as shown in example below.

##### Public void RotatePage(string guid, RotatePageOptions rotatePageOptions) method is added

Use this method as a replacement for obsolete method as shown in example.

**Using RotatePage method with guid instead of obsolete RotatePage method.**



```csharp
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler();
string guid = "word.doc";

// Set rotation angle 90 for page number 1
RotatePageOptions rotateOptions = new RotatePageOptions(1, 90);

// Perform page rotation
htmlHandler.RotatePage(guid, rotateOptions);

```

{{< alert style="info" >}}To get final rotation angle of the document, please use GetDocumentInfo method of corresponding ViewerHandler class.{{< /alert >}}

##### Public void ReorderPage(ReorderPageOptions reorderPageOptions) method is set as obsolete

This method is set as obsolete and will be removed in the version 17.5.0, please use ReorderPage method with guid parameter instead as shown in example below.

##### Public void ReorderPage(string guid, ReorderPageOptions reorderPageOptions) is added

Use this method as a replacement for obsolete method as shown in example.

**Using ReorderPage method with guid instead of obsolete ReorderPage method.**



```csharp
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler();
string guid = "word.doc";
int pageNumber = 1;
int newPosition = 2;

// Perform page reorder
ReorderPageOptions options = new ReorderPageOptions(pageNumber, newPosition);
htmlHandler.ReorderPage(guid, options);

```

##### Public FileTreeContainer LoadFileTree () method is removed

Please use GetFileList() method instead.

##### Public FileTreeContainer LoadFileTree(FileTreeOptions fileTreeOptions) method is removed

Please use GetFileList(FileListOptions fileListOptions) method instead.

#### Changes in GroupDocs.Viewer.Handler.ViewerImageHandler

##### Public PrintableHtmlContainer GetPrintableHtml(PrintableHtmlOptions printableHtmlOptions) is set as obsolete

This method was set as obsolete and will be removed in the version 17.5.0, please use GetPrintableHtml method of the ViewerImageHandler class with guid parameter as shown in examples below.

##### Public PrintableHtmlContainer GetPrintableHtml(string guid) is added

Use this method as a replacement for obsolete method as shown in example below.

**Using GetPrintableHtml method of the ViewerImageHandler class with guid instead of GetPrintableHtml method without guid parameter**



```csharp
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler();
string guid = "word.doc";

// Get document html for print
var container = imageHandler.GetPrintableHtml(guid);

Console.WriteLine("Html content: {0}", container.HtmlContent);

```

##### Public PrintableHtmlContainer GetPrintableHtml(string guid, PrintableHtmlOptions printableHtmlOptions) is added

Use this method as a replacement for obsolete method as shown in example below.

**Using GetPrintableHtml method of the ViewerImageHandler class with guid instead of GetPrintableHtml method without guid parameter**



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

##### Public RotatePageContainer RotatePage(RotatePageOptions rotatePageOptions) method is set as obsolete

This method is set as obsolete and will be removed in the version 17.5.0, please use RotatePage method with guid parameter instead as shown in example below.

##### Public void RotatePage(string guid, RotatePageOptions rotatePageOptions) method is added

Use this method as a replacement for obsolete method as shown in example.

**Using RotatePage method with guid instead of obsolete RotatePage method.**



```csharp
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler();
string guid = "word.doc";

// Set rotation angle 90 for page number 1
RotatePageOptions rotateOptions = new RotatePageOptions(1, 90);

// Perform page rotation
imageHandler.RotatePage(guid, rotateOptions);

```

{{< alert style="info" >}}To get final rotation angle of the document, please use GetDocumentInfo method of corresponding ViewerHandler class.{{< /alert >}}

##### Public void ReorderPage(ReorderPageOptions reorderPageOptions) method is set as obsolete

This method is set as obsolete and will be removed in the version 17.5.0, please use ReorderPage method with guid parameter instead as shown in example below.

##### Public void ReorderPage(string guid, ReorderPageOptions reorderPageOptions) is added

Use this method as a replacement for obsolete method as shown in example.

**Using ReorderPage method with guid instead of obsolete ReorderPage method.**



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

##### Public FileTreeContainer LoadFileTree () method is removed

Please use GetFileList() method instead.

##### Public FileTreeContainer LoadFileTree(FileTreeOptions fileTreeOptions) method is removed

Please use GetFileList(FileListOptions fileListOptions) method instead.
