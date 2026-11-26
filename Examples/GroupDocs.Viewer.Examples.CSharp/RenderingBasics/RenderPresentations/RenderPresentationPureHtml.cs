namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPresentations;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPresentationPureHtml
{
    public static void Run()
    {
        // ...
        string inputPresentationPath = "sample.pptx";

        //preparing HTML options for embedded and external resources
        HtmlViewOptions embeddedOptions = HtmlViewOptions.ForEmbeddedResources("slide_{0}_embedded.html");
        HtmlViewOptions externalOptions = HtmlViewOptions.ForExternalResources("slide_{0}.html", "slide_{0}_{1}", "slide_{0}_{1}");
        //enabling the pure HTML/CSS mode for both options
        embeddedOptions.PresentationOptions.RenderToPureHtml = externalOptions.PresentationOptions.RenderToPureHtml = true;

        using (Viewer viewer = new Viewer(inputPresentationPath))
        {
            viewer.View(embeddedOptions);
            viewer.View(externalOptions);
        }
    }
}
