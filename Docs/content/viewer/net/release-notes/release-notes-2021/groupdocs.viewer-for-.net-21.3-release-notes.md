---
id: groupdocs-viewer-for-net-21-3-release-notes
url: viewer/net/groupdocs-viewer-for-net-21-3-release-notes
title: GroupDocs.Viewer for .NET 21.3 Release Notes
weight: 118
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 21.3"
keywords: release notes, groupdocs.viewer, .net, 21.3
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 21.3{{< /alert >}}

## Major Features

There are ? features, improvements, and bug-fixes in this release, most notable are:

* ...

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-3132|Add FilePath parameter to Attachment class|Feature|

## Public API and Backward Incompatible Changes

### Public API Changes

#### GroupDocs.Viewer.Results.Attachment

The *FilePath* field has been added to [GroupDocs.Viewer.Results.Attachment](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.results/attachment>) class. It is used to keep a relative attachment path or attachment filename.

```csharp
/// <summary>
/// Attachment relative path e.g. <example>folder/file.docx</example> or filename when the file is located in the root of an archive, in e-mail message or data file.
/// </summary>
public string FilePath { get; }
```

In addition, all three *Attachment* class constructors have been updated to accept the *FilePath* parameter.
