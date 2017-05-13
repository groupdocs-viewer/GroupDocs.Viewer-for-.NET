using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Routing;
using MvcSample.Models;

namespace MvcSample.Helpers
{
    public static class ImageUrlHelper
    {
        public static string[] GetImageUrls(string applicationHost, int[] pageNumbers, GetImageUrlsParameters parameters)
        {
            return GetImageUrls(applicationHost, parameters.Path, parameters.FirstPage, pageNumbers.Length, parameters.Width,
                parameters.Quality, parameters.UsePdf,
                parameters.WatermarkText, parameters.WatermarkColor, parameters.WatermarkOpacity,
                parameters.WatermarkPosition,
                parameters.WatermarkWidth,
                parameters.IgnoreDocumentAbsence,
                parameters.UseHtmlBasedEngine, parameters.SupportPageRotation,
                parameters.InstanceIdToken,
                null,
                pageNumbers);
        }

        public static string[] GetImageUrls(string applicationHost, int[] pageNumbers, ViewDocumentParameters parameters)
        {
            return GetImageUrls(applicationHost, parameters.Path, 0, pageNumbers.Length, parameters.Width,
                parameters.Quality, parameters.UsePdf,
                parameters.WatermarkText, parameters.WatermarkColor,parameters.WatermarkOpacity,
                parameters.WatermarkPosition,
                parameters.WatermarkWidth,
                parameters.IgnoreDocumentAbsence,
                parameters.UseHtmlBasedEngine, parameters.SupportPageRotation,
                parameters.InstanceIdToken,
                null,
                pageNumbers);
        }

        private static string[] GetImageUrls(string applicationHost, string path, int startingPageNumber, int pageCount, int? pageWidth, int? quality, bool usePdf = true,
                                             string watermarkText = null, int? watermarkColor = null,int? watermarkOpacity=255,
                                             WatermarkPosition? watermarkPosition = WatermarkPosition.Diagonal, float? watermarkWidth = 0,
                                             bool ignoreDocumentAbsence = false,
                                             bool useHtmlBasedEngine = false,
                                             bool supportPageRotation = false,
                                             string instanceId = null,
                                             string locale = null,
                                             int[] pageNumbers = null)
        {
            string[] pageUrls = new string[pageCount];

            RouteValueDictionary routeValueDictionary = new RouteValueDictionary
                {
                    {"path", HttpUtility.UrlEncode(path)},
                    {"width", pageWidth},
                    {"quality", quality},
                    {"usePdf", usePdf},
                    {"useHtmlBasedEngine", useHtmlBasedEngine},
                    {"rotate", supportPageRotation}
                };

            if (!string.IsNullOrWhiteSpace(locale))
                routeValueDictionary.Add("locale", locale);

            if (!string.IsNullOrEmpty(watermarkText))
            {
                routeValueDictionary.Add("watermarkText", watermarkText);
                routeValueDictionary.Add("watermarkColor", watermarkColor);
                routeValueDictionary.Add("watermarkPosition", watermarkPosition);
                routeValueDictionary.Add("watermarkWidth", watermarkWidth);
                routeValueDictionary.Add("watermarkOpacity", watermarkOpacity);
            }

            if (!string.IsNullOrWhiteSpace(instanceId))
                routeValueDictionary.Add("instanceIdToken", instanceId);
            if (ignoreDocumentAbsence)
                routeValueDictionary.Add("ignoreDocumentAbsence", ignoreDocumentAbsence);

            if (pageNumbers != null)
            {
                for (int i = 0; i < pageCount; i++)
                {
                    routeValueDictionary["pageIndex"] = pageNumbers[i] - 1;
                    pageUrls[i] = ConvertUrlToAbsolute(applicationHost, CreateRelativeRequestUrl("GetDocumentPageImage", routeValueDictionary));
                }
            }
            else
            {
                for (int i = 0; i < pageCount; i++)
                {
                    routeValueDictionary["pageIndex"] = startingPageNumber + i;
                    pageUrls[i] = ConvertUrlToAbsolute(applicationHost, CreateRelativeRequestUrl("GetDocumentPageImage", routeValueDictionary));
                }
            }

            return pageUrls;
        }

        private static string ConvertUrlToAbsolute(string applicationHost, string inputUrl)
        {
            string result = string.Format("{0}{1}", applicationHost, inputUrl);
            return result;
        }

        private static string CreateRelativeRequestUrl(string actionName, RouteValueDictionary routeValueDictionary)
        {
            StringBuilder urlBuilder = new StringBuilder("/document-viewer/");
            urlBuilder.Append(actionName);
            if (routeValueDictionary.Count == 0)
            {
                return urlBuilder.ToString();
            }
            urlBuilder.Append("?");
            foreach (KeyValuePair<string, object> oneRoute in routeValueDictionary)
            {
                if (string.IsNullOrWhiteSpace(oneRoute.Key)
                    || oneRoute.Value == null
                    || string.IsNullOrWhiteSpace(oneRoute.Value.ToString()))
                {
                    continue;
                }
                urlBuilder.Append(oneRoute.Key);
                urlBuilder.Append("=");
                string originalValue = oneRoute.Value.ToString();
                string encodedValue = HttpUtility.UrlEncode(originalValue);
                urlBuilder.Append(encodedValue);
                urlBuilder.Append("&");
            }
            urlBuilder.Remove(urlBuilder.Length - 1, 1);//remove last character '&'
            var result = HttpUtility.UrlDecode(urlBuilder.ToString());
            //return urlBuilder.ToString();
            return result;
        }
    }
}