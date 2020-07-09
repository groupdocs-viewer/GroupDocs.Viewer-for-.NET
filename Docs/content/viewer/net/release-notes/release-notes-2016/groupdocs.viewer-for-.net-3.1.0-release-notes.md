---
id: groupdocs-viewer-for-net-3-1-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-3-1-0-release-notes
title: GroupDocs.Viewer For .NET 3.1.0 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 3.1.0.{{< /alert >}}

## Major Features

There are 32 improvements and fixes in this regular monthly release. The most notable are:

*   Introduced error localization.
*   Improved image watermarks.
*   Improved image conversion and resizing.
*   Improved convertor post-processing actions.
*   Added required HTML markup for email documents.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-425 | Implement ru-RU localization for error messages | New Feature |
| VIEWERNET-424 | Implement en-US localization for error messages | New Feature |
| VIEWERNET-348 | Implement localization. | New Feature |
| VIEWERNET-322 | Handle load document errors. | New Feature |
| WEB-1105 | Request the Aspose.Cells team to make output HTML compatible with Viewer.NET | Improvement |
| VIEWERNET-405 | Improve applying image watermark. | Improvement |
| VIEWERNET-404 | Improve email document loading by passing load options. | Improvement |
| VIEWERNET-367 | Improve LocalizedStringKeys description by adding default template messages. | Improvement |
| VIEWERNET-366 | Implement Localization Handler Interface. | Improvement |
| VIEWERNET-365 | Improve converter post-processing actions. | Improvement |
| VIEWERNET-362 | Improve image converter resizing. | Improvement |
| VIEWERNET-359 | Use output stream for convert page operations. | Improvement |
| VIEWERNET-355 | Localize exception messages. | Improvement |
| VIEWERNET-338 | Add required html markup for email documents. | Improvement |
| WEB-2424 | Not completely correct conversion from HTML to PDF | Bug |
| WEB-2319 | The order of characters in RTL words is reversed | Bug |
| WEB-2313 | Incorrect conversion from XLSX to the PDF and HTML | Bug |
| WEB-2291 | Incorrect conversion to HTML and JPEG | Bug |
| WEB-2278 | Process hangs when converting specific PDF to HTML and JPEG | Bug |
| WEB-2270 | Long whitespace when replacing text in numbered list in specific conditions | Bug |
| WEB-2079 | Empty table content when converting PDF to HTML | Bug |
| WEB-2019 | Exception when converting PDF to HTML with specific parameters | Bug |
| WEB-1913 | Text is absent in HTML, does not fit in images produced from a PDF | Bug |
| WEB-1171 | Incorrect rendering of the EPUB file | Bug |
| WEB-1165 | An image on a page is turned upside down when viewing a PDF file in the image mode | Bug |
| WEB-1040 | Exceptions are thrown when trying to view Word documents | Bug |
| VIEWERNET-412 | The pdf diagonal watermark is not in the center of the document. | Bug |
| VIEWERNET-391 | Watermark width is not applying in the case of rendering as PDF | Bug |
| VIEWERNET-364 | File not found exception when document loaded from stream. | Bug |
| VIEWERNET-358 | Stream is not readable exception when trying to load password protected pdf. | Bug |
| VIEWERNET-352 | Html blocks are outside html document when converting mhtml email to html. | Bug |
| VIEWERNET-316 | Empty, incomplete or invalid html when saving to stream | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 3.1.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

ILocaleHandler has been removed from all ViewerHtmlHandler constructors.
