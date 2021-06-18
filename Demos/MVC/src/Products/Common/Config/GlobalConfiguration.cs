using GroupDocs.Viewer.MVC.Products.Viewer.Config;

namespace GroupDocs.Viewer.MVC.Products.Common.Config
{
    /// <summary>
    /// Global configuration.
    /// </summary>
    public class GlobalConfiguration
    {
        public ServerConfiguration Server { get; set; }
        public ApplicationConfiguration Application { get; set; }
        public CommonConfiguration Common { get; set; }
        public ViewerConfiguration Viewer { get; set; }

        /// <summary>
        /// Get all configurations.
        /// </summary>
        public GlobalConfiguration()
        {
            this.Server = new ServerConfiguration();
            this.Application = new ApplicationConfiguration();
            this.Viewer = new ViewerConfiguration();
            this.Common = new CommonConfiguration();
        }
    }
}