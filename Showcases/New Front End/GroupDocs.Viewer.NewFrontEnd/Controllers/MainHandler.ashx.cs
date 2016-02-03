using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupDocs.Viewer.Model;
using System.Web.Script.Serialization;
using GroupDocs.Viewer.Model.BusinessObjects;
using System.IO;

namespace GroupDocs.Viewer.NewFrontEnd.Controllers
{
    /// <summary>
    /// Summary description for MainHandler
    /// </summary>
    public class MainHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
             // Check the action variable in ajax http request 
            if (context.Request["action"].ToString() == "renderashtml")
            {
               // File path is also included in the http request
                String FilePath = context.Request["filepath"].ToString();
                List<HtmlInfo> lstPages= ViewGenerator.RenderDocumentAsHtml(FilePath);
                GenerateResponse(lstPages, context);
               
            }
            else if (context.Request["action"].ToString() == "renderashtmlwithwatermark")
            {
                String FilePath = context.Request["filepath"].ToString();
                String WatermarkText = context.Request["watermark"].ToString();
                List<HtmlInfo> lstPages = ViewGenerator.RenderDocumentAsHtml(FilePath,WatermarkText,System.Drawing.Color.Red);
                GenerateResponse(lstPages, context);
            }
            else if (context.Request["action"].ToString() == "renderashtmlwithreorder")
            {
                String FilePath = context.Request["filepath"].ToString();
                int startIndex = int.Parse(context.Request["start"].ToString());
                int newIndex = int.Parse(context.Request["new"].ToString());
                List<HtmlInfo> lstPages = ViewGenerator.RenderDocumentAsHtml(FilePath,startIndex,newIndex+1);
                GenerateResponse(lstPages, context);
            }
            else if (context.Request["action"].ToString() == "renderashtmlwithrotate")
            {
                String FilePath = context.Request["filepath"].ToString();
                int pageId = int.Parse(context.Request["page"].ToString());
                int angle = int.Parse(context.Request["angle"].ToString());
                List<HtmlInfo> lstPages = ViewGenerator.RotateDocumentAsHtml(FilePath,pageId,angle);
                GenerateResponse(lstPages, context);
            }
            if (context.Request["action"].ToString() == "renderasimage")
            {
                // File path is also included in the http request
                String FilePath = context.Request["filepath"].ToString();
                List<ImageInfo> lstPages = ViewGenerator.RenderDocumentAsImages(FilePath);
                GenerateResponse(lstPages, context);

            }
            else if (context.Request["action"].ToString() == "renderasimagewithwatermark")
            {
                String FilePath = context.Request["filepath"].ToString();
                String WatermarkText = context.Request["watermark"].ToString();
                List<ImageInfo> lstPages = ViewGenerator.RenderDocumentAsImages(FilePath, WatermarkText,System.Drawing.Color.Red);
                GenerateResponse(lstPages, context);
            }
            else if (context.Request["action"].ToString() == "renderasimagewithreorder")
            {
                String FilePath = context.Request["filepath"].ToString();
                int startIndex = int.Parse(context.Request["start"].ToString());
                int newIndex = int.Parse(context.Request["new"].ToString());
                List<ImageInfo> lstPages = ViewGenerator.RenderDocumentAsImages(FilePath, startIndex, newIndex + 1);
                GenerateResponse(lstPages, context);
            }
            else if (context.Request["action"].ToString() == "renderasimagewithrotate")
            {
                String FilePath = context.Request["filepath"].ToString();
                int pageId = int.Parse(context.Request["page"].ToString());
                int angle = int.Parse(context.Request["angle"].ToString());
                List<ImageInfo> lstPages = ViewGenerator.RotateDocumentAsImages(FilePath, pageId, angle);
                GenerateResponse(lstPages, context);
            }
        }
        public void GenerateResponse(object obj, HttpContext context)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = int.MaxValue;
            string serObj = javaScriptSerializer.Serialize(obj);
            context.Response.ContentType = "text/html";
            context.Response.Write(serObj);
        }
        public void GenerateFile(Stream obj, HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/pdf";
           // context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
           // context.Response.BinaryWrite(;
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}