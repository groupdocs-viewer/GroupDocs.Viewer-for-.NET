namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderMsProjectFiles;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderProjectWithTimeUnit
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.mpp"))
        {
            // Convert the document to HTML.
            // {0} is replaced with the current page number in the file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("output_{0}.html");
            // Specify the time unit.
            viewOptions.ProjectManagementOptions.TimeUnit = TimeUnit.ThirdsOfMonths;
            viewer.View(viewOptions);
        }
    }
}
