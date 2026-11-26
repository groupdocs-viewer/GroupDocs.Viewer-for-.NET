namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RepairCorruptedPdf
{
    public static void Run()
    {
        // ...

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.TryRepair = true;

        PngViewOptions viewOptions = new PngViewOptions();

        using (Viewer viewer = new Viewer("corrupted.pdf", loadOptions))
        {    
            viewer.View(viewOptions);
        }
    }
}
