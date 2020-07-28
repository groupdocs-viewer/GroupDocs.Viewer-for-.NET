---
id: groupdocs-viewer-for-net-20-7-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-7-release-notes
title: GroupDocs.Viewer for .NET 20.7 Release Notes
weight: 57
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 20.7"
keywords: release notes, groupdocs.viewer, .net, 20.7
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.7{{< /alert >}}

## Major Features  

There are 31 features, improvements, and bug-fixes in this release, most notable are:

* [Support setting margins when converting HTML files]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-web-documents/how-to-convert-and-view-html-files-with-margins.md">}})
* [Rendering text files into a single HTML page]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-text-files/how-to-convert-and-view-txt-files.md#convert-txt-to-html">}})
* [Excel 2003 XML file (SpreadsheetML) (.xml) file-format support]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-excel-spreadsheets/how-to-convert-and-view-excel-spreadsheetml-files.md">}})
* [Apple numbers (.numbers) file-format support]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-excel-spreadsheets/how-to-convert-and-view-apple-numbers-files.md">}})
* WinRAR Compressed Archive (.rar) file-format support
* [Split up archives into multiple pages]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-archive-files/how-to-convert-and-view-archive-files.md#convert-archive-files-to-multiple-pages-html">}})
* [How to check if a file is encrypted]({{< ref "viewer/net/developer-guide/basic-usage/how-to-check-if-file-is-encrypted.md">}})

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-2219|Rendering text files into single HTML page|Feature|
|VIEWERNET-2492|Support setting margins when converting HTML files|Feature|
|VIEWERNET-2509|Add WinRAR Compressed Archive (.rar) file-format support|Feature|
|VIEWERNET-2535|Split up archives into multiple pages|Feature|
|VIEWERNET-2549|Add feature to identify File is Password Protected|Feature|
|VIEWERNET-2575|Add Apple numbers (.numbers) file-format support|Feature|
|VIEWERNET-2578|Add Excel 2003 XML file (SpreadsheetML) (.xml) file-format support|Feature|
|VIEWERNET-2181|Images are missing when rendering Excel as HTML/image/PDF|Bug|
|VIEWERNET-2217|AutoCad rendering issue|Bug|
|VIEWERNET-2348|Cannot access a disposed object error when disposing the Viewer |Bug|
|VIEWERNET-2465|Exception: Image export failed |Bug|
|VIEWERNET-2470|"Image export failed" exception when rendering EMF file"|Bug|
|VIEWERNET-2484|GetViewInfo consumes a lot of memory |Bug|
|VIEWERNET-2498|Overflow error on VSDX file|Bug|
|VIEWERNET-2501|Partial Worksheet rendering issue|Bug|
|VIEWERNET-2530|File damaged or corrupted error|Bug|
|VIEWERNET-2537|Unable to cast object of type double to string|Bug|
|VIEWERNET-2543|VDX and VSS files rendered incorrectly|Bug|
|VIEWERNET-2544|XLSM file can't be viewed|Bug|
|VIEWERNET-2573|"File is corrupted or damaged" exception when rendring XLS file"|Bug|
|VIEWERNET-2574|Determine attached file extension in EML|Bug|
|VIEWERNET-2580|Exception is thrown when rendering XLSX file|Bug|
|VIEWERNET-2590|"Parameter is not valid" exception when rendering VSD file"|Bug|
|VIEWERNET-2596|Out of memory exception|Bug|
|VIEWERNET-2610|Can't view ICO file|Bug|
|VIEWERNET-2611|Can't get document info for ICO|Bug|
|VIEWERNET-2631|Exception is thrown when rendering VDX file|Bug|
|VIEWERNET-2637|Application never exits when converting SVG to PNG/JPG on Linux|Bug|
|VIEWERNET-2638|Application never exits when converting EMF to HTML on Linux|Bug|
|VIEWERNET-2639|Blank image when converting EMF to PNG on Linux|Bug|
|VIEWERNET-2640|Invalid row index|Bug|

## Public API and Backward Incompatible Changes

### Behavior changes

* In this version we've improved viewing of archives and text files - now it could be rendered to multiple/single pages, they are rendered to multiple pages by default

### Changes in the public API

#### GroupDocs.Viewer.Options.ArchiveOptions

Added new property to GroupDocs.Viewer.Options.CadOptions](<https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/archiveoptions>) class

```csharp
/// <summary>
/// Number of records per page (for rendering to HTML only)
/// </summary>
public int ItemsPerPage { get; set; }

```

#### GroupDocs.Viewer.Options.HtmlViewOptions

Added new property to GroupDocs.Viewer.Options.htmlviewoptions](<https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions>) class

```csharp
/// <summary>
/// Enables HTML content will be rendered to single page
/// </summary>
public bool RenderSinglePage { get; set; }
```

#### GroupDocs.Viewer.FileType

Added new fields to GroupDocs.Viewer.Options.htmlviewoptions](<https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/filetype>) class

```csharp
/// <summary>
/// Roshal ARchive (.rar) are compressed files generated using the RAR (WINRAR) compression method.
/// Learn more about this file format <a href="https://wiki.fileformat.com/compression/rar">here</a>.
/// </summary>
public static readonly FileType RAR = new FileType("Rar Compressed File", ".rar");

/// <summary>
/// Excel 2003 XML (SpreadsheetML) represents Excel Binary File Format. Such files can be created by Microsoft Excel as well as other similar spreadsheet programs such as OpenOffice Calc or Apple Numbers.
/// Learn more about this file format <a href="https://wiki.fileformat.com/spreadsheet/xls">here</a>.
/// </summary>
public static readonly FileType Excel2003XML = new FileType("Excel 2003 XML (SpreadsheetML)", ".xml");

/// <summary>
/// Apple numbers represent Excel-like Binary File Format. Such files can be created by Apple numbers application.
/// Learn more about this file format <a href="https://fileinfo.com/extension/numbers">here</a>.
/// </summary>
public static readonly FileType NUMBERS = new FileType("Apple numbers", ".numbers");

```

#### GroupDocs.Viewer.Options.SpreadsheetOptions

Added new property and one method to GroupDocs.Viewer.Options.htmlviewoptions](<https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/spreadsheetoptions>) class

```csharp
/// <summary>
/// The columns count to include into each page when splitting worksheet into pages.
/// </summary>
public int CountColumnsPerPage { get; private set; }

/// <summary>
/// Initializes new instance of <see cref="SpreadsheetOptions"/> for rendering sheet into pages.
/// </summary>
/// <param name="countRowsPerPage">Rows count to include into each page.</param>
/// <param name="countColumnsPerPage">Columns count to include into each page.</param>
/// <returns>New instance of <see cref="SpreadsheetOptions"/> for rendering sheet into pages.</returns>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="countRowsPerPage"/> is equals or less than zero.</exception>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="countColumnsPerPage"/> is equals or less than zero.</exception>
public static SpreadsheetOptions ForSplitSheetIntoPages(int countRowsPerPage, int countColumnsPerPage)
```

#### GroupDocs.Viewer.Options.WordProcessingOptions

Added new properties to GroupDocs.Viewer.Options.htmlviewoptions](<https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/wordprocessingoptions>) class

```csharp
/// <summary>
/// Left page margin (for HTML rendering only)
/// </summary>
public float LeftMargin { get; set; }

/// <summary>
/// Right page margin (for HTML rendering only)
/// </summary>
public float RightMargin { get; set; }

/// <summary>
/// Top page margin (for HTML rendering only)
/// </summary>
public float TopMargin { get; set; }

/// <summary>
/// Bottom page margin (for HTML rendering only)
/// </summary>
public float BottomMargin { get; set; }

```
