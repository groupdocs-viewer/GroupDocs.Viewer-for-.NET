namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.Logging;

using System.IO;
using System;
using GroupDocs.Viewer.Logging;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

/// <summary>
/// Writes log messages to a file.
/// </summary>
public class CustomLogger : ILogger
{
    private readonly string _fileName;

    private CustomLogger() { }

    /// <summary>
    /// Create logger to a file.
    /// </summary>
    /// <param name="fileName">Full file name with path</param>
    public CustomLogger(string fileName)
    {
        _fileName = fileName;
    }

    /// <summary>
    /// Writes trace message to the file.
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
    /// Writes warning message to the file;
    /// Warning log messages provide information about the unexpected and recoverable events in application flow.
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
    /// Writes an error message to the file.
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

public static class WriteLogsWithCustomLogger
{
    public static void Run()
    {
        // ...

        // Create logger and specify the output file.
        CustomLogger customLogger = new CustomLogger("output.log");

        // Create ViewerSettings and specify CustomLogger.
        ViewerSettings viewerSettings = new ViewerSettings(customLogger);

        // Render a document.
        using (Viewer viewer = new Viewer("sample.docx",viewerSettings))
        {
            ViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources("result.html");

            viewer.View(viewOptions);
        }
    }
}
