---
id: how-to-set-up-logging
url: viewer/net/how-to-set-up-logging
title: How to set up logging
weight: 1
description: "This article explains how to set up logging when viewing a document with GroupDocs.Viewer within your .NET applications."
keywords: logging logger viewing converting
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
By default GroupDocs.Viewer not logging when viewing documents but we also provide a way to save the log to console and file.

There is an interface that we can utilize:

* [ILogger](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.logging/ilogger) - defines the methods that are required for instantiating and releasing output file stream.

There are classes that we can utilize:

* [ConsoleLogger](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.logging/consolelogger) - defines the methods that are required for logging to console.
* [FileLogger](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.logging/filelogger) - defines the methods that are required for logging to file.

There are 3 types of messages in the log file:

* Error - for unrecoverable exceptions
* Warning - for recoverable/expected exceptions
* Trace - for general information

## Logging to File

In this example, we'll log into the file so we need to use [FileLogger](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.logging/filelogger) class.

```csharp
// Create logger and specify the output file
FileLogger fileLogger = new FileLogger("output.log");

// Create ViewerSettings and specify FileLogger
ViewerSettings viewerSettings = new ViewerSettings(fileLogger);

using (Viewer viewer = new Viewer("sample.docx",viewerSettings))
{
    ViewOptions viewOptions =
    HtmlViewOptions.ForEmbeddedResources("result.html");

    viewer.View(viewOptions);
}
```

## Logging to Console

In this example, we'll log into the console so we need to use [ConsoleLogger](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.logging/consolelogger) class.

```csharp
// Create logger and specify the output file
FileLogger fileLogger = new FileLogger("output.log");

// Create ViewerSettings and specify FileLogger
ViewerSettings viewerSettings = new ViewerSettings(fileLogger);

using (Viewer viewer = new Viewer("sample.docx",viewerSettings))
{
    ViewOptions viewOptions =
    HtmlViewOptions.ForEmbeddedResources("result.html");

    viewer.View(viewOptions);
}
```

## Implementing custom logger

To make your logger you should implement [ILogger](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.logging/ilogger) interface.

For trace messages - implement public void Trace(string message) method \
For warning messages - implement public void Warning(string message) method \
For error messages - implement public void Error(string message) method

In this example, we'll implement a simple file logger.

```csharp
// Create logger and specify the output file
CustomLogger customLogger = new CustomLogger("output.log");

// Create ViewerSettings and specify FileLogger
ViewerSettings viewerSettings = new ViewerSettings(fileLogger);

using (Viewer viewer = new Viewer("sample.docx",viewerSettings))
{
    ViewOptions viewOptions =
    HtmlViewOptions.ForEmbeddedResources("result.html");

    viewer.View(viewOptions);
}

/// <summary>
/// Writes log messages to the file.
/// </summary>
public class CustomLogger : ILogger
{
    private readonly string _fileName;

    private CustomLogger() { }

    /// <summary>
    /// Create logger to file.
    /// </summary>
    /// <param name="fileName">Full file name with path</param>
    public CustomLogger(string fileName)
    {
        _fileName = fileName;
    }

    /// <summary>
    /// Writes trace message to the console.
    /// Trace log messages provide generally useful information about application flow.
    /// </summary>
    /// <param name="message">The trace message.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public void Trace(string message)
    {
        if (message == null)
            throw new ArgumentNullException(nameof(message));

        using (StreamWriter wr = new StreamWriter(_fileName, true))
        {
            wr.WriteLine($"[TRACE] {message}");
        }
    }

    /// <summary>
    /// Writes warning message to the console;
    /// Warning log messages provide information about the unexpected and recoverable event in application flow.
    /// </summary>
    /// <param name="message">The warning message.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public void Warning(string message)
    {
        if (message == null)
            throw new ArgumentNullException(nameof(message));

        using (StreamWriter wr = new StreamWriter(_fileName, true))
        {
            wr.WriteLine($"[WARN] {message}");
        }
    }

    /// <summary>
    /// Writes an error message to the console.
    /// Error log messages provide information about unrecoverable events in application flow.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="exception">The exception.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="exception"/> is null.</exception>
    public void Error(string message, Exception exception)
    {
        if (message == null)
            throw new ArgumentNullException(nameof(message));
        if (exception == null)
            throw new ArgumentNullException(nameof(exception));

        using (StreamWriter wr = new StreamWriter(_fileName, true))
        {
            wr.WriteLine($"[ERROR] {message}, exception: {exception}");
        }
    }
}
```

## More resources

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App

Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.
