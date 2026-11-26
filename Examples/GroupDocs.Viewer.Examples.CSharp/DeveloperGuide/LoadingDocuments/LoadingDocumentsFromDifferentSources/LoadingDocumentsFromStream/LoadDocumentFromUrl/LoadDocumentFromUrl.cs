namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingDocumentsFromDifferentSources.LoadingDocumentsFromStream.LoadDocumentFromUrl;

using System.IO;
using System.Net;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadDocumentFromUrl
{
    public static void Run()
    {
        // ...

        string url = "https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/blob/master/Examples/GroupDocs.Viewer.Examples.CSharp/Resources/SampleFiles/sample.docx?raw=true";

        Stream stream = DownloadFile(url);

        using (Viewer viewer = new Viewer(stream, new LoadOptions(FileType.DOCX)))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }

        static Stream DownloadFile(string url)
        {
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = request.GetResponse())
                return GetFileStream(response);
        }

        static Stream GetFileStream(WebResponse response)
        {
            MemoryStream fileStream = new MemoryStream();
            using (Stream responseStream = response.GetResponseStream())
                responseStream.CopyTo(fileStream);
            fileStream.Position = 0;
            return fileStream;
        }
    }
}
