#if NETCOREAPP
using System;
using System.IO;
using GroupDocs.Viewer.Options;
using System.Threading.Tasks;
using System.Threading;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.CommonRenderingOptions
{
    /// <summary>
    /// Cancel render with cancellation token (for .NET Standard only!).
    /// </summary>
    class CancelRenderWithCancellationToken
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Task.Run(() =>
            {
                using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DOCX, new ViewerSettings(new GroupDocs.Viewer.Logging.ConsoleLogger())))
                {
                    HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                    options.RenderComments = true;

                    viewer.View(options, cancellationToken);
                }
            }, cancellationToken);

            cancellationTokenSource.CancelAfter(10);

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
#endif