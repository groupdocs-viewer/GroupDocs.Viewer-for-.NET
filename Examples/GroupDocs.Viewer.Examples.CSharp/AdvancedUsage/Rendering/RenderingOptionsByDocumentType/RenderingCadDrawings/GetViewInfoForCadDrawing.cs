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
            using (Viewer viewer = new Viewer(Utils.SAMPLE_DWG_WITH_LAYOUTS_AND_LAYERS))
            {
                CadViewInfo info = viewer.GetViewInfo(
                    ViewInfoOptions.ForHtmlView()) as CadViewInfo;

                Console.WriteLine("Document type is: " + info.FileType);
                Console.WriteLine("Pages count: " + info.Pages.Count);

                foreach (Layout layout in info.Layouts)
                    Console.WriteLine(layout);

                foreach (Layer layer in info.Layers)
                    Console.WriteLine(layer);
            }

            Console.WriteLine("\nCAD info obtained successfully.");
        }
    }
}
