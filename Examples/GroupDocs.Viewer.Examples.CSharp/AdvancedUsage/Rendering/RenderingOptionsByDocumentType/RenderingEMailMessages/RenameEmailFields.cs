using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingEMailMessages
{
    /// <summary>
    /// This example demonstrates how to rename fields when rendering email messages.
    /// </summary>
    class RenameEmailFields
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_MSG))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.EmailOptions.FieldTextMap[Field.From] = "Sender";
                options.EmailOptions.FieldTextMap[Field.To] = "Receiver";
                options.EmailOptions.FieldTextMap[Field.Sent] = "Date";
                options.EmailOptions.FieldTextMap[Field.Subject] = "Topic";

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

