---
id: groupdocs-viewer-for-net-17-6-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-17-6-0-release-notes
title: GroupDocs.Viewer for .NET 17.6.0 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 17.6.0.{{< /alert >}}

## Major Features

One new feature and 8 improvements and fixes in this regular monthly release. The most notable are:

*   Added SVG file format support
*   Replaced backslashes in resource URL's with forward slashes
*   Implemented saving HTML resources apart from HTML document when rendering Presentation documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1223 | Add SVG format support | New Feature |
| VIEWERNET-1213 | Move the setting that enables text extraction to ImageOptions class | Improvement |
| VIEWERNET-1210 | Replace backslashes in resource URL's with forward slashes | Improvement |
| VIEWERNET-1199 | Extend support of HtmlOptions.IsResourceEmbedded option for Presentation documents | Improvement |
| VIEWERNET-1083 | Determine resource type based on resource name | Improvement |
| VIEWERNET-1082 | Remove obsolete ViewerConfig properties and fields | Improvement |
| VIEWERNET-1081 | Add code examples to WordsOptions class documentation comments | Improvement |
| VIEWERNET-1230 | Image export failed exception when passed CAD layout name does not exist. | Bug |
| VIEWERNET-1212 | File added to storage when GetDocumentInfo called for stream | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 17.6.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Getting Text Coordinates in Image Mode

**How to get text coordinates in image mode**



```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
  
// Set document guid
string guid = "document.doc";
  
// Init viewer image handler
ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig);
 
//Get document rendered as an image with text extraction enabled
ImageOptions imageOptions = new ImageOptions();
imageOptions.ExtractText = true;
List<PageImage> pages = viewerImageHandler.GetPages(guid, imageOptions);
 
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

### List of Changes in GroupDocs.Viewer for .NET 17.6.0

#### Public bool UsePdf property is set obsolete

This property will be removed in the version 17.8.0, please use ImageOptions.ExtractText or DocumentInfoOptions.ExtractText settings instead, as shown in the example below.

**How to get text coordinates in image mode**



```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
  
// Set document guid
string guid = "document.doc";
  
// Init viewer image handler
ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig);
 
//Get document rendered as an image with text extraction enabled
ImageOptions imageOptions = new ImageOptions();
imageOptions.ExtractText = true;
List<PageImage> pages = viewerImageHandler.GetPages(guid, imageOptions);
 
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

#### Public bool UsePdf property is set obsolete in GroupDocs.Viewer.Converter.Options.FileDataOptions

This property will be removed in the version 17.8.0, please use ExtractText property instead.

#### Public bool ExtractText property added in GroupDocs.Viewer.Converter.Options.ImageOptions

Please use this setting as a replacement for obsolete ViewerConfig.UsePdf, to render the document into the image with text extraction enabled.

#### Public bool ExtractText property added in GroupDocs.Viewer.Domain.CachedPageDescription

This property indicates that the cached page will be or has been created with text extraction enabled.

#### Public bool TextExtracted property added in GroupDocs.Viewer.Domain.FileData

This property indicates whether the text with coordinates has been extracted into the file data.

#### Public bool ExactText property added in GroupDocs.Viewer.Domain.Options.DocumentInfoOptions

Please use this setting as a replacement for obsolete ViewerConfig.UsePdf, to get the text with coordinates as shown in below example.

**How to get text coordinates in image mode**



```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
  
// Set document guid
string guid = "document.doc";
  
// Init viewer image handler
ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig);
 
//Get document rendered as an image with text extraction enabled
ImageOptions imageOptions = new ImageOptions();
imageOptions.ExtractText = true;
List<PageImage> pages = viewerImageHandler.GetPages(guid, imageOptions);
 
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

#### Public GroupDocs.Viewer.Handler.IInputDataHandler interface AddFile(string guid, Stream content) method is set as obsolete

This method is obsolete and will be removed after 17.9.0.
