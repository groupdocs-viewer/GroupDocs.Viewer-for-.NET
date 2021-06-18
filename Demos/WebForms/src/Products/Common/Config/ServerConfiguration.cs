using GroupDocs.Viewer.WebForms.Products.Common.Util.Parser;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace GroupDocs.Viewer.WebForms.Products.Common.Config
{
    /// <summary>
    /// Server configuration.
    /// </summary>
    public class ServerConfiguration : ConfigurationSection
    {
        public int HttpPort { get; set; } = 8080;
        private readonly string HostAddress = "localhost";
        private readonly NameValueCollection serverConfiguration = (NameValueCollection)System.Configuration.ConfigurationManager.GetSection("serverConfiguration");

        /// <summary>
        /// Get server configuration section of the web.config.
        /// </summary>
        public ServerConfiguration()
        {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("server");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);
            int defaultPort = Convert.ToInt32(this.serverConfiguration["httpPort"]);
            this.HttpPort = valuesGetter.GetIntegerPropertyValue("connector", defaultPort, "port");
            this.HostAddress = valuesGetter.GetStringPropertyValue("hostAddress", this.HostAddress);
        }
    }
}