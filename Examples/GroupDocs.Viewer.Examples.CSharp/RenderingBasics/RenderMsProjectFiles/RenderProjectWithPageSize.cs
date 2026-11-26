namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderMsProjectFiles;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderProjectWithPageSize
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.mpp"))
        {
            // Convert the document to PDF.
            var viewOptions = new PdfViewOptions("render-project-with-page-size.pdf");
            // Specify the page size.
            viewOptions.ProjectManagementOptions.PageSize = PageSize.A3;
            viewer.View(viewOptions);
        }
    }
}
