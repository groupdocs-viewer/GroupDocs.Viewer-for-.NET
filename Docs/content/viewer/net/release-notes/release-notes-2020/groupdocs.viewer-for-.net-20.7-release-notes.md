---
id: groupdocs-viewer-for-net-20-7-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-7-release-notes
title: GroupDocs.Viewer for .NET 20.7 Release Notes
weight: 60
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 20.7"
keywords: release notes, groupdocs.viewer, .net, 20.7
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.7{{< /alert >}}

## Major Features  

There are ? features, improvements, and bug-fixes in this release, most notable are:

* List

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET- | Description | Feature or Improvement or Bug |

## Public API and Backward Incompatible Changes

### GroupDocs.Viewer.Options.SpreadsheetOptions

The new factory method has been added to support partial rendering of Excel spreadsheets by splitting worksheets into pages by rows and columns. See [Split worksheets into pages]({{< ref "split-worksheets-into-pages.md" >}}) documentation article for more details and code samples.

```csharp
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