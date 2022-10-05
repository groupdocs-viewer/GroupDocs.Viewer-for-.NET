using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace GroupDocs.Viewer.AspNetWebForms.ActionResults
{
    internal class ResourceActionResult : IHttpActionResult
    {
        private readonly byte[] _data;
        private readonly string _contentType;
        readonly HttpRequestMessage _request;

        public ResourceActionResult(byte[] data, string contentType, HttpRequestMessage request)
        {
            _data = data;
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

            response.Content.Headers.ContentType = 
                new MediaTypeHeaderValue(_contentType);
            response.Content.Headers.ContentDisposition 
                = new ContentDispositionHeaderValue("inline");

            return Task.FromResult(response);
        }
    }
}