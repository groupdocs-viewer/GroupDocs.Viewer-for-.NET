---
id: groupdocs-viewer-for-net-16-11-release-notes
url: viewer/net/groupdocs-viewer-for-net-16-11-release-notes
title: GroupDocs.Viewer For .NET 16.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}
This page contains release notes for [GroupDocs.Viewer for .NET 16.11.0](http://downloads.groupdocs.com/viewer/net/new-releases/groupdocs.viewer-for-.net-16.11.0/).
{{< /alert >}}

## Major Features

There are 2 new features and 15 improvements and fixes in this regular monthly release. The most notable are:

*   Ability to set default font when rendering Email documents
*   OTP (OpenDocument Presentation Template) file format viewing support
*   Improved public API of ViewerConfig class and IInputDataHandler interface
*   When viewing two documents in one browser page CSS classes are not overriding

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-955 | Ability to set default font when rendering Email documents | New Feature |
| VIEWERNET-849 | Add OTP format support | New Feature |
| VIEWERNET-966 | Improve public API of ViewerConfig class | Improvement |
| VIEWERNET-963 | Improve rendering CAD (dwg, dxf) documents to Pdf | Improvement |
| VIEWERNET-957 | Improve public API of IInputDataHandler interface | Improvement |
| VIEWERNET-927 | Display HTML pages of two different documents in the same page in browser without overriding css classes | Improvement |
| WEB-2447 | The background is missed for IE 11 | Bug |
| WEB-2109 | Special characters like accents, umlauts and circumflex are displayed incorrectly when saving specific PDF to HTML | Bug |
| WEB-1398 | A ligature is shown incorrectly in HTML produced from PDF | Bug |
| VIEWERNET-979 | Invalid characters while rendering Word document into HTML | Bug |
| VIEWERNET-958 | Throws unsupported file format exception when loading specific doc file | Bug |
| VIEWERNET-956 | Getting exception "File type 'doc' is not supported" | Bug |
| VIEWERNET-949 | Parameter is not valid exception when rendering xlsx to image | Bug |
| VIEWERNET-877 | Extra blank page created when convering dwg to pdf. | Bug |
| VIEWERNET-848 | Failed to convert wmf file to image in Asp.Net application. | Bug |
| VIEWERNET-847 | Incorrect Rendering of Radio Buttons, Checkboxes and their Label into Html | Bug |
| VIEWERNET-775 | No text when converting Pdf to Html with FontAbsorber | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}
**LoadFileTree** method is obsolete starting from version 16.11.0 and it is replaced with **GetFileList** method.  
**GetFileList** method retrieves files and directories for specified path (or GroupDocs.Viewer's storage path) and works identically in **ViewerImageHandler** and **ViewerHtmlHandler**
{{< /alert >}}

### Ability to set default font when rendering Email documents

Default font name may be specified in this cases:

1.  You want to generally specify the default font to fall back on if a particular font in a document cannot be found during rendering.
2.  Your document uses fonts that contain non-English characters and you want to make sure any missing font is replaced with one that has the same character set available.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
config.DefaultFontName = "Calibri";


```

### Improved Public APIs

1.  Improve public API of ViewerConfig classPublic API changes:
    1.  Class *GroupDocs.Viewer.Config.ViewerConfig* property *public string TempFolderName* marked as 'Obsolete'
    2.  Class *GroupDocs.Viewer.Config.ViewerConfig* property *public string TempPath* marked as 'Obsolete'
2.  Improve public API of IInputDataHandler interface Public API changes:
    1.  Class *ViewerImageHandler/ViewerHtmlHandler* method *FileListContainer GetFileList()* added
    2.  Class\_ViewerImageHandler/ViewerHtmlHandler\_ method *GetFileList(FileListOptions fileListOptions)* added
    3.  Class *ViewerImageHandler/ViewerHtmlHandler* method *FileTreeContainer LoadFileTree()* marked as 'Obsolete'
    4.  Class *ViewerImageHandler/ViewerHtmlHandler* method *FileTreeContainer LoadFileTree(FileTreeOptions fileTreeOptions)* marked as 'Obsolete'
    5.  Class *GroupDocs.Viewer.Domain.Containers.FileTreeContainer* marked as 'Obsolete'
    6.  Class *GroupDocs.Viewer.Domain.Options.FileTreeOptions* marked as 'Obsolete'
    7.  Interface *GroupDocs.Viewer.Handler.Input.IInputDataHandler* method *SaveDocument(CachedDocumentDescription cachedDocumentDescription, Stream documentStream)* marked as 'Obsolete'
    8.  Interface *GroupDocs.Viewer.Handler.Input.IInputDataHandler* method *LoadFileTree(FileTreeOptions fileTreeOptions)* marked as 'Obsolete'
    9.  Interface *GroupDocs.Viewer.Handler.Input.IInputDataHandler* method *void AddFile(string guid, Stream content)* added
    10.  Interface *GroupDocs.Viewer.Handler.Input.IInputDataHandler* method *List<FileDescription> GetEntities(string path)* added

### Get file list

{{< alert style="info" >}}LoadFileTree method is obsolete starting from version 16.11.0 and it is replaced with GetFileList method.{{< /alert >}}{{< alert style="info" >}}GetFileList method retrieves files and directories for specified path (or GroupDocs.Viewer's storage path) and works identically in ViewerImageHandler and ViewerHtmlHandler{{< /alert >}}

**Load file list for ViewerConfig.StoragePath**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);

// Load file list for ViewerConfig.StoragePath
FileListContainer container = imageHandler.GetFileList();
foreach (var node in container.Files)
{
    if (node.IsDirectory)
    {
        Console.WriteLine("Guid: {0} | Name: {1} | LastModificationDate: {2}",
            node.Guid,
            node.Name,
            node.LastModificationDate);
    }
    else
        Console.WriteLine("Guid: {0} | Name: {1} | Document type: {2} | File type: {3} | Extension: {4} | Size: {5} | LastModificationDate: {6}",
            node.Guid,
            node.Name,
            node.DocumentType,
            node.FileType,
            node.Extension,
            node.Size,
            node.LastModificationDate);
}


```

**Load file list for custom path**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);

// Load file list for custom path
FileListOptions options = new FileListOptions(@"D:\");
FileListContainer container = imageHandler.GetFileList(options);
foreach (var node in container.Files)
{
    if (node.IsDirectory)
    {
        Console.WriteLine("Guid: {0} | Name: {1} | LastModificationDate: {2}",
            node.Guid,
            node.Name,
            node.LastModificationDate);
    }
    else
        Console.WriteLine("Guid: {0} | Name: {1} | Document type: {2} | File type: {3} | Extension: {4} | Size: {5} | LastModificationDate: {6}",
            node.Guid,
            node.Name,
            node.DocumentType,
            node.FileType,
            node.Extension,
            node.Size,
            node.LastModificationDate);
}


```

**Load file list for custom path with order**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);

// Load file list sorted by Name and ordered Ascending for custom path
FileListOptions options = new FileListOptions(@"D:\", FileListOptions.FileListSortBy.Name, FileListOptions.FileListOrderBy.Ascending);
FileListContainer container = imageHandler.GetFileList(options);
foreach (var node in container.Files)
{
    if (node.IsDirectory)
    {
        Console.WriteLine("Guid: {0} | Name: {1} | LastModificationDate: {2}",
            node.Guid,
            node.Name,
            node.LastModificationDate);
    }
    else
        Console.WriteLine("Guid: {0} | Name: {1} | Document type: {2} | File type: {3} | Extension: {4} | Size: {5} | LastModificationDate: {6}",
            node.Guid,
            node.Name,
            node.DocumentType,
            node.FileType,
            node.Extension,
            node.Size,
            node.LastModificationDate);
}


```
