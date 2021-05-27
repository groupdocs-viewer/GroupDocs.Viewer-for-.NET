---
id: groupdocs-viewer-for-net-21-5-release-notes
url: viewer/net/groupdocs-viewer-for-net-21-5-release-notes
title: GroupDocs.Viewer for .NET 21.5 Release Notes
weight: 115
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 21.5"
keywords: release notes, groupdocs.viewer, .net, 21.5
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 21.5{{< /alert >}}

## Major Features

There are 15 features, improvements, and bug-fixes in this release, most notable are:

* Support rendering of VCF files that contain contacts list - now VCF with multiple contacts are supported
* Improve rendering performance for files without header - for CAD files
* [Optimize output HTML for printing]({{< ref "viewer/net/developer-guide/advanced-usage/how-to/how-to-optimize-output-html-for-printing.md">}})
* Render spreadsheets similar to Excel (by page breaks) by default

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-2478|Optimize output HTML for printing|Feature|
|VIEWERNET-3224|Support rendering of VCF files that contain contacts list|Feature|
|VIEWERNET-3240|Improve rendering performance for files without header|Improvement|
|VIEWERNET-3277|Render spreadsheets similar to Excel (by page breaks) by default|Improvement|
|VIEWERNET-3278|Add factory methods without parameters to ViewInfoOptions|Improvement|
|VIEWERNET-3279|Add utility method to retrieve filetype by filename or filepath|Improvement|
|VIEWERNET-3134|"Failed to render CAD document into PDF." exception when rendering DWF file"|Bug|
|VIEWERNET-3142|Long conversion time to HTML for certain DOC file|Bug|
|VIEWERNET-3182|"Arithmetic operation resulted in an overflow." exception when rendering CDR file"|Bug|
|VIEWERNET-3199|"The added or subtracted value results in an un-representable DateTime. (Parameter 'value') exception" when try to get info from specific MPX file"|Bug|
|VIEWERNET-3235|Could not load file. File is corrupted or damaged exception when rendering TGA|Bug|
|VIEWERNET-2471|"File is corrupted or damaged" exception when rendering IFC file"|Bug|
|VIEWERNET-2908|PDF to HTML conversion: overlapping text and text out of place in the output|Bug|
|VIEWERNET-3223|Viewer - html files with erroneous css class|Bug|
|VIEWERNET-3237|Empty image when rendering spreadsheet and ignoring empty rows and columns|Bug|

## Public API and Backward Incompatible Changes

### Public API Changes

### GroupDocs.Viewer.FileType class

Added utility method to get FileType from filename or filepath

```cs
/// <summary>
/// Extracts file extension and maps it to file type.
/// </summary>
/// <param name="filePath">The file name or file path.</param>
/// <returns>When file type is supported returns it, otherwise returns default <see cref="Unknown"/> file type.</returns>
public static FileType FromFilePath(string filePath)
```

### GroupDocs.Viewer.Options.BaseViewOptions class

The default value of `BaseViewOptions.SpreadsheetOptions` has been changed from

```cs
/// <summary>
/// The spreadsheet files view options.
/// </summary>
public SpreadsheetOptions SpreadsheetOptions { get; set; } = SpreadsheetOptions.ForSplitSheetIntoPages(40);
```

to

```cs
/// <summary>
/// The spreadsheet files view options.
/// </summary>
public SpreadsheetOptions SpreadsheetOptions { get; set; } = SpreadsheetOptions.ForRenderingByPageBreaks();
```

We've changed default value to make the output similar to the output you can get when printing spreadsheet in Excel. See [Render spreadsheets by page breaks](https://docs.groupdocs.com/viewer/net/render-spreadsheets-by-page-breaks/) for more details.

### GroupDocs.Viewer.Options.ViewInfoOptions class

Added three factory methods without parameters:

```cs
/// <summary>
/// Initializes new instance of <see cref="ViewInfoOptions"/> class to retrieve information about view when rendering into HTML.
/// </summary>
/// <returns>New instance of <see cref="ViewInfoOptions"/> class.</returns>
public static ViewInfoOptions ForHtmlView()

/// <summary>
/// Initializes new instance of <see cref="ViewInfoOptions"/> class to retrieve information about view when rendering into JPG.
/// </summary>
/// <returns>New instance of <see cref="ViewInfoOptions"/> class.</returns>
public static ViewInfoOptions ForJpgView()


/// <summary>
/// Initializes new instance of <see cref="ViewInfoOptions"/> class to retrieve information about view when rendering into PNG.
/// </summary>
/// <returns>New instance of <see cref="ViewInfoOptions"/> class.</returns>
public static ViewInfoOptions ForPngView()
```

### GroupDocs.Viewer.Options.HtmlViewOptions class

[GroupDocs.Viewer.Options.HtmlViewOptions.ForPrinting](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/htmlviewoptions/properties/forprinting>) property was added that add optimize output HTML for printing support.

### Removed obsolete members

* LotusNotesOptions property removed from [GroupDocs.Viewer.Options.BaseViewOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/baseviewoptions>) class.
* RenderSinglePage property removed from [GroupDocs.Viewer.Options.HtmlViewOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/HtmlViewOptions>) class,
please use [GroupDocs.Viewer.Options.HtmlViewOptions.RenderToSinglePage](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/htmlviewoptions/properties/rendertosinglepage>) property.
* LotusNotesOptions class removed from GroupDocs.Viewer.Options namespace.
