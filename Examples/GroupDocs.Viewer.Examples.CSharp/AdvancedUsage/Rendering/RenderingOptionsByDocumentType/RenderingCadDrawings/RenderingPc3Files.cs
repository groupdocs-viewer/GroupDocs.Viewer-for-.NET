using GroupDocs.Viewer.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingCadDrawings
{
    public class RenderingPc3Files
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "pc3_result.jpg");

            // TO JPG with PC3 config
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DWG_WITH_LAYOUTS_AND_LAYERS))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);

                // With PC3 file is 274x198
                options.CadOptions.Pc3File = TestFiles.SAMPLE_PC3_CONFIG; 
                // Without PC3 file size is 2000x1769 pixels

                viewer.View(options);
            }
        }
    }
}
