---
id: groupdocs-viewer-for-net-21-4-release-notes
url: viewer/net/groupdocs-viewer-for-net-21-4-release-notes
title: GroupDocs.Viewer for .NET 21.4 Release Notes
weight: 117
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 21.4"
keywords: release notes, groupdocs.viewer, .net, 21.4
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 21.4{{< /alert >}}

## Major Features

There are 19 features, improvements, and bug-fixes in this release, most notable are:

* [GroupDocs.Viewer WPF Example](<https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WPF>)
* [GroupDocs.Viewer Windows Forms Example](<https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WinForms>)
* [Add support of resizing images when rendering to HTML/PDF]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/set-output-image-size-limits-when-rendering-to-pdf-html.md">}})
* Watermark styles correct page layout
* Descriptive exception message when opening password-protected ODP/OTP presentations
* Default font is applied when rendering PPTX

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-3144|GroupDocs.Viewer WPF Example|Feature|
|VIEWERNET-3139|GroupDocs.Viewer Windows Forms Example|Feature|
|VIEWERNET-2945|Add support of resizing images when rendering to HTML/PDF|Feature|
|VIEWERNET-3135|Watermark styles are breaking page layout|Bug|
|VIEWERNET-2852|"Image export failed." exception when rendering SVG file|Bug|
|VIEWERNET-3151|Output SVG is not valid when converting EMF|Bug|
|VIEWERNET-2814|Could not load file. File is corrupted or damaged.|Bug|
|VIEWERNET-3101|Html markup broken for specific VSD file|Bug|
|VIEWERNET-3149|Content is missing when rendering XLSX file|Bug|
|VIEWERNET-3154|Ignore empty pages when rendering Excel spreadsheets|Bug|
|VIEWERNET-3156|Output image or html is filled with black color|Bug|
|VIEWERNET-3157|Exception thrown when rendering from PDF with images in Linux|Bug|
|VIEWERNET-3158|Default font is not applied when rendering PPTX|Bug|
|VIEWERNET-2828|"Could not load file. File is corrupted or damaged." exception when rendering IFC file|Bug|
|VIEWERNET-3161|Descriptive exception message when opening password-protected ODP/OTP presentations|Bug|
|VIEWERNET-2786|Problem with jpf image cache size|Bug|
|VIEWERNET-2742|Image export failed JPF|Bug|
|VIEWERNET-3105|DOCX to HTML: Incorrect SVG image rendering|Bug|
|VIEWERNET-3071|"Value cannot be null.Parameter name: key" exception when rendering PDF to JPEG in Linux|Bug|

## Public API and Backward Incompatible Changes

### Public API Changes

#### Changes in GroupDocs.Viewer.Options namespace

New properties have been added to [GroupDocs.Viewer.Options.HtmlViewOptions](<https://apireference.groupdocs.com/viewer/net/groupDocs.viewer.options/htmlviewoptions>) and  [GroupDocs.Viewer.Options.PdfViewOptions](<https://apireference.groupdocs.com/viewer/net/groupDocs.viewer.options/pdfviewoptions>) classes.

```csharp
/// <summary>
/// Max width of output image (for PNG/JPG output only)
/// </summary>
public int ImageMaxWidth { get; set; }

/// <summary>
/// Max height of output image (for PNG/JPG output only)
/// </summary>
public int ImageMaxHeight { get; set; }

/// <summary>
/// Image width (for PNG/JPG output only)
/// </summary>
public int ImageWidth { get; set; }

/// <summary>
/// Image Height (for PNG/JPG output only)
/// </summary>
public int ImageHeight { get; set; }
```
