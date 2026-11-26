namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.SearchHighlightText;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class HighlightWordInWordDocument
{
    public static void Run()
    {
        // ...

        // The search term is a text literal
        SearchHighlightOptions searchOptions = new SearchHighlightOptions()
        {
            SearchTerm = "Buyer",
            IsSearchTermRegEx = false
        };

        using (Viewer viewer = new Viewer("contract.docx"))
        {
            // Search first, then render: the found text is highlighted in the output
            viewer.Search(searchOptions);
            viewer.View(HtmlViewOptions.ForEmbeddedResources());
        }
    }
}
