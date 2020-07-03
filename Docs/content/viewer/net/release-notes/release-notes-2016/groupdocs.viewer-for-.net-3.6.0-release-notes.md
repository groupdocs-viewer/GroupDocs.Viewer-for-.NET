---
id: groupdocs-viewer-for-net-3-6-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-3-6-0-release-notes
title: GroupDocs.Viewer For .NET 3.6.0 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 3.6.0.{{< /alert >}}

## Major Features

There are 7 new features and 14 improvements and fixes in this regular monthly release. The most notable are:

*   Add support for Spanish locale.
*   Add support for Italian locale
*   Hide/Show the hidden pages for Visio files
*   Ability to set default font when rendering Cells and Words documents
*   Ability to set the encoding standard automatically
*   LaTeX file format viewing support

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-394 | Support for hyperlinks referencing a worksheet in the same document | New Feature |
| VIEWERNET-433 | Add support for Spanish locale | New Feature |
| VIEWERNET-435 | Add support for Italian locale | New Feature |
| VIEWERNET-639 | Hide/Show the hidden pages for Visio files | New Feature |
| VIEWERNET-801 | Ability to set default font when rendering Cells documents | New Feature |
| VIEWERNET-802 | Ability to set default font when rendering Words documents | New Feature |
| WEB-2073 | LaTeX file format viewing support | New Feature |
| VIEWERNET-401 | Improve applying pdf document transformations | Improvement |
| VIEWERNET-803 | Ability to set the encoding standard automatically | Improvement |
| VIEWERNET-824 | Cleanup GetDocumentInfo method response | Improvement |
| VIEWERNET-826 | Remove XHTML xmlns attribute | Improvement |
| VIEWERNET-827 | Cleanup html markup for Cells documents | Improvement |
| VIEWERNET-596 | The bookmark range is invalid for .docx | Bug |
| VIEWERNET-747 | Text document format detected as Unknown | Bug |
| VIEWERNET-805 | GetPages() Method Throws "Parameter is not valid" Exception | Bug |
| VIEWERNET-807 | Output html contains garbled characters and few characters are merged | Bug |
| VIEWERNET-820 | GetPages() throws exception for email attachments | Bug |
| VIEWERNET-821 | API throws exception in Mono | Bug |
| VIEWERNET-835 | User can't catch GroupDocsException | Bug |
| WEB-2070 | Convert .docx to .pdf wrong symbol | Bug |
| WEB-2448 | Missing character in resultant html | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 3.6.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Cleanup GetDocumentInfo method response

*   Class GroupDocs.Viewer.Domain.Containers.DocumentInfoContainer field ContentControls marked as 'obsolete' 
*   Class GroupDocs.Viewer.Domain.ContentControl marked as 'obsolete' 
*   Class GroupDocs.Viewer.Domain.WordsFileData field ContentControls marked as 'obsolete'

### User can't catch GroupDocsException

*   New public class GroupDocs.Viewer.Exception.GroupDocsViewerException
*   All exceptions from GroupDocs.Viewer.Exception namespace are derived classes of GroupDocsViewerException.

### How to specify resource prefix

**HtmlResourcePrefix** setting is necessary when every resource name in html document should be prefixed with some string. This may be useful when resources for document are obtained via some REST API method. Please note that css files will also be processed - html resource prefix value will be added to font names in css file.



```csharp
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.HtmlResourcePrefix = "http://contoso.com/api/getResource?name="


```

If ccs files should not be processed then **IgnoreResourcePrefixForCss** setting should be set to true.



```csharp
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.HtmlResourcePrefix = "http://contoso.com/api/getResource?name="
htmlOptions.IgnoreResourcePrefixForCss = true;


```

### How to set default font name

Default font name may be specified in this cases:  
#You want to generally specify the default font to fall back on if particular font in a document cannot be found during rendering.  
#Your document uses fonts that non-English characters and you want to make sure any missing font is replaced with one that has the same character set available.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
config.DefaultFontName = "Calibri";


```

### Show hidden pages in MS Visio files

**Show hidden pages for Visio files in image representation**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "sample.vdx";
  
// Set image options to show hidden pages
ImageOptions options = new ImageOptions();
options.DiagramOptions.ShowHiddenPages = true;
  
DocumentInfoContainer container = imageHandler.GetDocumentInfo(guid);
  
foreach (PageData page in container.Pages)
   Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible);
  
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
   Console.WriteLine("Page number: {0}", page.PageNumber);
  
   // Page image stream
   Stream imageContent = page.Stream;
}

```

**Show hidden pages for Visio files in html representation**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "sample.vdx";
  
// Set html options to show grid lines
HtmlOptions options = new HtmlOptions();
options.DiagramOptions.ShowHiddenPages = true;
  
DocumentInfoContainer container = htmlHandler.GetDocumentInfo(guid);
  
foreach (PageData page in container.Pages)
   Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible);
  
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
{
   Console.WriteLine("Page number: {0}", page.PageNumber);
   //Console.WriteLine("Html content: {0}", page.HtmlContent);
}

```

### How to specify internal hyperlink prefix for Excel files

It's known fact that Excel workbook may contain hyperlink to specific location in the same workbook.

[https://support.office.com/en-us/article/Hyperlinks-in-worksheets-EDB15706-517B-4ECF-81C6-84068FF8677E](https://support.office.com/en-us/article/Hyperlinks-in-worksheets-EDB15706-517B-4ECF-81C6-84068FF8677E).

**InternalHyperlinkPrefix** setting is useful for applications where workbook sheets are rendered separately one by one. In this case internal hyperlink may contain some REST API method address with referenced sheet name.



```csharp
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.CellsOptions.InternalHyperlinkPrefix = "http://contoso.com/api/getPage?name="



```

**InternalHyperlinkPrefix** value may contain page number placeholder which will be substituted with referenced sheet number.



```csharp
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.CellsOptions.InternalHyperlinkPrefix = "http://contoso.com/api/getPage?number={page-number}"


```
