namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.SpecifyRenderingOptions;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SetImageSize
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.dwg"))
        {
            // Convert the diagram to PNG.
            var viewOptions = new PngViewOptions("output.png");
            // Specify a scale factor.
            viewOptions.CadOptions = CadOptions.ForRenderingByScaleFactor(0.5f);
            viewer.View(viewOptions);
        }
    }
}
