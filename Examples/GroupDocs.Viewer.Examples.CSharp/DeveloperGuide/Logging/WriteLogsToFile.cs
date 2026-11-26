namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.Logging;

using GroupDocs.Viewer.Logging;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class WriteLogsToFile
{
    public static void Run()
    {
        // ...

        // Create logger and specify the output file.
        FileLogger fileLogger = new FileLogger("output.log");

        // Create ViewerSettings and specify FileLogger.
        ViewerSettings viewerSettings = new ViewerSettings(fileLogger);

        // Render a document.
        using (Viewer viewer = new Viewer("sample.docx",viewerSettings))
        {
            ViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources("result.html");
            viewer.View(viewOptions);
        }
    }
}
