using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace GroupDocs.Viewer.AspNetWebForms.ActionResults
{
    internal class FileActionResult : IHttpActionResult
    {
        private readonly byte[] _data;
        private readonly string _fileName;
        private readonly string _contentType;
        readonly HttpRequestMessage _request;

        public FileActionResult(byte[] data, string fileName, string contentType, 
            HttpRequestMessage request)
        {
            _data = data;
            _fileName = fileName;
            _contentType = contentType;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage
            {
                Content = new ByteArrayContent(_data),
                StatusCode = HttpStatusCode.OK,
                RequestMessage = _request
            };

            var contentType = string.IsNullOrEmpty(_contentType) 
                ? "application/octet-stream" 
                : _contentType;

            response.Content.Headers.ContentType = 
                new MediaTypeHeaderValue(contentType);
            response.Content.Headers.ContentDisposition = 
                new ContentDispositionHeaderValue("attachment")
                {
                    FileName = _fileName
                };

            return Task.FromResult(response);
        }
    }
}