namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingDocumentsFromDifferentSources.LoadingDocumentsFromStream.LoadDocumentFromFtp;

using System.IO;
using System.Net;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadDocumentFromFtp
{
    public static void Run()
    {
        // ...

        Stream stream = GetFileFromFtp("sample.docx");
        using (Viewer viewer = new Viewer(stream))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }

        static Stream GetFileFromFtp(string filePath)
        {
            Uri uri = new Uri(filePath);
            FtpWebRequest request = CreateRequest(uri);
            using (WebResponse response = request.GetResponse())
                return GetFileStream(response);
        }

        static FtpWebRequest CreateRequest(Uri uri)
        {
            request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            return request;
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
