using GroupDocs.Viewer.Handler;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Viewer_Modren_UI.Helpers;

namespace WebForm_Modern_UI.Controllers
{
    public class DownloadOriginalController : ApiController
    {
        public HttpResponseMessage Get(string file)
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            Stream original = null;
            try
            {
                original = handler.GetFile(file).Stream;
            }
            catch (Exception x)
            {
                throw x;
            }

            using (var ms = new MemoryStream())
            {
                original.CopyTo(ms);
                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(ms.ToArray())
                };
                result.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = file
                    };
                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                return result;

            }
        }
    }
}