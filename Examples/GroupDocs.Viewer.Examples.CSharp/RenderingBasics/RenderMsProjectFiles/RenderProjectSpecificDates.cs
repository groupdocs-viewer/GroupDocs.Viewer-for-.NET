namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderMsProjectFiles;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderProjectSpecificDates
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.mpp"))
        {
            // Convert the document to PDF.
            var viewOptions = new PdfViewOptions("render-project-specific-dates.pdf");
            // Specify the date range.
            viewOptions.ProjectManagementOptions.StartDate = new DateTime(2026, 10, 01);
            viewOptions.ProjectManagementOptions.EndDate = new DateTime(2026, 12, 01);
            viewer.View(viewOptions);
        }
    }
}
