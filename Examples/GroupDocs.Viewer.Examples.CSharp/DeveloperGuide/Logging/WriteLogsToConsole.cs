namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.Logging;

using GroupDocs.Viewer.Logging;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class WriteLogsToConsole
{
    public static void Run()
    {
        // ...

        // Create console logger.
        ConsoleLogger consoleLogger = new ConsoleLogger();

        // Create ViewerSettings and specify FileLogger.
        ViewerSettings viewerSettings = new ViewerSettings(consoleLogger);

        // Render a document.
        using (Viewer viewer = new Viewer("sample.docx", viewerSettings))
        {
            ViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }
    }
}
