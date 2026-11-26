namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.CancelRendering;

using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class CancelRendering
{
    public static void Run()
    {
        // ...

        // Create cancellation token source.
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        // Create task and pass token
        Task runTask = Task.Run(() =>
        {
            using (Viewer viewer = new Viewer("sample.docx"))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources();
                options.RenderComments = true;
                viewer.View(options, cancellationToken);
            }
        }, cancellationToken);

        // Cancel task after 1000 ms.
        cancellationTokenSource.CancelAfter(1000);

        // Also you can call Cancel method at any time
        //cancellationTokenSource.Cancel();

        // Wait for the task to cancel.
        Thread.Sleep(2000);

        Debug.Assert(runTask.IsCanceled);
    }
}
