namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.SpecifyRenderingOptions;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class ApplyPc3File
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.dwg"))
        {
            // Convert the diagram to PDF.
            var viewOptions = new PdfViewOptions("apply-pc3-file.pdf");
            // Specify a path to the PC3 file.
            viewOptions.CadOptions.Pc3File = "small_page.pc3";
            viewer.View(viewOptions);
        }
    }
}
