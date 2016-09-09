using System;
using System.Runtime.Serialization.Json;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class JsonDataContractActionResult : JsonResult
    {
        public JsonDataContractActionResult(Object data)
        {
            this.Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var serializer = new DataContractJsonSerializer(this.Data.GetType());
            context.HttpContext.Response.ContentType = "application/json";
            serializer.WriteObject(context.HttpContext.Response.OutputStream, this.Data);
        }
    }
}
