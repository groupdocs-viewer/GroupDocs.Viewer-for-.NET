---
id: groupdocs-viewer-for-net-21-1-release-notes
url: viewer/net/groupdocs-viewer-for-net-21-1-release-notes
title: GroupDocs.Viewer for .NET 21.1 Release Notes
weight: 120
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 21.1"
keywords: release notes, groupdocs.viewer, .net, 21.1
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 21.1{{< /alert >}}

## Major Features  

There are 9 features, improvements, and bug-fixes in this release, most notable are:

* [AI (Adobe Illustrator) file-format support]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-image-files/how-to-convert-and-view-ai-files.md">}})
* [Microsoft Compiled HTML Help  (CHM) file-format support]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-web-documents/how-to-convert-and-view-chm-files.md">}})
* Add Truevision TGA (TARGA) (tga) file-format support
* Add Animated PNG (apng) file-format support
* Render multipaged PDF to single page HTML

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-280|Support for .ai (Adobe Illustrator) file format|Feature|
|VIEWERNET-2931|Add Microsoft Compiled HTML Help  (CHM) file-format support|Feature|
|VIEWERNET-2949|Render multipaged PDF to single page HTML|Feature|
|VIEWERNET-3008|Add Truevision TGA (TARGA) (tga) file-format support|Feature|
|VIEWERNET-3010|Add Animated PNG (apng) file-format support|Feature|
|VIEWERNET-2934|Add gdv prefix to all CSS class names in custom templates|Improvement|
|VIEWERNET-3018|Add constructors to Viewer class that accept Stream instead of Func\<Stream\>|Improvement|
|VIEWERNET-2950|View DOCX in PDF mode exception: System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.|Bug|
|VIEWERNET-3019|Rename RenderSinglePage property to RenderToSinglePage in HtmlViewOptions|Bug|

## Public API and Backward Incompatible Changes

### Public API Changes

In this version we've simplified public API and added eight new constructors to the [Viewer](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/viewer>) class that accepts _Stream_ instead of _Func\<Stream\>_. The constructors that accept _Func\<Stream\>_ has been marked as obsolete, so please switch to the new constructors as we're planning to remove obsolete one in the future versions.

```csharp
// The following constructors has been added
public Viewer(Stream stream)
public Viewer(Stream stream, bool leaveOpen)
public Viewer(Stream stream, LoadOptions loadOptions)
public Viewer(Stream stream, LoadOptions loadOptions, bool leaveOpen)
public Viewer(Stream stream, ViewerSettings settings)
public Viewer(Stream stream, ViewerSettings settings, bool leaveOpen)
public Viewer(Stream stream, LoadOptions loadOptions, ViewerSettings settings)
public Viewer(Stream stream, LoadOptions loadOptions, ViewerSettings settings, bool leaveOpen)

// The following constructors were marked as obsolete
public Viewer(Common.Func<Stream> getFileStream)
public Viewer(Common.Func<Stream> getFileStream, Common.Func<LoadOptions> getLoadOptions)
public Viewer(Common.Func<Stream> getFileStream, ViewerSettings settings)
public Viewer(Common.Func<Stream> getFileStream, Common.Func<LoadOptions> getLoadOptions, ViewerSettings settings)
```

[GroupDocs.Viewer.Options.LotusNotesOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/lotusnotesoptions>) class set as obsolete.
Please use [MailStorageOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/mailstorageoptions>) class, this class will be replaced at 21.4 version

public class [MailStorageOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/mailstorageoptions>) class added to GroupDocs.Viewer.Options. This class provides view options for
viewing mail storage formats like Lotus Notes (NSF)

```csharp

/// <summary>
/// Provides options for rendering Mail storage (Lotus Notes, MBox) data files.
/// </summary>
public class MailStorageOptions
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

#### GroupDocs.Viewer.FileType

Fields were added to [GroupDocs.Viewer.FileType](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype>) class that reflects new file formats that we're supporting starting from v21.1.

```csharp
/// <summary>
/// Microsoft Compiled HTML Help File (.chm) is a well-known format for HELP (documentation to some application) documents.
/// Learn more about this file format <a href="https://docs.fileformat.com/web/chm/">here</a>. 
/// </summary>
public static readonly FileType CHM = new FileType("Microsoft Compiled HTML Help File", ".chm");

/// <summary>
/// Adobe Illustrator (.ai) is a file format for Adobe Illustrator drawings.
/// Learn more about this file format <a href="https://fileinfo.com/extension/ai#adobe_illustrator_file">here</a>. 
/// </summary>
public static readonly FileType AI = new FileType("Adobe Illustrator", ".ai");

/// <summary>
/// Truevision TGA (Truevision Advanced Raster Adapter - TARGA) is used to store bitmap digital images developed by TRUEVISION.
/// Learn more about this file format <a href="https://wiki.fileformat.com/image/tga">here</a>. 
/// </summary>
public static readonly FileType TGA = new FileType("Truevision TGA (TARGA)", ".tga");

/// <summary>
/// Animated Portable Network Graphic (.apng) is extension of  PNG format that supports animation.
/// Learn more about this file format <a href="https://wiki.fileformat.com/image/apng">here</a>. 
/// </summary>
public static readonly FileType APNG = new FileType("Animated Portable Network Graphic", ".apng");
```

### GroupDocs.Viewer.Options.BaseViewOptions class

[GroupDocs.Viewer.Options.BaseViewOptions.LotusNotesOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/baseviewoptions/properties/lotusnotesoptions>) property set as obsolete.
This option will be replaced by [GroupDocs.Viewer.Options.BaseViewOptions.MailStorageOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/baseviewoptions/properties/mailstorageoptions>) property at 21.4 version.

Fields were added to [GroupDocs.Viewer.Options.BaseViewOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/baseviewoptions>) class that reflects new view options for new file formats that we're supporting starting from v21.1.

```csharp
/// <summary>
/// Lotus Notes storage data files view options.
/// </summary>
public MailStorageOptions MailStorageOptions { get; set; } = new MailStorageOptions();

```

### GroupDocs.Viewer.Options.HtmlViewOptions class

[GroupDocs.Viewer.Options.HtmlViewOptions.RenderSinglePage](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/htmlviewoptions/properties/rendersinglepage>) property set as obsolete.
 This property will be removed at 21.4 release, please use RenderToSinglePage property.

[GroupDocs.Viewer.Options.HtmlViewOptions.RenderToSinglePage](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/htmlviewoptions/properties/rendertosinglepage>) property was added.
