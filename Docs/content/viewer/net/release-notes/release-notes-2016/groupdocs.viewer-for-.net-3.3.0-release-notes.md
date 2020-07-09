---
id: groupdocs-viewer-for-net-3-3-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-3-3-0-release-notes
title: GroupDocs.Viewer For .NET 3.3.0 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
This page contains release notes for GroupDocs.Viewer for .NET 3.3.0

## Major Features

There are 33 improvements and fixes in this regular monthly release. The most notable are:

*   Introduced option to specify custom fonts path.
*   Introduced new methods for working with email attachments.
*   Introduced new methods for getting info for remotely located document or document in the form of stream.
*   Introduced ability to clear cache.
*   Introduced options to set opacity setting for watermark in html mode.
*   Improved rendering performance.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-631 | Add ability to specify custom fonts path | New Feature |
| VIEWERNET-475 | Opacity setting for Watermark | New Feature |
| VIEWERNET-416 | Get selected attachment from email documents | New Feature |
| VIEWERNET-414 | Render attachments from email documents | New Feature |
| VIEWERNET-478 | Pre-Render Information required of a remotely located document or document in the form of streams | New Feature |
| VIEWERNET-459 | Provide remove old cache utility feature in the next generation API | New Feature |
| VIEWERNET-582 | The GroupDocs.Viewer 3.x is slower than 2.19 in performance | Improvement |
| VIEWERNET-641 | Update DocumentInfoOptions Cells/Words/Email DocumentInfoOptions properties names and types | Improvement |
| VIEWERNET-640 | Remove duplicated document name header in Project document converted to html | Improvement |
| VIEWERNET-636 | Remove border in html that was converted from words document | Improvement |
| VIEWERNET-619 | Implement adding prefix to font-family property if it can be overriden | Improvement |
| VIEWERNET-614 | Implement transparent watermarking in html mode | Improvement |
| VIEWERNET-600 | Improve performance of extracting document information in image mode | Improvement |
| VIEWERNET-590 | Apply HtmlResourcePrefix to fonts mentioned in css files | Improvement |
| VIEWERNET-568 | Load document only when not cached | Improvement |
| VIEWERNET-557 | Improve temp files folder structure | Improvement |
| VIEWERNET-558 | Improve processing remote files by Uri | Improvement |
| WEB-1107 | Convert a document page to JPEG in about 0.1 second | Improvement |
| WEB-905 | Links for mail attachments | Improvement |
| VIEWERNET-642 | GetDocumentInfo Method Throws Exception in Evaluation Mode | Bug |
| VIEWERNET-632 | The HtmlResourcePrefix {page-number} is not set in DiagramToHtmlConverter | Bug |
| VIEWERNET-476 | Some characters are not showing in correct format when render as HTML | Bug |
| VIEWERNET-591 | 'System.OutOfMemoryException' thrown while rendering as image | Bug |
| VIEWERNET-605 | Only first frame or tiff document converted in image mode | Bug |
| VIEWERNET-606 | Only first frame or tiff document converted in image mode | Bug |
| VIEWERNET-550 | MSG file is not rendering properly | Bug |
| VIEWERNET-583 | Failed to get document information in image mode with text from epub document | Bug |
| VIEWERNET-570 | Failed to get document information in image mode with text in trial | Bug |
| VIEWERNET-551 | File description document type format is Unknown when extension is upper case | Bug |
| VIEWERNET-552 | File description document type format is Unknown when extension is upper case | Bug |
| WEB-2372 | Different HTML generated for the same document | Bug |
| WEB-1531 | Outlines are rendered incorrectly in HTML | Bug |
| WEB-2320 | Some text extracted from document twice | Bug |

   
 

## Public API and Backward Incompatible Changes

#### Set custom fonts directory path



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Add custom fonts directories to FontDirectories list
config.FontDirectories.Add(@"/usr/admin/Fonts");
config.FontDirectories.Add(@"/home/admin/Fonts");
 
// Init viewer handler with config
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);


```

#### Get email attachment original file



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create image handler
ViewerImageHandler handler = new ViewerImageHandler(config);
EmailAttachment attachment = new EmailAttachment("document-with-attachments.msg", "attachment-image.png");
  
// Get attachment original file
FileContainer container = imageHandler.GetFile(attachment);
Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType);
Console.WriteLine("Attach stream lenght: {0}", fileContainer.Stream.Length);


```

#### Get attachment document html representation



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
viewerConfig.UseCache = true;
 
// Setup html conversion options
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.IsResourcesEmbedded = false;
  
// Init viewer html handler
ViewerHtmlHandler handler = new ViewerHtmlHandler(viewerConfig);
 
DocumentInfoContainer info = handler.GetDocumentInfo("document-with-attachments.msg");
 
// Iterate over the attachments collection
foreach (AttachmentBase attachment in info.Attachments)
{
    Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType);
 
    // Get attachment document html representation
    List<PageHtml> pages = handler.GetPages(attachment, htmlOptions);
    foreach (PageHtml page in pages)
    {
        Console.WriteLine("  Page: {0}, size: {1}", page.PageNumber, page.HtmlContent.Length);
        foreach (HtmlResource htmlResource in page.HtmlResources)
        {
            Stream resourceStream = handler.GetResource(attachment, htmlResource);
            Console.WriteLine("     Resource: {0}, size: {1}", htmlResource.ResourceName, resourceStream.Length);
        }
    }
}


```

#### Get attachment document image representation



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
viewerConfig.UseCache = true;
  
// Init viewer image handler
ViewerImageHandler handler = new ViewerImageHandler(viewerConfig);
 
DocumentInfoContainer info = handler.GetDocumentInfo("document-with-attachments.msg");
 
// Iterate over the attachments collection
foreach (AttachmentBase attachment in info.Attachments)
{
    Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType);
 
    // Get attachment document image representation
    List<PageImage> pages = handler.GetPages(attachment, htmlOptions);
    foreach (PageImage page in pages)
        Console.WriteLine("  Page: {0}, size: {1}", page.PageNumber, page.Stream.Length);
}


```

#### Get document information by guid

The following code snippet shows you how to get document information by guid in Viewer v.3.3.0



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

#### Get document information by stream



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
 
// Get document stream
Stream stream = GetDocumentStream();
// Get document information
DocumentInfoOptions options = new DocumentInfoOptions();
DocumentInfoContainer documentInfo = htmlHandler.GetDocumentInfo(stream, options);
 
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

#### Get document information by Uri



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
 
Uri uri = new Uri("http://example.com/words.doc");
 
// Get document information
DocumentInfoOptions options = new DocumentInfoOptions();
DocumentInfoContainer documentInfo = htmlHandler.GetDocumentInfo(uri, options);
 
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

#### How to clear all cache files



```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
 
// Init viewer image or html handler
ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig);
 
//Clear all cache files 
viewerImageHandler.ClearCache();


```

#### How to clear files from cache older than specified time interval



```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
 
// Init viewer image or html handler
ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig);
 
//Clear files from cache older than specified time interval
TimeSpan olderThanTwoDays = TimeSpan.FromDays(2);
viewerImageHandler.ClearCache(olderThanTwoDays)


```
