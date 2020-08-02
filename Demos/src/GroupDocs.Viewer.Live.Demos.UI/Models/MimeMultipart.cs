using System.Web.Http.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Web.Http.Filters;

namespace GroupDocs.Viewer.Live.Demos.UI.Models
{
    public class MimeMultipart : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(
                        HttpStatusCode.UnsupportedMediaType)
                );
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

        }
    }
}