using GroupDocs.Viewer.MVC.Products.Common.Util.Parser;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace GroupDocs.Viewer.MVC.Products.Common.Config
{
    /// <summary>
    /// CommonConfiguration.
    /// </summary>
    public class CommonConfiguration : ConfigurationSection
    {
        [JsonProperty]
        public bool pageSelector { get; set; }

        [JsonProperty]
        public bool download { get; set; }

        [JsonProperty]
        public bool upload { get; set; }

        [JsonProperty]
        public bool print { get; set; }

        [JsonProperty]
        public bool browse { get; set; }

        [JsonProperty]
        public bool rewrite { get; set; }

        [JsonProperty]
        public bool enableRightClick { get; set; }

        private NameValueCollection commonConfiguration = (NameValueCollection)System.Configuration.ConfigurationManager.GetSection("commonConfiguration");

        /// <summary>
        /// Constructor.
        /// </summary>
        public CommonConfiguration()
        {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("common");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);
            pageSelector = valuesGetter.GetBooleanPropertyValue("pageSelector", Convert.ToBoolean(commonConfiguration["isPageSelector"]));
            download = valuesGetter.GetBooleanPropertyValue("download", Convert.ToBoolean(commonConfiguration["isDownload"]));
            upload = valuesGetter.GetBooleanPropertyValue("upload", Convert.ToBoolean(commonConfiguration["isUpload"]));
            print = valuesGetter.GetBooleanPropertyValue("print", Convert.ToBoolean(commonConfiguration["isPrint"]));
            browse = valuesGetter.GetBooleanPropertyValue("browse", Convert.ToBoolean(commonConfiguration["isBrowse"]));
            rewrite = valuesGetter.GetBooleanPropertyValue("rewrite", Convert.ToBoolean(commonConfiguration["isRewrite"]));
            enableRightClick = valuesGetter.GetBooleanPropertyValue("enableRightClick", Convert.ToBoolean(commonConfiguration["enableRightClick"]));
        }
    }
}