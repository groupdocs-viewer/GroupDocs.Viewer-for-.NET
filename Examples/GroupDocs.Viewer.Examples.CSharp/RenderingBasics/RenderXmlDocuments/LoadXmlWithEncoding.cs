namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderXmlDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadXmlWithEncoding
{
    public static void Run()
    {
        LoadOptions loadOpts = new LoadOptions(FileType.XML);
        loadOpts.Encoding = System.Text.Encoding.ASCII;
        using (Viewer viewer = new Viewer(xmlContent, loadOpts))
        {
            // do some work...
        }
    }
}
