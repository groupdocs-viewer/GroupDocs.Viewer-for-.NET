namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.SpecifyRenderingOptions;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class EnablePerformanceMode
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.dwg"))
        {
           HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources("Output-Page#{0}.html");                    
           viewOptions.CadOptions = CadOptions.ForRenderingByWidth(1000);
           viewOptions.CadOptions.EnablePerformanceConversionMode = true;

           viewer.View(viewOptions);
        }
    }
}
