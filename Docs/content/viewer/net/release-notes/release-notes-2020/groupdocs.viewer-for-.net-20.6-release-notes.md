---
id: groupdocs-viewer-for-net-20-6-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-6-release-notes
title: GroupDocs.Viewer for .NET 20.6 Release Notes
weight: 70
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.6{{< /alert >}}

## Major Features  
There are 19 features, improvements, and bug-fixes in this release, most notable are:
*   [Fixed High RAM consumption issue when rendering a large text file]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-text-files/how-to-convert-and-view-txt-files.md">}})
*   [Improved rendering Outlook files (pst, ost) to HTML]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-outlook-data-files/how-to-convert-and-view-ost-and-pst-files.md">}})
*   [Show spreadsheet column headings and row numbers]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-excel-spreadsheets/how-to-show-spreadsheet-column-and-row-headings.md" >}}) was implemented for all options
*   [Support file format detection for passed stream]({{< ref "viewer/net/developer-guide/basic-usage/how-to-determine-file-type.md">}})
*   [Get sheet names from an Excel file]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-excel-spreadsheets/how-to-get-the-names-of-the-worksheets.md">}})

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-2485 | Get sheet names from an Excel file | Feature |
| VIEWERNET-2222 | Show spreadsheet column headings and row numbers | Feature |
| VIEWERNET-2474 | Support file format detection for passed stream | Feature |
| VIEWERNET-2468 | Improved rendering Outlook files (pst, ost) to HTML | Improvement |
| VIEWERNET-2434 | High RAM consumption issue when rendering a large text file | Bug |
| VIEWERNET-2466 | Rendering Archive to PDF does not show certain characters | Bug |
| VIEWERNET-2473 | Exception is thrown when rendering SVG file | Bug |
| VIEWERNET-2476 | Exception: A generic error occurred in GDI+ | Bug |
| VIEWERNET-2480 | "Image export failed" exception when rendering WMF file | Bug |
| VIEWERNET-2494 | Input string was not in a correct format" exception when rendering XLSX | Bug |
| VIEWERNET-2495 | "A generic error occurred in GDI+" exception occurs when rendering VSDX file | Bug |
| VIEWERNET-2496 | "Parameter is not valid" exception when rendering VSDX file | Bug |
| VIEWERNET-2497 | "Unable to read beyond the end of the stream" exception when rendering ICO file | Bug |
| VIEWERNET-2503 | "File is corrupted or damaged" exception when rendring CSV file | Bug |
| VIEWERNET-2504 | "A generic error occurred in GDI+" exception occurs when rendering ICO file | Bug |
| VIEWERNET-2505 | Exception: Invalid start row index on XLSB file | Bug |
| VIEWERNET-2529 | HTML representation generating stuck | Bug |
| VIEWERNET-2533 | The row index should not be inside the pivottable report | Bug |
| VIEWERNET-2532 | Not null and not empty string is expected | Bug |

## Public API and Backward Incompatible Changes

### GroupDocs.Viewer.FileType
Two new methods added to the FileType class. The more details and use cases can be found in How to determine file type documentation article.

```csharp
/// <summary>Detects file type by reading the file signature.</summary>
/// <param name="stream">The file stream.</param>
/// <returns>Returns file type in case it was detected successfully otherwise returns default <see cref="F:GroupDocs.Viewer.FileType.Unknown" /> file type.</returns>
public static FileType FromStream(Stream stream)
 
/// <summary>Detects file type by reading the file signature.</summary>
/// <param name="stream">The file stream.</param>
/// <param name="password">The password to open the file.</param>
/// <returns>Returns file type in case it was detected successfully otherwise returns default <see cref="F:GroupDocs.Viewer.FileType.Unknown" /> file type.</returns>
public static FileType FromStream(Stream stream, string password)
```

### GroupDocs.Viewer.Results.Page
Three constructors have been added to the Page class to support retrieving worksheet or page names that is described in How to get the names of the worksheets.

```csharp
/// <summary>
/// Initializes new instance of <see cref="Page"/> class.
/// </summary>
/// <param name="number">The page number.</param>
/// <param name="name">The worksheet or page name.</param>
/// <param name="visible">The page visibility indicator.</param>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="number"/> is less or equal to zero.</exception>
public Page(int number, string name, bool visible)
 
/// <summary>
/// Initializes new instance of <see cref="Page"/> class.
/// </summary>
/// <param name="number">The page number.</param>
/// <param name="name">The worksheet or page name.</param>
/// <param name="visible">The page visibility indicator.</param>
/// <param name="width">The width of the page in pixels when viewing as JPG or PNG.</param>
/// <param name="height">The height of the page in pixels when viewing as JPG or PNG.</param>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="number"/> is less or equal to zero.</exception>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="width"/> is less or equal to zero.</exception>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="height"/> is less or equal to zero.</exception>
public Page(int number, string name, bool visible, int width, int height)
 
/// <summary>
/// Initializes new instance of <see cref="Page"/> class.
/// </summary>
/// <param name="number">The page number.</param>
/// <param name="name">The worksheet or page name.</param>
/// <param name="visible">The page visibility indicator.</param>
/// <param name="width">The width of the page in pixels when viewing as JPG or PNG.</param>
/// <param name="height">The height of the page in pixels when viewing as JPG or PNG.</param>
/// <param name="lines">The lines contained by the page when viewing as JPG or PNG with enabled Text Extraction.</param>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="number"/> is less or equal to zero.</exception>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="width"/> is less or equal to zero.</exception>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="height"/> is less or equal to zero.</exception>
/// <exception cref="System.ArgumentNullException">Thrown when <paramref name="lines"/> is null.</exception>
public Page(int number, string name, bool visible, int width, int height, IList<Line> lines)
```