using System;
using Microsoft.SharePoint.WebControls;
using GroupDocs.Viewer.Handler;
using System.IO;

using System.Web;
using ViewerModernWebPart.Helpers;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Options;

namespace ViewerModernWebPart.Layouts.ViewerModernWebPart
{
    public partial class DownloadPdf : LayoutsPageBase
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            var file = GetValueFromQueryString("file");

            string watermarkText = GetValueFromQueryString("watermarkText");
            int? watermarkColor = Convert.ToInt32(GetValueFromQueryString("watermarkColor"));
            WatermarkPosition watermarkPosition = (WatermarkPosition)Enum.Parse(typeof(WatermarkPosition), GetValueFromQueryString("watermarkPosition"), true);
            string widthFromQuery = GetValueFromQueryString("watermarkWidth");
            int? watermarkWidth = GetValueFromQueryString("watermarkWidth") == "null" || GetValueFromQueryString("watermarkWidth") == "" ? null : (int?)Convert.ToInt32(GetValueFromQueryString("watermarkWidth"));
            byte watermarkOpacity = Convert.ToByte(GetValueFromQueryString("watermarkOpacity"));

            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();

            Stream pdf = null;
            try
            {
                PdfFileOptions o = new PdfFileOptions();
                if (watermarkText != "")
                    o.Watermark = Utils.GetWatermark(watermarkText, watermarkColor, watermarkPosition, watermarkWidth, watermarkOpacity);
                pdf = handler.GetPdfFile(file,o).Stream;
            }
            catch (Exception x)
            {
                throw x;
            }
            using (var ms = new MemoryStream())
            {
                pdf.CopyTo(ms);
                ms.WriteTo(HttpContext.Current.Response.OutputStream);
                Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileNameWithoutExtension(file) + ".pdf");
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }
        private String GetValueFromQueryString(String value)
        {
            try
            {
                return Request.QueryString[value].ToString();

            }
            catch (System.Exception exp)
            {
                return String.Empty;
            }
        }   
    }
}
