namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingDocumentsFromDifferentSources.LoadingDocumentsFromStream.LoadDocumentFromAmazonS3Storage;

using System.IO;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Amazon.S3;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LoadDocumentFromAmazonS3
{
    public static async Task RunAsync()
    {
        // ...

        string key = "sample.docx";
        Stream stream = await DownloadFileAsync(key);

        using (Viewer viewer = new Viewer(stream))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }

        static async Task<Stream> DownloadFileAsync(string key)
        {
            AmazonS3Client client = new AmazonS3Client();
            string bucketName = "my-bucket";
            GetObjectRequest request = new GetObjectRequest
            {
                Key = key,
                BucketName = bucketName
            };

            using (GetObjectResponse response = await client.GetObjectAsync(request))
            {
                stream = new MemoryStream();
                response.ResponseStream.CopyTo(stream);
                stream.Position = 0;
                return stream;
            }
        }
    }
}
