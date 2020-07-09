---
id: groupdocs-viewer-for-net-18-10-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-10-release-notes
title: GroupDocs.Viewer for .NET 18.10 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.10.{{< /alert >}}

## Major Features

There are 12 features, improvements, and fixes in this regular monthly release. The most notable are:

*   Added new option which allows setting the list of fonts to exclude when rendering into HTML
*   Improved rendering of MS Project documents when Start/End date options are set
*   Improved performance of methods which accept URL

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1677 | Option for setting the list of fonts that should be excluded from HTML | Feature |
| VIEWERNET-1773 | Do not show items beyond Start and End date options when rendering MS Project documents | Improvement |
| VIEWERNET-1742 | Release internal resources for methods which accept URL | Improvement |
| VIEWERNET-1738 | GetDocumentInfo method page number depending on the type of ViewerHandler | Improvement |
| VIEWERNET-1679 | Prevent setting malicious values for HtmlResourcePrefix | Improvement |
| VIEWERNET-1678 | Improve setting PageSize and TimeScale for MS Project documents by default  | Improvement |
| VIEWERNET-1741 | Specified watermark font not found exception when calling GetPdfFile method | Bug |
| VIEWERNET-1736 | OutlookOptions.MaxItemsInFolder option not working properly for rendering into image and PDF | Bug |
| VIEWERNET-1662 | Incorrect rendering of PDF document into HTML | Bug |
| VIEWERNET-1659 | Duplicate link tag when rendering Text documents with external resources | Bug |
| VIEWERNET-1649 | Exception when rendering PDF document as HTML | Bug |
| VIEWERNET-1420 | Images are missing when rendering PDF document into HTML or Image | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.10. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Option for setting the list of fonts that should be excluded from HTML

Adding fonts into HTML ensures that the text from the original document will appear similar in HTML, regardless of whether fonts are installed on the viewer's device or not. But at the same time, this improvement comes with the cost of the increased size of the output file. Since the version 18.10 GroupDocs.Viewer API provides a new setting - **HtmlOptions.ExcludeFontsList**, that allows finding the compromise, by preventing adding specific fonts (that are commonly available on most of the devices). The example below shows how to prevent adding fonts into output HTML. Currently, it works only for Presentation documents. We are planning to extend support for this feature for all document types where it is applicable in the upcoming releases.

**Prevent adding Arial and Times New Roman fonts into HTML representations (other fonts used in original presentation will be added).**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "presentation.pptx";
 
HtmlOptions options = new HtmlOptions();
options.ExcludeFontsList.Add("Times New Roman");
options.ExcludeFontsList.Add("Arial");
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
 
 
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

### List of Changes in v18.10

In the version 18.10, following public class members were added, marked as obsolete, removed or replaced.

#### GroupDocs.Viewer.Handler.Input.IInputDataHandler

##### DateTime GetLastModificationDate(string guid) method compilation is set to fail

This method is obsolete and will be removed after v18.10. GroupDocs.Viewer will rely on **LastModificationDate** field in the **FileDescription** object returned by **GetFileDescription** method.
