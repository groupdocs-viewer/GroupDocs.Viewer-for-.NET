---
id: groupdocs-viewer-for-net-21-2-release-notes
url: viewer/net/groupdocs-viewer-for-net-21-2-release-notes
title: GroupDocs.Viewer for .NET 21.2 Release Notes
weight: 119
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 21.2"
keywords: release notes, groupdocs.viewer, .net, 21.2
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 21.2{{< /alert >}}

## Major Features

There are 51 features, improvements, and bug-fixes in this release, most notable are:

* Email Mailbox File (.mbox) file-format support
* [Time Format and TimeZone setting when rendering Email documents to HTML]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-e-mail-messages/datetime-format-and-time-zone-when-rendering-to-html.md">}})
* [Render spreadsheet by page breaks]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-excel-spreadsheets/render-by-page-breaks.md">}})
* [Support MaxHeight and MaxWidth options when rendering to JPG/PNG]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/set-output-image-size-limits.md">}})
* [Support for PC3 file printer configuration when rendering CAD formats]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-cad-drawings/how-to-apply-pc3-config-file.md">}})
* Render presentations documents to single-page HTML
* Add support of rendering text in PDF files as images
* Support play/stop animation when rendering APNG images
* Support play/stop animation when rendering GIF images

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-3070|Render spreadsheet by page breaks|Feature|
|VIEWERNET-3068|Render presentations documents to single page HTML|Feature|
|VIEWERNET-3050|Add support of rendering text in PDF files as images|Feature|
|VIEWERNET-3043|Support for PC3 file printer configuration when rendering CAD formats|Feature|
|VIEWERNET-3039|Support MaxHeight and MaxWidth options when rendering to JPG/PNG|Feature|
|VIEWERNET-3009|Support play/stop animation when rendering APNG images|Feature|
|VIEWERNET-3006|Time Format and TimeZone setting when rendering Email documents to HTML|Feature|
|VIEWERNET-3003|Add Email Mailbox File (.mbox) file-format support|Feature|
|VIEWERNET-2316|Support play/stop animation when rendering GIF images|Feature|
|VIEWERNET-3069|Visio to PDF rendering - output lacks a lot of text|Bug|
|VIEWERNET-3058|Replacing the default font doesn't work on Linux|Bug|
|VIEWERNET-3057|Missing Polish signs in EML to HTML or PDF rendering|Bug|
|VIEWERNET-3055|Replacing the default font doesn't work on Linux|Bug|
|VIEWERNET-3047|Incorrect image dimensions for VCF files|Bug|
|VIEWERNET-3046|Freezes on format-detection|Bug|
|VIEWERNET-3045|Incorrect image dimensions for Archive files|Bug|
|VIEWERNET-3044|GetViewInfo returns small page dimensions for Visio files|Bug|
|VIEWERNET-3002|"The number greater than zero is expected. (Parameter 'width')" exception when rendering VSDX file"|Bug|
|VIEWERNET-2996|"Image export failed." exception when rendering EMF file"|Bug|
|VIEWERNET-2990|"The number greater than zero is expected. (Parameter 'width')" exception when rendering DWG file"|Bug|
|VIEWERNET-2989|"The number greater than zero is expected. (Parameter 'width')" exception when rendering DXF file"|Bug|
|VIEWERNET-2985|Performance drop in rendering word processing files to HTML|Bug|
|VIEWERNET-2936|Specific DWF file is rendering too long.|Bug|
|VIEWERNET-2929|"Arithmetic operation resulted in an overflow." exception when rendering DOCX file"|Bug|
|VIEWERNET-2928|"Could not load file. File is corrupted or damaged." exception when rendering DXF file"|Bug|
|VIEWERNET-2922|"Image export failed." exception when rendering JP2 file"|Bug|
|VIEWERNET-2919|Parameter is not valid. for cdr file|Bug|
|VIEWERNET-2910|"Could not load file. File is corrupted or damaged." exception when rendering IFC file"|Bug|
|VIEWERNET-2909|"The number greater than zero is expected. (Parameter 'width')" exception when rendering CMX file"|Bug|
|VIEWERNET-2876|The image is blank when rendering a specific DWG file to PNG in Linux (docker container).|Bug|
|VIEWERNET-2875|The output image is blank when converting a specific STL file to PNG.|Bug|
|VIEWERNET-2874|Jpeg quality option does not work when rendering CAD files to JPEG in Linux docker containers.|Bug|
|VIEWERNET-2864|"The number greater than zero is expected. (Parameter 'width')" exception when rendering DWF file"|Bug|
|VIEWERNET-2863|Parameter is not valid. for AutoCad file|Bug|
|VIEWERNET-2862|"CAD document rendering failed.Please check that CadOptions sizing options do not have too low or too high values." exception when rendering DGN file"|Bug|
|VIEWERNET-2860|"The number greater than zero is expected. (Parameter 'width')" exception when rendering DWF file"|Bug|
|VIEWERNET-2853|"Could not load file. File is corrupted or damaged." exception when rendering IFC file"|Bug|
|VIEWERNET-2847|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-2846|"Could not load file. File is corrupted or damaged." exception when rendering IFC file"|Bug|
|VIEWERNET-2840|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-2837|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-2836|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-2835|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-2834|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-2833|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-2816|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-2762|"Certain Excel to HTML conversion, alignment issues"|Bug|
|VIEWERNET-2752|"GroupDocs.Viewer throws GroupDocsViewerException  "Image export failed" exception when rendering specific Corel Metafile exchange (cmx) file"|Bug|
|VIEWERNET-2713|Could not load file. File is corrupted or damaged when rendering DWF file|Bug|
|VIEWERNET-2689|StackOverFlow error|Bug|
|VIEWERNET-2475|Exception: Failed to render CAD document into PDF|Bug|

## Public API and Backward Incompatible Changes

### Public API Changes

public interface [IMaxSizeOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/imaxsizeoptions>) interface added to GroupDocs.Viewer.Options. This interface provides MaxSize options for rendering to PNG/JPG output.

```csharp

/// <summary>
/// Limits of image size options interface. 
/// </summary>
public interface IMaxSizeOptions
{
   /// <summary>
   /// Max width of an output image in pixels.
   /// </summary>
   int MaxWidth { get; set; }

   /// <summary>
   /// Max height of an output image in pixels.
   /// </summary>
   int MaxHeight { get; set; }
}
```

#### GroupDocs.Viewer.FileType

Fields were added to [GroupDocs.Viewer.FileType](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype>) class that reflects new file formats that we're supporting starting from v21.2.

```csharp
/// <summary>
/// Email Mailbox File (.mbox)
/// Learn more about this file format <a href="https://fileinfo.com/extension/mbox">here</a>. 
/// </summary>
public static readonly FileType MBOX = new FileType("Email Mailbox File", ".mbox");
```

#### GroupDocs.Viewer.Options

Fields were added to [GroupDocs.Viewer.Options.PngViewOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/pngviewoptions>) class and to
[GroupDocs.Viewer.Options.JpgViewOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/jpgviewoptions>) class that reflects MaxSize options for rendering to PNG/JPG output that we're supporting starting from v21.2.
Both classes now implement inteface [IMaxSizeOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/imaxsizeoptions>).

```csharp
/// <summary>
/// Max width of an output image in pixels.
/// </summary>
public int MaxWidth { get; set; }

/// <summary>
/// Max height of an output image in pixels.
/// </summary>
public int MaxHeight { get; set; }
```

### GroupDocs.Viewer.Options.SpreadsheetOptions class

[GroupDocs.Viewer.Options.SpreadsheetOptions.ForRenderingByPageBreaks](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/spreadsheetoptions/methods/forrenderingbypagebreaks>) method was added that add support for split Excel sheets by page breaks when rendering.

### GroupDocs.Viewer.Options.CadOptions class

[GroupDocs.Viewer.Options.CadOptions.Pc3File](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/cadoptions/properties/pc3file>) property was added that add support to apply PC3 configuration plotter file when rendering CAD files.

### GroupDocs.Viewer.Options.EmailOptions class

Properties were added to [GroupDocs.Viewer.Options.EmailOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/emailoptions>) class that adds support to set time zone offset and date-time format when rendering E-mail messages to HTML.

```csharp
/// <summary>
/// Time Format (can be include TimeZone)
/// for example: 'MM d yyyy HH:mm tt', if not set - current system format is used
/// </summary>
public string DateTimeFormat { get; set; }

/// <summary>
/// Message time zone offset
/// </summary>
public TimeSpan TimeZoneOffset { get; set; }
```

### Behaviour changes

Now when rendering APNG and GIF to HTML you will get a page with an animated picture. If an animated file contains only one frame, HTML with static image will be generated.

![Animated PNG in HTML](viewer/net/images/apng_animated.gif)
