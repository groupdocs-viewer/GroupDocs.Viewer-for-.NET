namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.CachingResults;

using System.Diagnostics;
using System.IO;
using System;
using GroupDocs.Viewer.Caching;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class CacheRenderingResults
{
    public static void Run()
    {
        // ...

        string outputDirectory = "output";
        string cachePath = Path.Combine(outputDirectory, "cache");
        string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
        // Create a cache.
        FileCache cache = new FileCache(cachePath);
        ViewerSettings settings = new ViewerSettings(cache);

        using (Viewer viewer = new Viewer("sample.docx", settings))
        {
            // Create an HTML file.
            HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
            // Render and display the rendering time.
            Stopwatch stopWatch = Stopwatch.StartNew();
            viewer.View(options);
            stopWatch.Stop();
            Console.WriteLine("Time taken on first call to View method {0} (ms).", stopWatch.ElapsedMilliseconds);
            // Get cached results and display the time.
            stopWatch.Restart();
            viewer.View(options);
            stopWatch.Stop();
            Console.WriteLine("Time taken on second call to View method {0} (ms).", stopWatch.ElapsedMilliseconds);
        }
    }
}
