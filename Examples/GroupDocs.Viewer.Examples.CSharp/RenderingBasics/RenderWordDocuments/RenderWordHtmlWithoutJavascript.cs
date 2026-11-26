namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordHtmlWithoutJavascript
{
    public static void Run()
    {
        // ...

        HtmlViewOptions htmlViewOptionsWithoutJavaScript = HtmlViewOptions.ForEmbeddedResources("without-js-page{0}.html");

        HtmlViewOptions htmlViewOptionsWithJavaScript = HtmlViewOptions.ForEmbeddedResources("with-js-page{0}.html");
        htmlViewOptionsWithJavaScript.RemoveJavaScript = false;

        using (var viewer = new Viewer("with_script.docx"))
        {
            viewer.View(htmlViewOptionsWithoutJavaScript);
            viewer.View(htmlViewOptionsWithJavaScript);
        }
    }
}
