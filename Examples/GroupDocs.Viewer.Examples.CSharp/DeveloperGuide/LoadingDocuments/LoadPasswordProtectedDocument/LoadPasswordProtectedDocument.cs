namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadPasswordProtectedDocument;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadPasswordProtectedDocument
{
    public static void Run()
    {
        // ...

        // Specify a password.
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.Password = "123456";
        // Render a file.
        using (Viewer viewer = new Viewer("encrypted.docx", loadOptions))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }
    }
}
