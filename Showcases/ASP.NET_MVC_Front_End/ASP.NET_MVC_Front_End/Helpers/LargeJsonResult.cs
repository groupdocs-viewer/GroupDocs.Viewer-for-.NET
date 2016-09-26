using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MvcSample.Helpers
{
    public class LargeJsonResult : JsonResult
    {
        const string JsonRequestGetNotAllowed = "This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.";

        public LargeJsonResult()
        {
            _MaxJsonLength = 64 * 1024 * 1024;
            _RecursionLimit = 100;
        }

        public int _MaxJsonLength { get; set; }

        public int _RecursionLimit { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(JsonRequestGetNotAllowed);
            }

            HttpResponseBase response = context.HttpContext.Response;

            if (!String.IsNullOrWhiteSpace(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer() { MaxJsonLength = _MaxJsonLength, RecursionLimit = _RecursionLimit };
                string output = serializer.Serialize(Data);
                response.Write(output);
            }
        }
    }
}