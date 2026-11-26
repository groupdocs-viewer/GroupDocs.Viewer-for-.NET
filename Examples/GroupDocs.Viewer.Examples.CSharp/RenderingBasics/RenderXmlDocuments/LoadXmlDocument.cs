namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderXmlDocuments;

using System.IO;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadXmlDocument
{
    public static void Run()
    {
        // 1. Specify by filename
        string inputXmlDocument = "sample.xml";
        using (Viewer viewer = new Viewer(inputXmlDocument))
        {
            // do some work...
        }

        //2. Specify by filename and FileStream
        string inputXmlPath = "sample.xml";
        using (FileStream inputXmlFileStream = File.OpenRead(inputXmlPath))
        using (Viewer viewer = new Viewer(inputXmlFileStream))
        {
            // do some work...
        }

        // 3. Specify by load options
        MemoryStream xmlContent = new MemoryStream();
        // fill MemoryStream with content of XML document
        GroupDocs.Viewer.Options.LoadOptions loadOptions = new LoadOptions(FileType.XML);
        using (Viewer viewer = new Viewer(xmlContent, loadOptions))
        {
            // do some work...
        }
    }
}
