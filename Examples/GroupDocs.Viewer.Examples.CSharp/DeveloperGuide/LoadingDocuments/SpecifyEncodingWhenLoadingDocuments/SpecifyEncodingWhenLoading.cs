namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.SpecifyEncodingWhenLoadingDocuments;

using System.Text;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SpecifyEncodingWhenLoading
{
    public static void Run()
    {
        // ...

        // .NET 6 and later need this once to know code-page encodings such as Shift_JIS
        // (.NET Framework knows them already).
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        // Specify an encoding.
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.Encoding = Encoding.GetEncoding("shift_jis");
        // Render a file.
        using (Viewer viewer = new Viewer("sample-shift-jis.txt", loadOptions))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }
    }
}
