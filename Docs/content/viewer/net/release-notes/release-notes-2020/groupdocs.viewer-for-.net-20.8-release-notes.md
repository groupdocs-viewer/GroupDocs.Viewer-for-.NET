---
id: groupdocs-viewer-for-net-20-8-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-8-release-notes
title: GroupDocs.Viewer for .NET 20.8 Release Notes
weight: 50
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 20.8"
keywords: release notes, groupdocs.viewer, .net, 20.8
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.8{{< /alert >}}

## Major Features  

There are 21 features, improvements, and bug-fixes in this release, most notable are:

* [Added Lotus Notes Database (.nsf) file-format support]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-lotus-notes-files/how-to-convert-and-view-nsf-files.md">}})
* [Added Compressed SVG File (.svgz) file-format support]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-image-files/how-to-convert-and-view-svg-and-svgz-files.md">}})
* When watermark is added output HTML doesn't end properly

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-2393|Add Lotus Notes Database (.nsf) file-format support|Feature|
|VIEWERNET-2607|Add Compressed SVG File (.svgz) file-format support|Feature|
|VIEWERNET-2472|"File is corrupted or damaged" exception is thrown when rendering DXF file"|Bug|
|VIEWERNET-2499|"A generic error occurred in GDI+" exception occurs when rendering DOCX file"|Bug|
|VIEWERNET-2506|"Image export failed" exception when rendering ODG file"|Bug
|VIEWERNET-2507|"Image export failed" when rendering JP2 file"|Bug|
|VIEWERNET-2536|"Input string was not in a correct format" exception when rendering VSDX"|Bug|
|VIEWERNET-2539|Exception is thrown when rendering PPTX file|Bug|
|VIEWERNET-2584|"File is corrupted or damaged" exception is thrown when rendring DOCX file"|Bug|
|VIEWERNET-2585|"Parameter is not valid" exception when rendering DOCX file"|Bug|
|VIEWERNET-2586|"File is corrupted or damaged" exception when rendering WMF file"|Bug|
|VIEWERNET-2588|"Unable to cast object of type" exception when rendering PPTX file"|Bug|
|VIEWERNET-2594|"Zoom value should be between 10 and 400" exception when rendering ODS file"|Bug|
|VIEWERNET-2602|NullReferenceException when rendering a certain PDF to HTML|Bug|
|VIEWERNET-2633|Particular HTML file to PDF rendering issue |Bug|
|VIEWERNET-2643|Overflow error on VDX file|Bug|
|VIEWERNET-2656|Can't open xlsm file|Bug|
|VIEWERNET-2662|The column index should not be inside the pivottable report|Bug|
|VIEWERNET-2663|GetViewInfo is stuck|Bug|
|VIEWERNET-2694|When watermark is added output HTML doesn't end properly|Bug|
|VIEWERNET-2704|Document wrongly marked as encrypted.|Bug|

## Public API and Backward Incompatible Changes

### Changes in the public API

#### GroupDocs.Viewer.FileType

Three new fields added to [GroupDocs.Viewer.FileType](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype>) class that reflect new file formats that we're supporting starting from v20.8.

```csharp
/// <summary>
/// Scalable Vector Graphics File (.svgz) is a Scalar Vector Graphics file that uses XML based text format, compressed by GZIP for describing the appearance of an image.
/// Learn more about this file format <a href="https://fileinfo.com/extension/svgz">here</a>
/// </summary>
public static readonly FileType SVGZ = new FileType("Compressed Scalable Vector Graphics File", ".svgz")

/// <summary>
/// Lotus Notes Database (.nsf)
/// Learn more about this file format <a href="https://fileinfo.com/extension/nsf">here</a>.
/// </summary>
public static readonly FileType NSF = new FileType("Lotus Notes Database", ".nsf")
```

#### GroupDocs.Viewer.Options.LotusNotesOptions

public class [LotusNotesOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/lotusnotesoptions>) class added to GroupDocs.Viewer.Options namespace. This class provides options for rendering Lotus Notes data files.

```csharp
/// <summary>
/// Provides options for rendering Lotus Notes data files.
/// </summary>
public class LotusNotesOptions
{
    /// <summary>
    /// The keywords used to filter messages.
    /// </summary>
    public string TextFilter { get; set; }

    /// <summary>
    /// The email-address used to filter messages by sender or recipient.
    /// </summary>
    public string AddressFilter { get; set; }

    /// <summary>
    /// The maximum number of messages or items for render.
    /// </summary>
    /// <remarks>
    /// Lotus notes data files can be large and retrieving all messages can take significant time.
    /// This setting limits maximum number of messages or items that are rendered.
    /// Default value is 0 - all messages will be rendered
    /// </remarks>
    public int MaxItems { get; set; } = 0;
}
```
