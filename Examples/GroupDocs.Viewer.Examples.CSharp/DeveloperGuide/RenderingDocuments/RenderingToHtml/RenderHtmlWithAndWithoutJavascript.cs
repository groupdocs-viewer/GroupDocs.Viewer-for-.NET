namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderHtmlWithAndWithoutJavascript
{
    public static void Run()
    {
        // ...

        HtmlViewOptions withoutJavaScriptEmbedded = HtmlViewOptions.ForEmbeddedResources("without-js-page{0}.html");

        HtmlViewOptions withJavaScriptExternal = HtmlViewOptions.ForExternalResources("with-js-page{0}.html", "with-js-page{0}/resource-{1}", "with-js-page{0}/resource-{1}");
        withJavaScriptExternal.RemoveJavaScript = false;

        using (var viewer = new Viewer("with_script.xlsx"))
        {
            viewer.View(withoutJavaScriptEmbedded);
            viewer.View(withJavaScriptExternal);
        }
    }
}
