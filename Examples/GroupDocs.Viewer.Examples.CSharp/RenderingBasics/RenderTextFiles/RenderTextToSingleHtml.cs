namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderTextFiles;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderTextToSingleHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("terms_of_service.txt"))
        {
            // Convert the text file to HTML.
            // Specify the output file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("output.html");
            // Render the file to a single page. 
            viewOptions.RenderToSinglePage = true;
            viewer.View(viewOptions);
        }
    }
}
