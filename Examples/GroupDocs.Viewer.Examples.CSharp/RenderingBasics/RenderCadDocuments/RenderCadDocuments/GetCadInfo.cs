namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.RenderCadDocuments;

using System.IO;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetCadInfo
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.dwg"))
        {
            ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForHtmlView();
            // Enable this option to see the list of all layouts contained in the CAD file.
            viewInfoOptions.CadOptions.RenderLayouts = true;
            CadViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions) as CadViewInfo;

            if (viewInfo != null)
            {
                // Display information about the CAD file.
                Console.WriteLine($"File type: {viewInfo.FileType}");
                Console.WriteLine($"The number of pages: {viewInfo.Pages.Count}");

                // Display the list of existing layouts.
                Console.WriteLine("The drawing contains the following layout(s):");
                foreach (Layout layout in viewInfo.Layouts)
                    Console.WriteLine(layout.Name);

                // Display the list of existing layers.
                Console.WriteLine("The drawing contains the following layer(s):");
                foreach (Layer layer in viewInfo.Layers)
                    Console.WriteLine(layer);
            }
        }
    }
}
