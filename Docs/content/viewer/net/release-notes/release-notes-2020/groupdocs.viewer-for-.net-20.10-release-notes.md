---
id: groupdocs-viewer-for-net-20-10-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-10-release-notes
title: GroupDocs.Viewer for .NET 20.10 Release Notes
weight: 49
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 20.10"
keywords: release notes, groupdocs.viewer, .net, 20.10
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.10{{< /alert >}}

## Major Features  

There are 31 features, improvements, and bug-fixes in this release, most notable are:

* [Added logging support]({{< ref "viewer/net/developer-guide/advanced-usage/how-to/how-to-set-up-logging.md">}})
* [Add Compressed Windows Metafile (.wmz) file-format support]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-image-files/how-to-convert-and-view-wmf-and-wmz-files.md">}})
* [Add Corel Metafile exchange (.cmx) file-format support]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-image-files/how-to-convert-and-view-cmx-files.md">}})
* [Add Corel Draw (.cdr) file-format support]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-image-files/how-to-convert-and-view-cdr-files.md">}})
* [Added Support rendering presentations with shapes and text with 3D effects]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-powerpoint-presentations/converting-presentations-with-shapes-and-text-with-3-d-effects.md">}})
* Added RAR5 archive extraction support

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-2422|Add logging support|Feature|
|VIEWERNET-2605|Add Compressed Windows Metafile (.wmz) file-format support|Feature|
|VIEWERNET-2606|Add Windows Compressed Enhanced Metafile (.emz) file-format support|Feature|
|VIEWERNET-2747|More descriptive exception when opening encrypted XLSM files|Feature|
|VIEWERNET-2749|Add Corel Metafile exchange (.cmx) file-format support|Feature|
|VIEWERNET-2759|Add Corel Draw (.cdr) file-format support|Feature|
|VIEWERNET-2760|Add RAR5 archive extraction support|Feature|
|VIEWERNET-2769|Support rendering presentations with shapes and text with 3D effects|Feature|
|VIEWERNET-1080|Incorrect print preview and print of output HTML in Chrome|Bug|
|VIEWERNET-2426|Problem with summary when rendering a PDF to HTML|Bug|
|VIEWERNET-2477|Exception is thrown when loading XLSB file|Bug|
|VIEWERNET-2488|Exception is thrown when rendering DNG file|Bug|
|VIEWERNET-2489|"Image export failed" exception when rendering TIFF file"|Bug|
|VIEWERNET-2495|"A generic error occurred in GDI+" exception occurs when rendering VSDX file"|Bug|
|VIEWERNET-2550|"A generic error occurred in GDI+" exception occurs when rendering MPP file"|Bug|
|VIEWERNET-2603|XLSX to HTML rendering missing some fields|Bug|
|VIEWERNET-2609|Can't get document info for JPF|Bug|
|VIEWERNET-2660|Out of memory exception thrown Linux when rendering MPP to PNG|Bug|
|VIEWERNET-2661|"A generic error occurred in GDI+" exception occurs when rendering VSDX file to PNG in Linux"|Bug|
|VIEWERNET-2751|You can not change part of an array or table formula.|Bug|
|VIEWERNET-2765|Out of memory when opening VSDX|Bug|
|VIEWERNET-2771|Could not load file. File is corrupted or damaged.|Bug|
|VIEWERNET-2772|'Object reference not set to an instance of an object.' when saving VSS shapes for specific file|Bug|
|VIEWERNET-2777|Image saving failed exception when saving SVG|Bug|
|VIEWERNET-2779|PLT file is failed to open|Bug|
|VIEWERNET-2780|Empty XLSX cells not rendered when converting to PNG|Bug|
|VIEWERNET-2781|An exception should be not thrown when the font doesn't exist|Bug|
|VIEWERNET-2783|You can not change part of an array or table formula.|Bug|
|VIEWERNET-2784|Object reference not set to an instance of an object.|Bug|
|VIEWERNET-2787|The column index should not be inside the pivottable report|Bug|
|VIEWERNET-2792|ViewOptions ignored for Cells file|Bug|

## Public API and Backward Incompatible Changes

### Changes in the public API

#### GroupDocs.Viewer.FileType

Fields were added to [GroupDocs.Viewer.FileType](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype>) class that reflects new file formats that we're supporting starting from v20.10.

```csharp
/// <summary>
/// Corel Exchange (.cmx) is a drawing image file that may contain vector graphics as well as bitmap graphics.
/// Learn more about this file format <a href="https://wiki.fileformat.com/image/cmx">here</a>.
/// </summary>
public static readonly FileType CMX = new FileType("Corel Metafile exchange", ".cmx");

/// <summary>
/// Enhanced Windows Metafile compressed (.emz) represents graphical images device-independently compressed by GZIP. Metafiles of EMF comprises of variable-length records in chronological order that can render the stored image after parsing on any output device.
/// Learn more about this file format <a href="https://wiki.fileformat.com/image/emz">here</a>.
/// </summary>

public static readonly FileType EMZ = new FileType("Windows Compressed Enhanced Metafile", ".emz");

/// <summary>
/// Compressed Windows Metafile (.wmz) represents Microsoft Windows Metafile (WMF) compressed in GZIP archvive - for storing vector as well as bitmap-format images data.
/// Learn more about this file format <a href="https://fileinfo.com/extension/wmz#compressed_windows_metafile">here</a>.
/// </summary>
public static readonly FileType WMZ = new FileType("Compressed Windows Metafile", ".wmz");
```

#### GroupDocs.Viewer.Logging

public class [ConsoleLogger](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.logging/consolelogger>) class added to GroupDocs.Viewer.Logging. This class provides support for logging GroupDocs.Viewer conversion process to console.

```csharp
/// <summary>
/// Writes log messages to the console.
/// </summary>
public class ConsoleLogger : ILogger
{
    /// <summary>
    /// Writes a trace message to the console.
    /// Trace log messages provide generally useful information about application flow.
    /// </summary>
    /// <param name="message">The trace message.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public void Trace(string message);

    /// <summary>
    /// Writes a warning message to the console.
    /// Warning log messages provide information about unexpected and recoverable events in application flow.
    /// </summary>
    /// <param name="message">The warning message.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public void Warning(string message);


    /// <summary>
    /// Writes an error message to the console.
    /// Error log messages provide information about unrecoverable events in application flow.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="exception">The exception.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="exception"/> is null.</exception>
    public void Error(string message, Exception exception);

}
```

\
public class [FileLogger](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.logging/filelogger>) class added to GroupDocs.Viewer.Logging. This class provides support for logging GroupDocs.Viewer conversion process to file.

```csharp
/// <summary>
/// Writes log messages to the file.
/// </summary>
public class FileLogger : ILogger
{
    /// <summary>
    /// Create logger to file.
    /// </summary>
    /// <param name="fileName">Full file name with path</param>
    public FileLogger(string fileName);

    /// <summary>
    /// Writes a trace message to the console.
    /// Trace log messages provide generally useful information about application flow.
    /// </summary>
    /// <param name="message">The trace message.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public void Trace(string message);

    /// <summary>
    /// Writes a warning message to the console.
    /// Warning log messages provide information about unexpected and recoverable events in application flow.
    /// </summary>
    /// <param name="message">The warning message.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public void Warning(string message);

    /// <summary>
    /// Writes an error message to the console.
    /// Error log messages provide information about unrecoverable events in application flow.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="exception">The exception.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="exception"/> is null.</exception>
    public void Error(string message, Exception exception);
}

```

\
public interface [ILogger](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.logging/ilogger>) class added to GroupDocs.Viewer.Logging. This interface provides support for custom logger implementation.

```csharp
    /// <summary>
    /// Defines the methods that are used to perform logging.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes a trace message.
        /// Trace log messages provide generally useful information about application flow.
        /// </summary>
        /// <param name="message">The trace message.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
        void Trace(string message);

        /// <summary>
        /// Writes a warning message.
        /// Warning log messages provide information about unexpected and recoverable events in application flow.
        /// </summary>
        /// <param name="message">The warning message.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
        void Warning(string message);

        /// <summary>
        /// Writes an error message.
        /// Error log messages provide information about unrecoverable events in application flow.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="exception">The exception.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="exception"/> is null.</exception>
        void Error(string message, Exception exception);
    }
```

#### GroupDocs.Viewer

New property and constructor added to [ViewerSettings](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/viewersettings>) class.

```csharp
/// <summary>
/// The logger implementation used for logging (Errors, Warnings, Traces).
/// </summary>
public ILogger Logger { get; }

/// <summary>
/// Initializes new instance of <see cref="ViewerSettings"/> class.
/// </summary>
/// <param name="cache">The cache.</param>
/// <param name="logger">The logger.</param>
/// <exception cref="System.ArgumentNullException">Thrown when <paramref name="cache"/> is null.</exception>
public ViewerSettings(ICache cache, ILogger logger)
```
