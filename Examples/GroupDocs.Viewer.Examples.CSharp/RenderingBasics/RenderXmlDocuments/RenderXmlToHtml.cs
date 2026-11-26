namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderXmlDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderXmlToHtml
{
    public static void Run()
    {
        HtmlViewOptions paginatedHtmlOptions = HtmlViewOptions.ForEmbeddedResources("page-{0}.html");
        HtmlViewOptions singleHtmlOptions = HtmlViewOptions.ForEmbeddedResources("single-page.html");
        singleHtmlOptions.RenderToSinglePage = true;

        string inputXmlDocument = "sample.xml";
        using (Viewer viewer = new Viewer(inputXmlDocument))
        {
            viewer.View(paginatedHtmlOptions);
            viewer.View(singleHtmlOptions);
        }
    }
}
