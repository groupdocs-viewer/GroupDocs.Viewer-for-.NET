namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.Troubleshooting.HowToMigrateToGroupdocsViewer198OrHigher;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class MigrateNewApi
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
           HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources();
           viewer.View(options);
        }
    }
}
