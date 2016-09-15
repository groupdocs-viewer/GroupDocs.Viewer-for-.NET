using System;
using System.Runtime.Serialization.Json;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public static class ControllerExtensions
    {
        public static ActionResult JsonOrJsonP(this Controller controller, object data, string callback, bool serialize = true)
        {
            bool isJsonP = (controller.Request != null && controller.Request.HttpMethod == "GET");
            string serializedData;

            if (isJsonP)
            {
                if (serialize)
                {
                    using (var ms = new System.IO.MemoryStream())
                    {
                        var serializer = new DataContractJsonSerializer(data.GetType());
                        serializer.WriteObject(ms, data);
                        serializedData = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
                else
                    serializedData = (string) data;
                string serializedDataWithCallback = String.Format("{0}({1})", callback, serializedData);

                return new ContentResult { Content = serializedDataWithCallback, ContentType = "application/javascript" };
            }

            if (serialize)
            {
                return new JsonDataContractActionResult(data);
            }
            else
            {
                serializedData = (string) data;
                return new ContentResult { Content = serializedData, ContentType = "application/json" };
            }
        }
    }
}
