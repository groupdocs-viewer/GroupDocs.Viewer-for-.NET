---
id: groupdocs-viewer-for-net-17-8-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-17-8-0-release-notes
title: GroupDocs.Viewer for .NET 17.8.0 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 17.8.0{{< /alert >}}

## Major Features

There are 9 new features and 11 improvements and fixes in this regular monthly release. The most notable are:

*   Responsive output for rendering into HTML
*   Setting to ignore HTML Resource Prefix in resources
*   Implemented feature to show comments when rendering Spreadsheet documents as HTML
*   Implemented feature to show comments when rendering Presentation documents
*   Implemented feature to ignore empty rows when rendering Spreadsheet documents
*   Added DNG image file format support
*   Added Microsoft Visio VSTM, VSSM and VSDM file formats support

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1322 | Export styles that make page responsive when resources are not embedded | New Feature |
| VIEWERNET-1315 | Implement a setting for ignoring HTML Resource Prefix in resources | New Feature |
| VIEWERNET-1307 | Show comments when rendering Spreadsheet documents as HTML | New Feature |
| VIEWERNET-1305 | Ignore empty rows when rendering Spreadsheet documents | New Feature |
| VIEWERNET-1292 | Add DNG image file format support | New Feature |
| VIEWERNET-1260 | Add VSTM file format support | New Feature |
| VIEWERNET-1259 | Add VSSM file format support | New Feature |
| VIEWERNET-1258 | Add VSDM file format support | New Feature |
| VIEWERNET-1191 | Show comments when rendering Presentation documents | New Feature |
| VIEWERNET-1321 | Improve setting prefix for fonts when rendering Text document as HTML | Improvement |
| VIEWERNET-1314 | Use single naming convention for HTML resources | Improvement |
| VIEWERNET-1306 | Use ICacheDataHandler instead of IFileDataStore | Improvement |
| VIEWERNET-1296 | Implement responsive output for rendering into HTML | Improvement |
| VIEWERNET-1303 | Exception when rendering Excel document into HTML and image | Bug |
| VIEWERNET-1297 | Exception when rendering email message containing .msg file as attachment | Bug |
| VIEWERNET-1241 | "Index was out of range" exception when rendering PDF to Html | Bug |
| VIEWERNET-1189 | Unable to render Word document having AD RMS template | Bug |
| VIEWERNET-1148 | Unable to render PDF document in HTML/Image mode | Bug |
| VIEWERNET-1063 | Rendering MS Project document stops responding | Bug |
| VIEWERNET-1017 | Check boxes in PDF document are not rendered correctly | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 17.8.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Ignoring resource prefix for HTML resources

{{< alert style="info" >}}Since the version 17.8.0, IgnoreResourcePrefixForCss setting is set obsolete and has been replaced by IgnorePrefixInResources which applies to all resource types.{{< /alert >}}

**Ignoring resource prefix using IgnorePrefixInResources**



```csharp
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.HtmlResourcePrefix = "http://contoso.com/api/getResource?name="
htmlOptions.IgnorePrefixInResources = true;
```

### Rendering documents with Comments

{{< alert style="info" >}}Since the version 17.8.0, rendering comments into HTML and PDF is supported for Microsoft Power Point documents and rendering comments into HTML is supported for Spreadsheet documents (MS Excel and OpenDocument spreadsheet).{{< /alert >}}

**Rendering document with comments.**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.pptx";
  
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

**Getting PDF representation of document with comments.**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.pptx";
  
// Set pdf options to get pdf file with comments
PdfFileOptions options = new PdfFileOptions();
options.RenderComments = true; // Default value is false
 
// Get pdf document with comments
FileContainer fileContainer = imageHandler.GetPdfFile(guid, pdfFileOptions);
// Access result pdf document using fileContainer.Stream property
```

### Ignoring empty rows when rendering Cells documents

Sometimes Cells document contains information in the beginning of the worksheet and after that, it contains some count of empty (blank) rows and information again e.g. summary row. Starting from 17.8.0, GroupDocs.Viewer provides new option *CellsOptions.IgnoreEmptyRows* which allows omitting rendering of empty rows as shown in the sample below.

**Ignoring empty rows when rendering Cells documents.**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.xlsx";
  
// Set Cells options to hide overflowing text
HtmlOptions options = new HtmlOptions();
options.CellsOptions.IgnoreEmptyRows = true; // default value is false
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

### Single naming convention for HTML resources

{{< alert style="info" >}}Starting from 17.8.0, GroupDocs.Viewer for .NET uses the single naming convention for HTML resources.{{< /alert >}}

*   Image resources (resources with extensions .png, .jpg, .jpeg, .bmp, .emf, .wmf) 
    *   for the first resource: image + extension e.g. image.png
    *   for the second and next resources: image + number + extension e.g. image1.png
*   Font resources (resources with extensions .woff, .eot, .ttf) 
    *   for the first resource: font + extension e.g. font.woff
    *   for the second and next resources: font + number + extension e.g. font1.woff
*   Graphics resources (resources with extensions .svg) 
    *   for the first resource: graphics.svg
    *   for the second and next resources: graphics + number.svg e.g. graphics1.svg
*   Other resources
    *   for the first resource: other + extension e.g. other.ext
    *   for the second and next resources: other + number + extension e.g. other1.ext

### Responsive output for rendering into HTML

In order to make your rendering into HTML look well across all type of devices set *EnableResponsiveRendering *option of HtmlOptions class and pass it to ViewerHtmlHandler as shown in example below:

**Getting responsive html representations.**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "CadDrawing.dwg";
 
HtmlOptions options = new HtmlOptions();
options.EnableResponsiveRendering = true;
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
 
 
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

{{< alert style="info" >}}Currently this option works for most document types, however, there are few (listed below) that are not supported yet. It is planned to extend support for this option in coming releases.{{< /alert >}}

**List of document types that do not support responsive rendering**

| Format Name | Extension |
| --- | --- |
| Comma-Separated Values | CSV |
| Electronic publication | EPUB |
| Extensible Markup Language | XML |
| HyperText Markup Language | HTML, MHT, MHTML |
| Image files | SVG |
| LaTeX | TEX |
| Microsoft Excel | XLS, XLSX, XLSM, XLSB |
| Microsoft PowerPoint | PPT, PPTX, PPS, PPSX |
| Microsoft Project | MPP, MPT |
| Microsoft Visio | VSD, VDX, VSS, VSX, VST, VTX, VSDX, VDW, VSSX, VSTX, VSDM , VSTM, VSSM |
| Microsoft Word | DOC, DOCX, DOCM, DOT, DOTX, DOTM |
| Mobipocket e-book format | MOBI |
| OpenDocument Formats | ODT, OTT, ODS, ODP, OTP, OTS |
| Plain Text File | TXT |
| Portable Document Format | PDF |
| Rich Text Format | RTF |
| XML Paper Specification | XPS |

### List of Changes in v17.8.0

#### GroupDocs.Viewer.Config.ViewerConfig

##### Public bool UsePdf obsolete property compilation is set to fail

This property will be removed in the version 17.9.0, please use ImageOptions.ExtractText or DocumentInfoOptions.ExtractText settings instead, as shown in the example below.

**Get text coordinates in image mode**

**before v17.6.0 (C#)**

```csharp
 //Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
viewerConfig.UsePdf = true;
 
// Set document guid
string guid = "document.doc";
 
// Init viewer image handler
ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig);
 
//Get document info
DocumentInfoContainer documentInfoContainer = viewerImageHandler.GetDocumentInfo(guid);
 
// Go through all pages
foreach (PageData pageData in documentInfoContainer.Pages)
{
    Console.WriteLine("Page number: " + pageData.Number);
  
    //Go through all page rows
    for (int i = 0; i < pageData.Rows.Count; i++)
    {
        RowData rowData = pageData.Rows[i];
 
        // Write data to console
        Console.WriteLine("Row: " + (i + 1));
        Console.WriteLine("Text: " + rowData.Text);
        Console.WriteLine("Text width: " + rowData.LineWidth);
        Console.WriteLine("Text height: " + rowData.LineHeight);
        Console.WriteLine("Distance from left: " + rowData.LineLeft);
        Console.WriteLine("Distance from top: " + rowData.LineTop);
 
        // Get words
        string[] words = rowData.Text.Split(' ');
 
        // Go through all word coordinates
        for (int j = 0; j < words.Length; j++)
        {
            int coordinateIndex = j == 0 ? 0 : j + 1;
 
            // Write data to console
            Console.WriteLine(string.Empty);
            Console.WriteLine("Word: '" + words[j] + "'");
            Console.WriteLine("Word distance from left: " + rowData.TextCoordinates[coordinateIndex]);
            Console.WriteLine("Word width: " + rowData.TextCoordinates[coordinateIndex + 1]);
            Console.WriteLine(string.Empty);
        }
    }
}
```

**v17.6.0 and higher (C#)**

```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
 
// Set document guid
string guid = "document.doc";
 
// Init viewer image handler
ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig);
 
//Get document info
DocumentInfoOptions documentInfoOptions = new DocumentInfoOptions();
documentInfoOptions.ExtractText = true;
DocumentInfoContainer documentInfoContainer = viewerImageHandler.GetDocumentInfo(guid, documentInfoOptions);
 
// Go through all pages
foreach (PageData pageData in documentInfoContainer.Pages)
{
    Console.WriteLine("Page number: " + pageData.Number);
  
    //Go through all page rows
    for (int i = 0; i < pageData.Rows.Count; i++)
    {
        RowData rowData = pageData.Rows[i];
 
        // Write data to console
        Console.WriteLine("Row: " + (i + 1));
        Console.WriteLine("Text: " + rowData.Text);
        Console.WriteLine("Text width: " + rowData.LineWidth);
        Console.WriteLine("Text height: " + rowData.LineHeight);
        Console.WriteLine("Distance from left: " + rowData.LineLeft);
        Console.WriteLine("Distance from top: " + rowData.LineTop);
 
        // Get words
        string[] words = rowData.Text.Split(' ');
 
        // Go through all word coordinates
        for (int j = 0; j < words.Length; j++)
        {
            int coordinateIndex = j == 0 ? 0 : j + 1;
 
            // Write data to console
            Console.WriteLine(string.Empty);
            Console.WriteLine("Word: '" + words[j] + "'");
            Console.WriteLine("Word distance from left: " + rowData.TextCoordinates[coordinateIndex]);
            Console.WriteLine("Word width: " + rowData.TextCoordinates[coordinateIndex + 1]);
            Console.WriteLine(string.Empty);
        }
    }
}
```

#### GroupDocs.Viewer.Converter.Options.FileDataOptions

##### Public bool UsePdf obsolete property compilation is set to fail

This property will be removed in the version 17.9.0, please use ExtractText property instead.

#### GroupDocs.Viewer.Converter.Options.HtmlOptions

##### Public bool IgnoreResourcePrefixForCss property is set obsolete

This property will be removed in the version 17.11.0, please use IgnorePrefixInResources property instead, as shown in example below.

**In this example HtmlResourcePrefix option will be applied to resources inside HTML content, but will not be applied inside resources like SVG and CSS.**



```csharp
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.HtmlResourcePrefix = "http://contoso.com/api/getResource?name="
htmlOptions.IgnorePrefixInResources = true;
```

##### Public bool IgnorePrefixInResources has been added

Use this property to prevent adding HtmlResourcePrefix in resource files like CSS or SVG.

#### GroupDocs.Viewer.Domain.EmailFileData

##### Public GroupDocs.Viewer.Domain.EmailFileData class and class members compilation is set to fail

Please use FileData class instead. This class is obsolete and will be removed in version 17.9.0.

#### GroupDocs.Viewer.Handler.ViewerHtmlHandler

##### public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore) constructor is set obsolete

This constructor is obsolete and will be removed after 17.11.0. Please use overload without 'fileDataStore' parameter.

##### public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore, CultureInfo cultureInfo) constructor is set obsolete

This constructor is obsolete and will be removed after 17.11.0. Please use overload without 'fileDataStore' parameter.

#### GroupDocs.Viewer.Handler.ViewerImageHandler

##### public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore) constructor is set obsolete

This constructor is obsolete and will be removed after 17.11.0. Please use overload without 'fileDataStore' parameter.

##### public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore, CultureInfo cultureInfo) constructor is set obsolete

This constructor is obsolete and will be removed after 17.11.0. Please use overload without 'fileDataStore' parameter.

#### GroupDocs.Viewer.Helper.IFileDataStore

##### public interface IFileDataStore interface is set obsolete

This interface is obsolete and will be removed after 17.11.0.
