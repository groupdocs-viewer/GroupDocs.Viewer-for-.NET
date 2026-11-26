namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.SearchHighlightText;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class HighlightRegexMatchesInPdf
{
    public static void Run()
    {
        // ...

        // The search term is a regular expression
        SearchHighlightOptions searchOptions = new SearchHighlightOptions()
        {
            SearchTerm = @"CF-\d{3}",
            IsSearchTermRegEx = true
        };

        using (Viewer viewer = new Viewer("sample.pdf"))
        {
            // Search first, then render: the found text is highlighted in the output
            viewer.Search(searchOptions);
            viewer.View(new PngViewOptions());
        }
    }
}
