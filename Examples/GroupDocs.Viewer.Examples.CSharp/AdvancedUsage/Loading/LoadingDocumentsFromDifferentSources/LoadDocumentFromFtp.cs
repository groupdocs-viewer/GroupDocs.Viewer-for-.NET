using System;
using System.IO;
using System.Net;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Loading.LoadingDocumentsFromDifferentSources
{
    /// <summary>
    /// This example demonstrates how to render document downloaded from FTP.
    /// </summary>
    class LoadDocumentFromFtp
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
            string filePath = "ftp://localhost/sample.doc";

            using (Viewer viewer = new Viewer(() => GetFileFromFtp(filePath)))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }

        private static Stream GetFileFromFtp(string filePath)
        {
            Uri uri = new Uri(filePath);
            FtpWebRequest request = CreateRequest(uri);

            using (WebResponse response = request.GetResponse())
                return GetFileStream(response);
        }

        private static FtpWebRequest CreateRequest(Uri uri)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            return request;
        }

        private static Stream GetFileStream(WebResponse response)
        {
            MemoryStream fileStream = new MemoryStream();

            using (Stream responseStream = response.GetResponseStream())
                responseStream.CopyTo(fileStream);

            fileStream.Position = 0;
            return fileStream;
        }
    }
}
