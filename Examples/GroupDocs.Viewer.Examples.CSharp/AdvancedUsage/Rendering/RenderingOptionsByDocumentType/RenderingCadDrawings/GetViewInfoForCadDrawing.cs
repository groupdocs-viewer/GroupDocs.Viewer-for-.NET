using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingCadDrawings
{
    /// <summary>
    /// Get list of all layouts and layers of a CAD drawing
    /// </summary>
    class GetViewInfoForCadDrawing
    {
        public static void Run()
        {
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DWG_WITH_LAYOUTS_AND_LAYERS))
            {
                ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForHtmlView();
                // Default value is false, so the only Model is rendered by default
                // Set RenderLayouts to true to include all layouts 
                // See https://docs.groupdocs.com/viewer/net/render-all-layouts/
                viewInfoOptions.CadOptions.RenderLayouts = true;

                CadViewInfo info = viewer.GetViewInfo(viewInfoOptions) as CadViewInfo;

                Console.WriteLine("Document type is: " + info.FileType);
                Console.WriteLine("Pages count: " + info.Pages.Count);

                Console.WriteLine("\nLayouts:");
                foreach (Layout layout in info.Layouts)
                    Console.WriteLine(layout);

                Console.WriteLine("\nLayers:");
                foreach (Layer layer in info.Layers)
                    Console.WriteLine(layer);
            }

            Console.WriteLine("\nCAD info obtained successfully.");
        }
    }
}