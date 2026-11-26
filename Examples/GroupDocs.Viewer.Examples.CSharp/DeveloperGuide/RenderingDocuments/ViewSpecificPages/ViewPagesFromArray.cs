namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.ViewSpecificPages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class ViewPagesFromArray
{
    public static void Run()
    {
        // ...

        // Create an array and specify page numbers.
        int[] pageNumbers = new int[] { 1, 2, 4 };

        using (Viewer viewer = new Viewer("sample.docx"))
        {
           // Create view options.
           var viewOptions = HtmlViewOptions.ForEmbeddedResources();

           // Use array to render specific pages.
           viewer.View(viewOptions, pageNumbers);
        }
    }
}
