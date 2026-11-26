namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderMsProjectFiles;

using System.IO;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetProjectInfo
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.mpp"))
        {
            var viewInfoOptions = ViewInfoOptions.ForHtmlView();
            var viewInfo = viewer.GetViewInfo(viewInfoOptions) as ProjectManagementViewInfo;

            if (viewInfo != null)
            {
                // Display information about the Project file.
                Console.WriteLine($"File type: {viewInfo.FileType}");
                Console.WriteLine($"The number of pages: {viewInfo.Pages.Count}");
                Console.WriteLine($"Project start date: {viewInfo.StartDate}");
                Console.WriteLine($"Project end date: {viewInfo.EndDate}");
            }
        }
    }
}
