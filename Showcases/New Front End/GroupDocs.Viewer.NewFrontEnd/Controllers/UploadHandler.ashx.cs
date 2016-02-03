using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace GroupDocs.Viewer.NewFrontEnd.Controllers
{
    /// <summary>
    /// Summary description for MainHandler
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fname = "";
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    //Check If browser is IE
                    if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;

                    }
                    //Check the document type here
                    if (GroupDocs.Viewer.Model.Utilities.checkExtenstion(Path.GetExtension(fname)))
                    {
                        // Save the posted file 
                        fname = Path.Combine(context.Server.MapPath("~/uploads/"), fname);
                        file.SaveAs(fname);
                        
                        //write the file path of successfully saved file.
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(fname);
                    }
                    else
                    {
                    //Generate the response with error code
                        context.Response.ContentType = "text/plain";
                        context.Response.Write("Please upload a valid MS Word file");
                        context.Response.StatusCode = 422;
                    }
                }
            }




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