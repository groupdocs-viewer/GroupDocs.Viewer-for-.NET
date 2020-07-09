---
id: groupdocs-viewer-for-net-3-4-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-3-4-0-release-notes
title: GroupDocs.Viewer For .NET 3.4.0 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
This page contains release notes for GroupDocs.Viewer for .NET 3.4.0

## Major Features

There are 24 improvements and fixes in this regular monthly release. The most notable are:

*   Improved rendering performance.
*   Improved applying watermark performance.
*   Improved GetPdfFile method usability and performance.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-628 | Implement RotatePage method that returns void | Improvement |
| VIEWERNET-663 | Improve library performance | Improvement |
| VIEWERNET-665 | Improve applying watermark performance | Improvement |
| VIEWERNET-670 | Improve get pdf file performance | Improvement |
| VIEWERNET-674 | Improve GetPdfFile method usability | Improvement |
| WEB-1734 | Hide the hidden sheets for .xls file | Improvement |
| VIEWERNET-652 | Small images are not visible in image mode | Bug |
| VIEWERNET-655 | Invalid parameter exception while converting mpt to image | Bug |
| VIEWERNET-659 | File is corrupted or damaged exception while converting mpt document to image | Bug |
| VIEWERNET-662 | Project reading exception in multithreading environment | Bug |
| VIEWERNET-681 | GetPdfFile returns all pages in trial mode | Bug |
| VIEWERNET-682 | JpegQuality is not applied for watermarked images | Bug |
| VIEWERNET-684 | Invalid Rendering of Excel File into Html and Image | Bug |
| VIEWERNET-689 | Incorrect Rendering of Excel File into Html and Image | Bug |
| VIEWERNET-690 | GetPages() for Email Attachment Throws Path Exception for Relative Storage Path | Bug |
| VIEWERNET-693 | Invalid Parameter Exception in Html Rendering | Bug |
| VIEWERNET-701 | GetPages() Throws Exception In Case of Stream Object | Bug |
| VIEWERNET-722 | Failed to load xps document in image mode with pdf | Bug |
| VIEWERNET-725 | API Renders First Sheet Twice in Excel Workbook | Bug |
| WEB-1709 | Text is shifted and duplicated in a PDF produced from VSD | Bug |
| WEB-1813 | Diagram file rendering regression | Bug |
| WEB-2029 | Incorrect saving XLSX to HTML | Bug |
| WEB-2289 | Incomplete converting XLSX to HTML | Bug |
| WEB-2322 | Text coordinates are incorrect for a specific document | Bug |
| WEB-2433 | Not all content of the Visio file is stored when converting to the PDF | Bug |
| VIEWERNET-729 | Incorrect Spacing between Characters in Html Rendering | Bug |

## Public API and Backward Incompatible Changes

The PdfFileOptions AddPrintAction property is obsolete in version 3.4.0, please use PdfFileOptions Transformations property and Transformation.AddPringAction enumeration.

**Get original file in Pdf format with print action**

Add watermark to Pdf document by setting AddPrintAction property to True of PdfFileOptions.

{{< alert style="info" >}}The PdfFileOptions AddPrintAction property is obsolete in version 3.4.0, please use PdfFileOptions Transformations property and Transformation.AddPringAction enumeration.{{< /alert >}}



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);

PdfFileOptions options = new PdfFileOptions();
options.Guid = "word.doc";

// Set add print action property
options.AddPrintAction = true;

// Get file as pdf with print action
FileContainer container = imageHandler.GetPdfFile(options);
Console.WriteLine("Stream lenght: {0}", container.Stream.Length);


```

**Get original file in Pdf format with transformations**

Add watermark to Pdf document by setting Transformations property of PdfFileOptions.

{{< alert style="info" >}}Transformation.AddPrintAction feature is supported starting from version 3.4.0{{< /alert >}}



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);

PdfFileOptions options = new PdfFileOptions();
options.Guid = "word.doc";

// Set apply rotate and reorder transformations
options.Transformations = Transformation.Rotate | Transformation.Reorder | Transformation.AddPrintAction;

// Get file as pdf with transformations
FileContainer container = imageHandler.GetPdfFile(options);
Console.WriteLine("Stream lenght: {0}", container.Stream.Length);


```
