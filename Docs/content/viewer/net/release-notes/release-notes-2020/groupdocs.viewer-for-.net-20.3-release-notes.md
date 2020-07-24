---
id: groupdocs-viewer-for-net-20-3-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-3-release-notes
title: GroupDocs.Viewer for .NET 20.3 Release Notes
weight: 100
description: "This page contains release notes for GroupDocs.Viewer for .NET 20.3."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Release notes for GroupDocs.Viewer for .NET 20.3

This page contains release notes for GroupDocs.Viewer for .NET 20.3.

## Major Features

There are 9 features, improvements, and bug-fixes in this release, most notable are:

*   Added support of Microsoft Excel 97-2003 Template (.xlt) file format
*   Added new option that enables users to set filename when viewing archive files 

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1898 | Add Microsoft Excel 97-2003 Template (.xlt) file format support | Feature |
| VIEWERNET-2351 | Specify filename when rendering archive files | Feature |
| VIEWERNET-2155 | Reduce margins when rendering LaTeX (.tex) files | Improvement |
| VIEWERNET-2355 | Return unknown file type when passing null or empty string as extension or media type | Improvement |
| VIEWERNET-2356 | Accept attachment object instead of attachment ID | Improvement |
| VIEWERNET-86 | DefaultFontName setting is not working for rendering Word Processing documents into HTML | Bug |
| VIEWERNET-2120 | Page size is 0 for HTML mode | Bug |
| VIEWERNET-2347 | The number greater than zero is expected exception | Bug |
| VIEWERNET-2352 | Output shows compressed file content/data as Compressed Word File | Bug |

## Public API and Backward Incompatible Changes

### Changes in GroupDocs.Viewer.FileType class

public static readonly FileType XLT = new FileType("Microsoft Excel Template", ".xlt"); field added

Microsoft Excel Template (.xlt)

public static FileType FromExtension(string extension) method behavior changed

This method now accepts *null* or *empty* string and returns *FileType.Unknown* file type instead of throwing *InvalidArgumentException*.

public static FileType FromMediaType(string mediaType) method behavior changed

This method now accepts *null* or *empty* string and returns *FileType.Unknown* file type instead of throwing *InvalidArgumentException*.

### Changes in GroupDocs.Viewer.Options.ArchiveOptions class

public FileName FileName { get; set; } property added

The filename to display in the header. By default, the name of the source file is displayed.

### Changes in GroupDocs.Viewer.Options.FileName class

public class FileName class added

This class represents the name of the file.

```csharp
/// <summary>
/// The filename.
/// </summary>
public class FileName
{
    internal string Text { get; }
 
    /// <summary>
    /// The empty filename.
    /// </summary>
    public static readonly FileName Empty = new FileName("<empty>");
 
    /// <summary>
    /// The name of the source file.
    /// </summary>
    public static readonly FileName Source = new FileName("<source>");
 
    /// <summary>
    /// Initializes new instance of <see cref="FileName"/> class.
    /// </summary>
    /// <param name="fileName">The name of the file.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="fileName"/> is null.</exception>
    public FileName(string fileName)
    {
        if (fileName == null)
            throw new ArgumentNullException(nameof(fileName));
        Text = fileName;
    }
 
    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return Text;
    }
}
```

### Changes in GroupDocs.Viewer.Results.Attachment class

public Attachment(string fileName) constructor added

Initializes new instance of Attachment class.

```csharp
/// <summary>
/// Initializes new instance of <see cref="Attachment"/> class.
/// </summary>
/// <param name="fileName">Attachment file name.</param>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="fileName"/> is null or empty.</exception>
public Attachment(string fileName)
```

### Changes in GroupDocs.Viewer.Viewer class

public Viewer(String filePath, Common.Func<LoadOptions> getLoadOptions) constructor has been removed 

Please switch to the constructor that accepts LoadOptions object instead of factory method.

Viewer(String filePath, Common.Func<LoadOptions> getLoadOptions, ViewerSettings settings) constructor has been removed

Please switch to the constructor that accepts LoadOptions object instead of factory method.

public void SaveAttachment(string attachmentId, Stream destination) method set as obsolete

This method is obsolete and will removed in June 2020 (v20.6). Please switch to the method that accepts Attachment as a first parameter.

public void SaveAttachment(Attachment attachment, Stream destination) method added

Saves attachment file to the destination stream.

```csharp
/// <summary>
/// Saves attachment file to <paramref name="destination"/> stream.
/// </summary>
/// <param name="attachment">The attachment.</param>
/// <param name="destination">The writable stream.</param>
/// <exception cref="System.ArgumentNullException">Thrown when <paramref name="attachment"/> is null.</exception>
/// <exception cref="System.ArgumentNullException">Thrown when <paramref name="destination"/> is null.</exception>
/// <exception cref="Exceptions.PasswordRequiredException">Thrown when password is required to open the document.</exception>
/// <exception cref="Exceptions.IncorrectPasswordException">Thrown when password that was specified is incorrect.</exception>
/// <exception cref="Exceptions.GroupDocsViewerException">Thrown when attachment could not be found.</exception>
public void SaveAttachment(Attachment attachment, Stream destination)
```

