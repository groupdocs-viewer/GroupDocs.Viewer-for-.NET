---
id: groupdocs-viewer-for-net-18-4-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-4-release-notes
title: GroupDocs.Viewer for .NET 18.4 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.4.{{< /alert >}}

## Major Features

There are 18 new features, improvements, and fixes in this regular monthly release. The most notable are:

*   Added support for following file formats  
    *   POTX (PowerPoint Open XML Presentation Template) 
    *   PPTM (PowerPoint Open XML Macro-Enabled Presentation)
    *   EPS (Encapsulated PostScript)
*   Implemented simple file storage interface
*   Improved minification process
*   Added settings to include or exclude hidden content in Excel documents
*   Added option for rendering Print Area in Excel documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1552 | Feature for AutoFitting column width depending on content for rendering into HTML | New Feature |
| VIEWERNET-1544 | Implement simple file storage interface | New Feature |
| VIEWERNET-1518 | Settings to include/exclude hidden content in Excel documents | New Feature |
| VIEWERNET-1517 | Rendering only Print Area in Excel documents | New Feature |
| VIEWERNET-1478 | Add POTX file format support | New Feature |
| VIEWERNET-1476 | Add PPTM file format support | New Feature |
| VIEWERNET-526 | Add EPS (Encapsulated PostScript) file format support | New Feature |
| VIEWERNET-1537 | Add prefix for CSS classes when rendering Email messages | Improvement |
| VIEWERNET-1501 | Minify CSS content when rendering into HTML with EnableMinification is true | Improvement |
| VIEWERNET-1481 | Improve rendering comments from Presentation documents | Improvement |
| VIEWERNET-1428 | Support JpegQuality option when rendering Microsoft Project documents | Improvement |
| VIEWERNET-1549 | Extend support for DefaultFontName setting to PDF documents when rendering into HTML | Improvement |
| VIEWERNET-512 | Responsive HTML output required in the case of HTML representation | Improvement |
| VIEWERNET-1526 | Invalid PDF when rendering Excel document with multiple pages per sheet | Bug |
| VIEWERNET-1511 | DefaultFontName setting is not working for rendering Text documents into PDF and image | Bug |
| VIEWERNET-1494 | Incorrect rendering of the content in header and footer of Word document | Bug |
| WEB-2106 | Local links are ignored when rendering PDF to HTML | Bug |
| WEB-1153 | Discrepancy when rendering as JPEG and HTML | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.4. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Managing Text Overflow when Rendering Cells Documents to HTML

When cells documents are rendered into HTML, overflowed text inside the cell overlays subsequent cells until it meets non-empty cell. To expand the cell width to fit the overflowed text, set CellsOptions.TextOverflowMode of HtmlOptions, ImageOptions or PdfOptions to TextOverflowMode.AutoFitColumn.

**Setting overflowed text to be hidden when rendering Cells documents**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.xlsx";
  
// Set Cells options to hide overflowing text
HtmlOptions options = new HtmlOptions();
options.CellsOptions.TextOverflowMode = TextOverflowMode.AutoFitColumn;
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

### Improved Minification Process

Since the version 18.4, embedded CSS content is minified when the EnableMinification setting is on.

#### Details behind minification

Here is the list of technics that lay behind minification process:

CSS minification:

*   Remove all insignificant whitespace.
*   Remove all comments.
*   Remove all unnecessary semicolon separators.
*   Reduce color values.
*   Reduce integer representations by removing leading and trailing zeros.
*   Remove unit specifiers from numeric zero values.

### Rendering Print Area in Cells Documents

Starting from 18.4 GroupDocs.Viewer provides new option *RenderPrintAreaOnly* in *GroupDocs.Viewer.Converter.Options.CellsOptions* class which enables rendering sections of the worksheet(s) defined as [print area](https://support.office.com/en-us/article/set-or-clear-a-print-area-on-a-worksheet-27048af8-a321-416d-ba1b-e99ae2182a7e). GroupDocs.Viewer renders each print area in a worksheet as a separate page.

**Note:** Next example shows how to render print area(s) when rendering as HTML.

**Rendering print area.**

```csharp
 // Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.xlsx";
 
// Enable redering of print area
HtmlOptions options = new HtmlOptions();
options.CellsOptions.RenderPrintAreaOnly = true;
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
 
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

**Note:** Next example shows how to render print area(s) when rendering as the image.

**Rendering print area.**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.xlsx";
 
// Enable redering of print area
ImageOptions options = new ImageOptions();
options.CellsOptions.RenderPrintAreaOnly = true;
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
 
foreach (PageImage page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    //Save image by accessing page.Stream
}
```

**Note:** Next example shows how to render print area(s) when rendering as PDF.

**Rendering print area.**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
 
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.xlsx";
 
 
// Enable redering of print area
PdfFileOptions options = new PdfFileOptions();
options.CellsOptions.RenderPrintAreaOnly = true;
 
// Get PDF file 
FileContainer container = imageHandler.GetPdfFile(guid, options);
 
 
//Save PDF file by accessing container.Stream
```

### Rendering Hidden Rows and Columns

Starting from 18.4 GroupDocs.Viewer provides two new options *ShowHiddenRows* and *ShowHiddenColumns* in *GroupDocs.Viewer.Converter.Options.CellsOptions* class which enables rendering [hidden rows and columns](https://support.office.com/en-us/article/hide-or-show-rows-or-columns-659c2cad-802e-44ee-a614-dde8443579f8). By default, GroupDocs.Viewer doesn't render hidden rows and columns so this options should be enabled in case you would like to render the hidden content.

**Note**: Next example shows how to render hidden rows and columns when rendering as HTML.

**Rendering hidden content**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.xlsx";
 
// Enable redering of hidden rows and columns
HtmlOptions options = new HtmlOptions();
options.CellsOptions.ShowHiddenRows = true;
options.CellsOptions.ShowHiddenColumns = true;
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
 
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

**Note**: Next example shows how to render hidden rows and columns when rendering as the image.

**Rendering hidden content**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.xlsx";
 
// Enable redering of hidden rows and columns
ImageOptions options = new ImageOptions();
options.CellsOptions.ShowHiddenRows = true;
options.CellsOptions.ShowHiddenColumns = true;
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
 
foreach (PageImage page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    //Save image by accessing page.Stream
}
```

**Note**: Next example shows how to render hidden rows and columns when rendering as PDF.

**Rendering hidden content**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.xlsx";
 
// Enable redering of hidden rows and columns
PdfFileOptions options = new PdfFileOptions();
options.CellsOptions.ShowHiddenRows = true;
options.CellsOptions.ShowHiddenColumns = true;
 
// Get PDF file 
FileContainer container = imageHandler.GetPdfFile(guid, options);
 
//Save PDF file by accessing container.Stream
```

### Implementation of Simple File Storage Interface

Starting from v18.4 GroupDocs.Viewer provides a simple interface to implement custom file storage called IFileStorage.

#### Amazon S3 File Storage

The next example is based on **IFileStorage** interface which was added in **v18.4** and required [AWSSDK.S3 NuGet package](https://www.nuget.org/packages/AWSSDK.S3/).

**Custom file storage implementation**

**Amazon S3 File Storage (C#)**

```csharp
public class AmazonS3FileStorage : IFileStorage, IDisposable
{
    private AmazonS3Client _client;
    private readonly string _bucketName;
    private char PathDelimiter
    {
        get { return '/'; }
    }
 
    public AmazonS3FileStorage(AmazonS3Client client, string bucketName)
    {
        _client = client;
        _bucketName = bucketName;
    }
 
    public bool FileExists(string path)
    {
        try
        {
            string key = GetKey(path);
            GetObjectMetadataRequest request = new GetObjectMetadataRequest
            {
                BucketName = _bucketName,
                Key = key
            };
            _client.GetObjectMetadata(request);
            return true;
        }
        catch (AmazonS3Exception)
        {
            return false;
        }
    }
 
    public Stream GetFile(string path)
    {
        string key = GetKey(path);
        GetObjectRequest request = new GetObjectRequest
        {
            Key = key,
            BucketName = _bucketName
        };
        using (GetObjectResponse response = _client.GetObject(request))
        {
            MemoryStream stream = new MemoryStream();
            response.ResponseStream.CopyTo(stream);
            stream.Position = 0;
            return stream;
        }
    }
 
    public void SaveFile(string path, Stream content)
    {
        string key = GetKey(path);
        PutObjectRequest request = new PutObjectRequest
        {
            Key = key,
            BucketName = _bucketName,
            InputStream = content
        };
        _client.PutObject(request);
    }
    public void DeleteDirectory(string path)
    {
        string key = GetKey(path);
        S3DirectoryInfo directory = new S3DirectoryInfo(_client, _bucketName, key);
        directory.Delete(true);
    }
 
    public IFileInfo GetFileInfo(string path)
    {
        string key = GetKey(path);
        GetObjectMetadataRequest request = new GetObjectMetadataRequest
        {
            BucketName = _bucketName,
            Key = key
        };
        GetObjectMetadataResponse response = _client.GetObjectMetadata(request);
        IFileInfo file = new GroupDocs.Viewer.Storage.FileInfo();
        file.Path = path;
        file.Size = response.ContentLength;
        file.LastModified = response.LastModified;
        file.IsDirectory = false;
        return file;
    }
 
    public IEnumerable<IFileInfo> GetFilesInfo(string path)
    {
        string key = GetKey(path);
        ListObjectsRequest request = new ListObjectsRequest
        {
            BucketName = _bucketName,
            Prefix = key.Length > 1 ? key : string.Empty,
            Delimiter = PathDelimiter.ToString()
        };
        ListObjectsResponse response = _client.ListObjects(request);
        List<IFileInfo> files = new List<IFileInfo>();
         
        // add directories 
        foreach (string directory in response.CommonPrefixes)
        {
            IFileInfo file = new GroupDocs.Viewer.Storage.FileInfo();
            file.Path = directory;
            file.IsDirectory = true;
            files.Add(file);
        }
         
        // add files
        foreach (S3Object entry in response.S3Objects)
        {
            IFileInfo fileDescription = new GroupDocs.Viewer.Storage.FileInfo
            {
                Path = entry.Key,
                IsDirectory = false,
                LastModified = entry.LastModified,
                Size = entry.Size
            };
            files.Add(fileDescription);
        }
        return files;
    }
 
    private string GetKey(string path)
    {
        return Regex.Replace(path, @"\\+", PathDelimiter.ToString())
            .Trim(PathDelimiter);
    }
 
    public void Dispose()
    {
        if (_client != null)
        {
            _client.Dispose();
            _client = null;
        }
    }
}
```

#### Local File Storage

The next example demonstrates example implementation of local file storage.

**Local File Storage (C#)**

```csharp
/// <summary>
/// Local file storage
/// </summary>
public class LocalFileStorage : IFileStorage
{
    /// <summary>
    /// Checks if file exists
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns><c>true</c> when file exists, otherwise <c>false</c></returns>
    public bool FileExists(string path)
    {
        return File.Exists(path);
    }
    /// <summary>
    /// Retrieves file content
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>Stream</returns>
    public Stream GetFile(string path)
    {
        return File.OpenRead(path);
    }
    /// <summary>
    /// Saves file
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="content">File content.</param>
    public void SaveFile(string path, Stream content)
    {
        string directory = Path.GetDirectoryName(path);
        if (directory != null)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }
        using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            if (content.Position != 0)
                content.Position = 0;
            CopyStream(content, fileStream);
        }
    }
    /// <summary>
    /// Removes directory
    /// </summary>
    /// <param name="path">Directory path.</param>
    public void DeleteDirectory(string path)
    {
        if (Directory.Exists(path))
        {
            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                //NOTE: ignore
            }
        }
    }
    /// <summary>
    /// Retrieves file information
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>File information.</returns>
    public IFileInfo GetFileInfo(string path)
    {
        System.IO.FileInfo info = new System.IO.FileInfo(path);
        FileInfo fileInfo = new FileInfo();
        if (info.Exists)
        {
            fileInfo.Path = path;
            fileInfo.LastModified = info.LastWriteTime;
            fileInfo.Size = info.Length;
            fileInfo.IsDirectory = false;
        }
        return fileInfo;
    }
    /// <summary>
    /// Retrieves list of files and folders
    /// </summary>
    /// <param name="path">Directory path.</param>
    /// <returns>Files and folders.</returns>
    public IEnumerable<IFileInfo> GetFilesInfo(string path)
    {
        List<IFileInfo> filesInfo = new List<IFileInfo>();
        foreach (string directory in Directory.GetDirectories(path))
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            IFileInfo info = new FileInfo();
            info.IsDirectory = true;
            info.Path = directoryInfo.FullName;
            info.LastModified = directoryInfo.LastWriteTime;
            filesInfo.Add(info);
        }
        foreach (string file in Directory.GetFiles(path))
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
            IFileInfo info = new FileInfo();
            info.IsDirectory = false;
            info.Path = fileInfo.FullName;
            info.LastModified = fileInfo.LastWriteTime;
            info.Size = fileInfo.Length;
            filesInfo.Add(info);
        }
        return filesInfo;
    }
    private void CopyStream(Stream src, Stream dst)
    {
        const int bufferSize = 81920; //NOTE: taken from System.IO
        byte[] buffer = new byte[bufferSize];
        int read;
        while ((read = src.Read(buffer, 0, buffer.Length)) != 0)
            dst.Write(buffer, 0, read);
    }
}
```

#### IFileStorage Interface

This interface is an alternative to complex and overloaded ICacheDataHandler and IInputDataHandler interfaces. 

**IFileStorage interface (C#)**

```csharp
/// <summary>
/// File storage interface
/// </summary>
public interface IFileStorage
{
    /// <summary>
    /// Checks if file exists
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns><c>true</c> when file exists, otherwise <c>false</c></returns>
    bool FileExists(string path);
 
    /// <summary>
    /// Retrieves file content
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>Stream</returns>
    Stream GetFile(string path);
 
    /// <summary>
    /// Saves file
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="content">File content.</param>
    void SaveFile(string path, Stream content);
 
    /// <summary>
    /// Removes directory
    /// </summary>
    /// <param name="path">Directory path.</param>
    void DeleteDirectory(string path);
 
    /// <summary>
    /// Retrieves file information
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>File information.</returns>
    IFileInfo GetFileInfo(string path);
 
    /// <summary>
    /// Retrieves list of files and folders
    /// </summary>
    /// <param name="path">Directory path.</param>
    /// <returns>Files and folders.</returns>
    IEnumerable<IFileInfo> GetFilesInfo(string path);
}
```

**IFileInfo interface (C#)**

```csharp
/// <summary>
/// File information
/// </summary>
public struct FileInfo : IFileInfo
{
    /// <summary>
    /// File or directory path
    /// </summary>
    public string Path { get; set; }
     
    /// <summary>
    /// File size in bytes
    /// </summary>
    public long Size { get; set; }
     
    /// <summary>
    /// Last modification date
    /// </summary>
    public DateTime LastModified { get; set; }
     
    /// <summary>
    /// Indicates if file is directory
    /// </summary>
    public bool IsDirectory { get; set; }
}
```

### List of Changes in v18.4

#### GroupDocs.Viewer.Config.ViewerConfig

##### public string DefaultFontName property compilation is set to fail

Please use DefaultFontName property of the ImageOptions, HtmlOptions, DocumentInfoOptions or PdfFileOptions class instead

#### GroupDocs.Viewer.Converter.Options.CellsOptions

##### public bool RenderPrintAreaOnly { get; set; } property has been added.

This option enables rendering section(s) of a worksheet defined as a print area. 



```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
 
// Init viewer html or image handler
ViewerHtmlHandler viewerHtmlHandler = new ViewerHtmlHandler(viewerConfig);

// Set the guid of the document you want to render
string guid = "with-print-area.xlsx";
 
// Enable rendering print area
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.CellsOptions.RenderPrintAreaOnly = true;
//Render document with specified options
List<PageHtml> pages = viewerHtmlHandler.GetPages(guid, htmlOptions);
```

##### public bool ShowHiddenRows { get; set; } property has been added.

This option enables rendering of hidden rows.



```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
 
// Init viewer html or image handler
ViewerHtmlHandler viewerHtmlHandler = new ViewerHtmlHandler(viewerConfig);

// Set the guid of the document you want to render
string guid = "with-hidden-rows.xlsx";
 
// Enable rendering hidden rows
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.CellsOptions.ShowHiddenRows= true;
//Render document with specified options
List<PageHtml> pages = viewerHtmlHandler.GetPages(guid, htmlOptions);
```

##### public bool ShowHiddenColumns { get; set; } property has been added.

This option enables rendering of hidden columns. 



```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
 
// Init viewer html or image handler
ViewerHtmlHandler viewerHtmlHandler = new ViewerHtmlHandler(viewerConfig);

// Set the guid of the document you want to render
string guid = "with-hidden-columns.xlsx";
 
// Enable rendering hidden columns
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.CellsOptions.ShowHiddenColumns= true;
//Render document with specified options
List<PageHtml> pages = viewerHtmlHandler.GetPages(guid, htmlOptions);
```

#### GroupDocs.Viewer.Domain.FileData

##### Public int MaxHeight property has been removed.

To get maximal height, loop through the list of pages.

##### Public int MaxWidth property has been removed.

To get the maximal width, loop through the list of pages.

##### Public int PageCount property has been removed.

To get the number of pages, use Count property of pages list

#### GroupDocs.Viewer.Exception.CacheFileNotFoundException

##### GroupDocs.Viewer.Exception.CacheFileNotFoundException class has been set as obsolete

This exception is obsolete. GroupDocs.Viewer will start throwing System.IO.FileNotFoundException instead of CacheFileNotFoundException in version v18.7 and next versions.

#### GroupDocs.Viewer.Exception.GuidNotSpecifiedException

##### GroupDocs.Viewer.Exception.GuidNotSpecifiedException class has been set as obsolete

This exception is obsolete. GroupDocs.Viewer will start throwing System.ArgumentNullException instead of GuidNotSpecifiedException in version v18.7 and next versions.

#### GroupDocs.Viewer.Exception.StoragePathNotSpecifiedException

##### GroupDocs.Viewer.Exception.StoragePathNotSpecifiedException class has been set as obsolete

This exception is obsolete and will be removed in v18.7.

#### GroupDocs.Viewer.Handler.Cache.ICacheDataHandler

#### void ClearCache(TimeSpan olderThan) method has been set as obsolete

This method is obsolete and will be removed in v18.7.

#### GroupDocs.Viewer.Handler.ViewerHtmlHandler

##### public ViewerImageHandler(IFileStorage fileStorage) constructor has been added

This constructor can be used to pass custom file storage implementation.

##### public ViewerImageHandler(IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been added

This constructor can be used to pass custom file storage implementation along with culture information.

##### public ViewerImageHandler(ViewerConfig viewerConfig, IFileStorage fileStorage) constructor has been added

This constructor can be used to pass custom file storage implementation along with Viewer configuration.

##### public ViewerImageHandler(ViewerConfig viewerConfig, IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been added

This constructor can be used to pass custom file storage implementation along with Viewer configuration and culture information.

##### public void ClearCache(TimeSpan olderThan) method has been set as obsolete 

Please use *public void ClearCache()* or *public void ClearCache(string guid) * methods instead.

**C# (since the v18.4)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
config.UseCache = true;
 
string guid = "document.docx";
ViewerHtmlHandler handler = new ViewerHtmlHandler(config);

// Create cache by calling GetPages method
List<PageHtml> pages = handler.GetPages(guid);

// Clear cache files for specified file 
handler.ClearCache(guid);
 
// Clear all cache files
handler.ClearCache();
```

**C# (before v18.1)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
config.UseCache = true;
 
string guid = "document.docx";
ViewerHtmlHandler handler = new ViewerHtmlHandler(config);

// Create cache by calling GetPages method
List<PageHtml> pages = handler.GetPages(guid);

// Clear cache filies created before specified time span
handler.ClearCache(TimeSpan.FromMinutes(1));
```

#### GroupDocs.Viewer.Handler.ViewerImageHandler

##### public ViewerImageHandler(IFileStorage fileStorage) constructor has been added

This constructor can be used to pass custom file storage implementation.

##### public ViewerImageHandler(IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been added

This constructor can be used to pass custom file storage implementation along with culture information.

##### public ViewerImageHandler(ViewerConfig viewerConfig, IFileStorage fileStorage) constructor has been added

This constructor can be used to pass custom file storage implementation along with Viewer configuration.

##### public ViewerImageHandler(ViewerConfig viewerConfig, IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been added

This constructor can be used to pass custom file storage implementation along with Viewer configuration and culture information.

##### public void ClearCache(TimeSpan olderThan) method has been set as obsolete 

Please use *public void ClearCache()* or *public void ClearCache(string guid)* methods instead.

**C# (since the v18.4)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
config.UseCache = true;
 
string guid = "document.docx";
ViewerImageHandler handler = new ViewerImageHandler(config);

// Create cache by calling GetPages method
List<PageImage> pages = handler.GetPages(guid);

// Clear cache files for specified file 
handler.ClearCache(guid);
 
// Clear all cache files
handler.ClearCache();
```

**C# (before v18.1)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
config.UseCache = true;
 
string guid = "document.docx";
ViewerImageHandler handler = new ViewerImageHandler(config);

// Create cache by calling GetPages method
List<PageImage> pages = handler.GetPages(guid);

// Clear cache filies created before specified time span
handler.ClearCache(TimeSpan.FromMinutes(1));
```

#### GroupDocs.Viewer.Storage.IFileStorage

##### public interface IFileStorage interface has been added.

This interface is an alternative to complex and overloaded ICacheDataHandler and IInputDataHandler interfaces.

**Custom file storage based on IFileStorage interface**

**IFileStorage interface (C#)**

```csharp
/// <summary>
/// File storage interface
/// </summary>
public interface IFileStorage
{
    /// <summary>
    /// Checks if file exists
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns><c>true</c> when file exists, otherwise <c>false</c></returns>
    bool FileExists(string path);

    /// <summary>
    /// Retrieves file content
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>Stream</returns>
    Stream GetFile(string path);

    /// <summary>
    /// Saves file
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="content">File content.</param>
    void SaveFile(string path, Stream content);

    /// <summary>
    /// Removes directory
    /// </summary>
    /// <param name="path">Directory path.</param>
    void DeleteDirectory(string path);

    /// <summary>
    /// Retrieves file information
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>File information.</returns>
    IFileInfo GetFileInfo(string path);

    /// <summary>
    /// Retrieves list of files and folders
    /// </summary>
    /// <param name="path">Directory path.</param>
    /// <returns>Files and folders.</returns>
    IEnumerable<IFileInfo> GetFilesInfo(string path);
}
```

**IFileInfo interface (C#)**

```csharp
/// <summary>
/// File information
/// </summary>
public struct FileInfo : IFileInfo
{
    /// <summary>
    /// File or directory path
    /// </summary>
    public string Path { get; set; }
    
    /// <summary>
    /// File size in bytes
    /// </summary>
    public long Size { get; set; }
    
    /// <summary>
    /// Last modification date
    /// </summary>
    public DateTime LastModified { get; set; }
    
    /// <summary>
    /// Indicates if file is directory
    /// </summary>
    public bool IsDirectory { get; set; }
}
```

{{< alert style="danger" >}}Next example requires AWSSDK.S3 NuGet package.{{< /alert >}}

**Amazon S3 File Storage (C#)**

```csharp
public class AmazonS3FileStorage : IFileStorage, IDisposable
{
    private AmazonS3Client _client;
    private readonly string _bucketName;
    private char PathDelimiter
    {
        get { return '/'; }
    }

    public AmazonS3FileStorage(AmazonS3Client client, string bucketName)
    {
        _client = client;
        _bucketName = bucketName;
    }

    public bool FileExists(string path)
    {
        try
        {
            string key = GetKey(path);
            GetObjectMetadataRequest request = new GetObjectMetadataRequest
            {
                BucketName = _bucketName,
                Key = key
            };
            _client.GetObjectMetadata(request);
            return true;
        }
        catch (AmazonS3Exception)
        {
            return false;
        }
    }

    public Stream GetFile(string path)
    {
        string key = GetKey(path);
        GetObjectRequest request = new GetObjectRequest
        {
            Key = key,
            BucketName = _bucketName
        };
        using (GetObjectResponse response = _client.GetObject(request))
        {
            MemoryStream stream = new MemoryStream();
            response.ResponseStream.CopyTo(stream);
            stream.Position = 0;
            return stream;
        }
    }

    public void SaveFile(string path, Stream content)
    {
        string key = GetKey(path);
        PutObjectRequest request = new PutObjectRequest
        {
            Key = key,
            BucketName = _bucketName,
            InputStream = content
        };
        _client.PutObject(request);
    }
    public void DeleteDirectory(string path)
    {
        string key = GetKey(path);
        S3DirectoryInfo directory = new S3DirectoryInfo(_client, _bucketName, key);
        directory.Delete(true);
    }

    public IFileInfo GetFileInfo(string path)
    {
        string key = GetKey(path);
        GetObjectMetadataRequest request = new GetObjectMetadataRequest
        {
            BucketName = _bucketName,
            Key = key
        };
        GetObjectMetadataResponse response = _client.GetObjectMetadata(request);
        IFileInfo file = new GroupDocs.Viewer.Storage.FileInfo();
        file.Path = path;
        file.Size = response.ContentLength;
        file.LastModified = response.LastModified;
        file.IsDirectory = false;
        return file;
    }

    public IEnumerable<IFileInfo> GetFilesInfo(string path)
    {
        string key = GetKey(path);
        ListObjectsRequest request = new ListObjectsRequest
        {
            BucketName = _bucketName,
            Prefix = key.Length > 1 ? key : string.Empty,
            Delimiter = PathDelimiter.ToString()
        };
        ListObjectsResponse response = _client.ListObjects(request);
        List<IFileInfo> files = new List<IFileInfo>();
        
		// add directories 
        foreach (string directory in response.CommonPrefixes)
        {
            IFileInfo file = new GroupDocs.Viewer.Storage.FileInfo();
            file.Path = directory;
            file.IsDirectory = true;
            files.Add(file);
        }
        
		// add files
        foreach (S3Object entry in response.S3Objects)
        {
            IFileInfo fileDescription = new GroupDocs.Viewer.Storage.FileInfo
            {
                Path = entry.Key,
                IsDirectory = false,
                LastModified = entry.LastModified,
                Size = entry.Size
            };
            files.Add(fileDescription);
        }
        return files;
    }

    private string GetKey(string path)
    {
        return Regex.Replace(path, @"\\+", PathDelimiter.ToString())
            .Trim(PathDelimiter);
    }

    public void Dispose()
    {
        if (_client != null)
        {
            _client.Dispose();
            _client = null;
        }
    }
}


```

#### GroupDocs.Viewer.Storage.LocalFileStorage

##### public class LocalFileStorage class has been added.

This class is an example of how *IFileStorage* interface that can be implemented to work with local files.

**Custom file storage based on IFileStorage interface**

**IFileStorage interface (C#)**

```csharp
/// <summary>
/// Local file storage
/// </summary>
public class LocalFileStorage : IFileStorage
{
    /// <summary>
    /// Checks if file exists
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns><c>true</c> when file exists, otherwise <c>false</c></returns>
    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    /// <summary>
    /// Retrieves file content
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>Stream</returns>
    public Stream GetFile(string path)
    {
        return File.OpenRead(path);
    }

    /// <summary>
    /// Saves file
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="content">File content.</param>
    public void SaveFile(string path, Stream content)
    {
        string directory = Path.GetDirectoryName(path);
        if (directory != null)
        {
            if (!Directory.Exists(directory))
               Directory.CreateDirectory(directory);
        }

        using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            if (content.Position != 0)
            	content.Position = 0;
            
			CopyStream(content, fileStream);
        }
    }
    
	/// <summary>
    /// Removes directory
    /// </summary>
    /// <param name="path">Directory path.</param>
    public void DeleteDirectory(string path)
    {
        if (Directory.Exists(path))
        {
            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                //NOTE: ignore
            }
        }
    }
    
	/// <summary>
    /// Retrieves file information
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>File information.</returns>
    public IFileInfo GetFileInfo(string path)
    {
        System.IO.FileInfo info = new System.IO.FileInfo(path);
        FileInfo fileInfo = new FileInfo();
        if (info.Exists)
        {
            fileInfo.Path = path;
            fileInfo.LastModified = info.LastWriteTime;
            fileInfo.Size = info.Length;
            fileInfo.IsDirectory = false;
         }
         return fileInfo;
    }
    
	/// <summary>
    /// Retrieves list of files and folders
    /// </summary>
    /// <param name="path">Directory path.</param>
    /// <returns>Files and folders.</returns>
    public IEnumerable<IFileInfo> GetFilesInfo(string path)
    {
        List<IFileInfo> filesInfo = new List<IFileInfo>();
        foreach (string directory in Directory.GetDirectories(path))
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            IFileInfo info = new FileInfo();
            info.IsDirectory = true;
            info.Path = directoryInfo.FullName;
            info.LastModified = directoryInfo.LastWriteTime;
            filesInfo.Add(info);
        }

        foreach (string file in Directory.GetFiles(path))
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
            IFileInfo info = new FileInfo();
            info.IsDirectory = false;
            info.Path = fileInfo.FullName;
            info.LastModified = fileInfo.LastWriteTime;
            info.Size = fileInfo.Length;
            filesInfo.Add(info);
        }
        return filesInfo;
    }

    private void CopyStream(Stream src, Stream dst)
    {
        const int bufferSize = 81920;
        byte[] buffer = new byte[bufferSize];
        int read;
        while ((read = src.Read(buffer, 0, buffer.Length)) != 0)
            dst.Write(buffer, 0, read);
    }
}
```
