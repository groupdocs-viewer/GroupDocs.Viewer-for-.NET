---
id: groupdocs-viewer-for-net-19-3-release-notes
url: viewer/net/groupdocs-viewer-for-net-19-3-release-notes
title: GroupDocs.Viewer for .NET 19.3 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 19.3.{{< /alert >}}

## Major Features

There are 10 features, improvements, and fixes in this regular monthly release. The most notable are:

*   Added Cs and Vb file formats support
*   Feature for detecting printing restriction in PDF documents, and the ability to print such documents
*   Ability to specify owner password, user password, and permissions when rendering into PDF

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1895 | Add Visual Basic (.vb) file format support | Feature |
| VIEWERNET-1894 | Add C# (.cs) file format support | Feature |
| VIEWERNET-1860 | Obtaining list of folders contained in the zip archive | Feature |
| VIEWERNET-1913 | Detect restriction for the printing | Feature |
| VIEWERNET-1905 | Print PDF documents which have restriction for printing | Feature |
| VIEWERNET-1909 | Specify owner password, user password and permissions when rendering into PDF | Feature |
| VIEWERNET-1858 | Show contact image when rendering vCard documents | Improvement |
| VIEWERNET-1856 | Improve output for rendering zip archives | Improvement |
| VIEWERNET-1911 | Out of memory exception | Bug |
| VIEWERNET-1910 | Document corrupted exception | Bug |

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 19.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### GroupDocs.Viewer.Config.ViewerConfig

#### public string LocalesPath property has been removed 

This property has been removed. GroupDocs.Viewer no longer provides localization supports.

### GroupDocs.Viewer.Converter.Options.ArchiveOptions

**public class ArchiveOptions has been added**  
ArchiveOptions class allows specifying archive documents specific rendering options as explained in the article (given at the end of the page)..

**public string FolderName property has been added**  
FolderName property of the ArchiveOptions class allows specifying the name of the folder inside Archive, to be rendered. More details can be found in the article (given at the end of the page)..

### GroupDocs.Viewer.Converter.Options.HtmlOptions

#### public ArchiveOptions ArchiveOptions property has been added

ArchiveOptions class allows specifying archive documents specific rendering options as explained in the article (given at the end of the page).

### GroupDocs.Viewer.Converter.Options.ImageOptions

#### public string FileExtension property compilation set to fail

This property is obsolete and will be removed after v19.3.

#### public ArchiveOptions ArchiveOptions property has been added

ArchiveOptions class allows specifying archive documents specific rendering options as explained in the article (given at the end of the page).

### GroupDocs.Viewer.Domain.ArchiveFileData

#### public class ArchiveFileData has been added

This class represents archive specific FileData.

### GroupDocs.Viewer.Domain.CachedDocumentDescription

#### public ArchiveOptions ArchiveOptions property has been added

ArchiveOptions class allows specifying archive documents specific rendering options as explained in the article (given at the end of the page).

### GroupDocs.Viewer.Domain.CachedPageDescription

 

#### public ArchiveOptions ArchiveOptions property has been added

ArchiveOptions class allows specifying archive documents specific rendering options as explained in the article (given at the end of the page).

### GroupDocs.Viewer.Domain.Containers.ArchiveDocumentInfoContainer

**ArchiveDocumentInfoContainer** class provides archive documents specific information as explained in the article (given at the end of the page).

### GroupDocs.Viewer.Domain.Containers.PdfDocumentInfoContainer

 

#### public class PdfDocumentInfoContainer class has been added

```csharp
/// <summary>
/// Represents a container for PDF document description.
/// </summary>
public class PdfDocumentInfoContainer : DocumentInfoContainer
{
    /// <summary>
    /// Indicates whether source document has restriction on printing
    /// </summary>
    public bool PrintingAllowed
    {
        get; internal set;
    }
}
```

####   
Check if source PDF document has restriction on printing

Since the version 19.3 GroupDocs.Viewer for .NET API enables to check if PDF document has restriction on printing.

Following example demonstrates how to retrieve document information and check if document has restriction on printing.

**C# (Render document into PDF with security settings)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = @"C:\storage";

// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(viewerConfig);

// Retrieve document information
string guid = "document.pdf";
PdfDocumentInfoContainer documentInfo = imageHandler.GetDocumentInfo(guid) as PdfDocumentInfoContainer;
 
bool printingAllowed = documentInfo.PrintingAllowed;
```

### GroupDocs.Viewer.Domain.Html.HtmlResource

 

#### public ArchiveOptions ArchiveOptions property has been added

ArchiveOptions class allows specifying archive documents specific rendering options as explained in the article (given at the end of the page).

### GroupDocs.Viewer.Domain.Options

 

#### public enum PdfFilePermissions enumeration has been added

```csharp
/// <summary>
/// PDF file permissions
/// </summary>
[Flags]
public enum PdfFilePermissions
{
    /// <summary>
    /// Deny printing, modification and data extraction
    /// </summary>
    None = 0,

    /// <summary>
    /// Allow printing
    /// </summary>
    Printing = 1,

    /// <summary>
    /// Allow to modify content, fill in forms, add or modify annotations
    /// </summary>
    Modification = 2,

    /// <summary>
    /// Allow text and graphics extraction 
    /// </summary>
    DataExtraction = 4,

    /// <summary>
    /// Allow printing, modification and data extraction 
    /// </summary>
    All = Printing | Modification | DataExtraction
}
```

#### public class PdfFileSecurity class has been added

```csharp
/// <summary>
/// Enables to specify owner password, user password and PDF file permissions
/// </summary>
public class PdfFileSecurity
{
    /// <summary>
    /// Owner password enables to set PDF file permissions
    /// </summary>
    public string OwnerPassword { get; }

    /// <summary>
    /// User password restricts opening PDF file
    /// </summary>
    public string UserPassword { get; }

    /// <summary>
    /// PDF file permissions
    /// </summary>
    public PdfFilePermissions PdfFilePermissions { get; }

    /// <summary>
    /// Creates new instance of this class
    /// </summary>
    /// <param name="ownerPassword">Owner password enables to set document permissions</param>
    /// <param name="userPassword">User password restricts opening PDF file</param>
    /// <param name="pdfFilePermissions">PDF file permissions</param>
    public PdfFileSecurity(string ownerPassword, string userPassword, PdfFilePermissions pdfFilePermissions)
    {
        if (ownerPassword == null)
            throw new ArgumentNullException("ownerPassword");
        if (userPassword == null)
            throw new ArgumentNullException("userPassword");
        OwnerPassword = ownerPassword;
        UserPassword = userPassword;
        PdfFilePermissions = pdfFilePermissions;
    }
}
```

#### PdfFileSecurity PdfFileSecurity { get; set; } property has been added to PdfFileOptions class

```csharp
/// <summary>
/// Enables to specify owner password, user password and PDF file permissions
/// </summary>
/// <example>
/// The following example demonstrates how to set owner password and permissions for printing.
/// <code lang="C#">          
/// ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler();
/// PdfFileOptions options = new PdfFileOptions();
/// options.PdfFileSecurity = new PdfFileSecurity("owner password", string.Empty, PdfFilePermissions.Printing);
///
/// string guid = "document.doc";
/// FileContainer fileContainer = htmlHandler.GetPdfFile(guid, options);
/// </code>
/// </example>
public PdfFileSecurity PdfFileSecurity { get; set; }
```

#### Specify owner password, user password and permissions when rendering into PDF

Since the version 19.3 GroupDocs.Viewer for .NET API enables to specify owner password, user password and PDF file permissions when rendering into PDF. API provides following settings: 

*   **Owner password** - Set owner password if password required to change the document permissions.
*   **User password** - Set user password if password required when opening a document.
*   **PDF file permissions** - Set permissions to allow or deny printing, modification and data extraction.

Following example demonstrates how to render document into PDF and set password for opening, password to change document permissions and permissions to deny printing

**C# (Render document into PDF with security settings)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = @"C:\storage";

// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(viewerConfig);
 
// Create PDF file security
string ownerPassword = "owner password";
string userPassword = "user password";
PdfFilePermissions denyPrinting = PdfFilePermissions.All ^ PdfFilePermissions.Printing;
 
PdfFileSecurity pdfFileSecurity = new PdfFileSecurity(ownerPassword, userPassword, denyPrinting);
 
// Create options
PdfFileOptions pdfFileOptions = new PdfFileOptions();
pdfFileOptions.PdfFileSecurity = pdfFileSecurity;

string guid = "document.doc";
FileContainer fileContainer = imageHandler.GetPdfFile(guid, pdfFileOptions);

```

### GroupDocs.Viewer.Domain.Options.DocumentInfoOptions

 

#### public ArchiveOptions ArchiveOptions property has been added

ArchiveOptions class allows specifying archive documents specific rendering options as explained in the article (given at the end of the page)

### GroupDocs.Viewer.Domain.Options.PdfFileOptions

 

#### public ArchiveOptions ArchiveOptions property has been added.

ArchiveOptions class allows specifying archive documents specific rendering options as explained in the article (given at the end of the page).

### GroupDocs.Viewer.Handler.Cache.ICacheDataHandler

 

#### public DateTime? GetLastModificationDate method  compilation is set to fail 

This property is obsolete and will be removed after v19.3. GroupDocs.Viewer will no longer rely on document last modification date while caching or retrieving render results from cache.

### GroupDocs.Viewer.Handler.ViewerHtmlHandler

 

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, CultureInfo cultureInfo) constructor compilation is set to fail

This constructor is obsolete and will be removed after v19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, CultureInfo cultureInfo) constructor compilation is set to fail

This constructor is obsolete and will be removed after v19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, CultureInfo cultureInfo) constructor compilation is set to fail

This constructor is obsolete and will be removed after v19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(IFileStorage fileStorage, CultureInfo cultureInfo) constructor compilation is set to fail

This constructor is obsolete and will be removed after v19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, IFileStorage fileStorage, CultureInfo cultureInfo) constructor compilation is set to fail

This constructor is obsolete and will be removed after v19.3. Please, instead, use the constructors that do not have CultureInfo argument.

### GroupDocs.Viewer.Handler.ViewerImageHandler

 

#### public ViewerImageHandler(ViewerConfig viewerConfig, CultureInfo cultureInfo) constructor compilation is set to fail

This constructor is obsolete and will be removed after v19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, CultureInfo cultureInfo) constructor compilation is set to fail

This constructor is obsolete and will be removed after v19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, CultureInfo cultureInfo) constructor compilation is set to fail

This constructor is obsolete and will be removed after v19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(IFileStorage fileStorage, CultureInfo cultureInfo) constructor compilation is set to fail

This constructor is obsolete and will be removed after v19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(ViewerConfig viewerConfig, IFileStorage fileStorage, CultureInfo cultureInfo) constructor compilation is set to fail

This constructor is obsolete and will be removed after v19.3. Please, instead, use the constructors that do not have CultureInfo argument.

### GroupDocs.Viewer.Localization.ILocalizationHandler

 

#### public interface ILocalizationHandler compilation is set to fail

This interface is obsolete and will be removed after version 19.3. The exception localization feature no longer provided.

### GroupDocs.Viewer.Localization.LocalizedStringKeys

 

#### public static class LocalizedStringKeys and all its members have been set obsolete

This class and its members are obsolete and will be removed after version 19.3. The exception localization feature no longer provided.

## Rendering Archive documents

#### Introduction

Since version 19.2 GroupDocs.Viewer for .Net API supports rendering Archive documents. Rendering into HTML provides one HTML page with the list of all items (files and folders) in the root of the archive. Rendering into PDF and image provides one or more pages, depending on a number of items (files or folders) in the archive, each output image or PDF page contains a maximum of 10 items. By default, only the items from the root of the archive are rendered. Since version 19.3, it is possible to obtain the list of contained folders and render the content from those.

#### Obtaining the list of folders from the Archive

The following example shows how to obtain the list of folders from the root of the archive:

**Retrieving the list of root folders from archive documents**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create HTML or image handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "archive.zip";
 
// Get archive document info
ArchiveDocumentInfoContainer documentInfoContainer = htmlHandler.GetDocumentInfo(guid) as ArchiveDocumentInfoContainer;
 
foreach (string folderName in documentInfoContainer.Folders)
 Console.WriteLine("Folder name: {0}", folderName); 


```

When you need to obtain the list of folders contained in a certain folder inside the archive, you have to use ArchiveOptions.FolderName option (available since version 19.3) as shown in the example below.  For instance, let's assume there is a folder named 'FirstLevelFolder' in the root of the archive, then if you need to get the list of folders inside this 'FirstLevelFolder', set the value 

ArchiveOptions.FolderName = "FirstLevelFolder";

In case you need to obtain a list of folders from 'SecondLevelFolder' that resides in 'FirstLevelFolder' then set the value using '/' path delimiter character as shown in the following example:

**Retrieving the list of folders from the certain folder inside the archive**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create HTML or image handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "archive.zip";
 
// set option to retrieve list of folders from certain folder.
HtmlOptions options = new HtmlOptions();
options.ArchiveOptions.FolderName = "FirstLevelFolder/SecondLevelFolder";
// Get archive document info
ArchiveDocumentInfoContainer documentInfoContainer = htmlHandler.GetDocumentInfo(guid, options) as ArchiveDocumentInfoContainer;
 
foreach (string folderName in documentInfoContainer.Folders)
 Console.WriteLine("Folder name: {0}", folderName); 


```

#### Rendering certain folders from the archive

By default items from the root of the archive are rendered. When you have obtained the list of folders as explained in the section above, you are now able to render the specified folder as shown in the examples below.

**Rendering specified folder into image (or HTML)**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create image handler or use ViewerHtmlHandler to render into HTML
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "sample.zip";
 
// Create image options with specified folder name (use HtmlOptions to render into HTML)
ImageOptions options = new ImageOptions();
options.ArchiveOptions.FolderName = "FirstLevelFolder/SecondLevelFolder";

// Render document into image 
List<PageImage> pages = imageHandler.GetPages(guid, options);
 
foreach (PageImage page in pages)
{
	// use page.Stream to work with rendering result
}

```

**Rendering specified folder into PDF**



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "sample.zip";
 
// Create pdf options with specified folder name
PdfFileOptions options = new PdfFileOptions();
options.ArchiveOptions.FolderName = "FolderName";

// Get pdf document
FileContainer fileContainer = imageHandler.GetPdfFile(guid, options);
 
// Access result PDF document using fileContainer.Stream property

```
