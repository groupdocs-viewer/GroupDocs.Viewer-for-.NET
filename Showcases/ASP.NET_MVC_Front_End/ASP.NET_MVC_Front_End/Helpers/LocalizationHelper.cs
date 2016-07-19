using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;

namespace MvcSample.Helpers
{
    /// <summary>
    /// The localization helper.
    /// </summary>
    public static class LocalizationHelper
    {
        /// <summary>
        /// The resource name template.
        /// </summary>
        const string ResourceNameTemplate = "MvcSample.Resources.LocalizedStrings-{0}.json";

        /// <summary>
        /// Gets localized strings in json representation.
        /// </summary>
        /// <param name="locale">The locale. Supported locales are <see cref="Locales.EnUs"/>, <see cref="Locales.EsEs"/>, 
        /// <see cref="Locales.PtPt"/>, <see cref="Locales.NbNo"/>, <see cref="Locales.PlPl"/>, <see cref="Locales.RuRu"/>,
        /// <see cref="Locales.ArAe"/>, <see cref="Locales.ItIt"/>, <see cref="Locales.ZhCn"/>, <see cref="Locales.ZhTw"/>,
        /// <see cref="Locales.TrTr"/>, <see cref="Locales.FrFr"/>.
        /// </param>
        /// <returns>The localized strings in json representation.</returns>
        public static IHtmlString GetLocalizedStringsJson(Locales locale = Locales.EnUs)
        {
            var resourceName = string.Format(ResourceNameTemplate, GetLocaleName(locale));

            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                    throw new NullReferenceException(string.Format("Resource {0} not found.", resourceName));

                using (StreamReader reader = new StreamReader(resourceStream, Encoding.UTF8))
                    return new HtmlString(reader.ReadToEnd());
            }
        }

        /// <summary>
        /// Gets locale name.
        /// </summary>
        /// <param name="locale">The locale</param>
        /// <returns>The locale name.</returns>
        private static string GetLocaleName(Locales locale)
        {
            switch (locale)
            {
                case Locales.ArAe: return "ar-AE";
                case Locales.EnUs: return "en-US";
                case Locales.EsEs: return "es-ES";
                case Locales.FrFr: return "fr-FR";
                case Locales.PtPt: return "pt-PT";
                case Locales.NbNo: return "nb-NO";
                case Locales.PlPl: return "pl-PL";
                case Locales.RuRu: return "ru-RU";
                case Locales.ItIt: return "it-IT";
                case Locales.ZhCn: return "zh-CN";
                case Locales.ZhTw: return "zh-TW";
                case Locales.TrTr: return "tr-TR";
                default:
                    throw new ArgumentOutOfRangeException("locale");
            }
        }
    }
}