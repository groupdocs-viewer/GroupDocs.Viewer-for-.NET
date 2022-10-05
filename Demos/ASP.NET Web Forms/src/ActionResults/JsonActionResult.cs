using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetWebForms.ActionResults
{
    internal class JsonActionResult : IHttpActionResult
    {
        readonly object _value;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        readonly HttpRequestMessage _request;
            
        public JsonActionResult(object value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(_value, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = new HttpResponseMessage
            {
                Content = content,
                StatusCode = StatusCode,
                RequestMessage = _request
            };

            return Task.FromResult(response);
        }
    }
}