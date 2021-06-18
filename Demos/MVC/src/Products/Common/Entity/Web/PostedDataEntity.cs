using System.Collections.Generic;

namespace GroupDocs.Viewer.MVC.Products.Common.Entity.Web
{
    /// <summary>
    /// DTO-class, representes document with its pages 
    /// posted from the front-end.
    /// </summary>
    public class PostedDataEntity
    {
        /// <summary>
        /// Absolute path to the document.
        /// </summary>
        public string guid { get; set; }

        /// <summary>
        /// Document password.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Page number.
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Page rotation angle.
        /// </summary>
        public int angle { get; set; }

        /// <summary>
        /// Collection of the document pages with their data.
        /// </summary>
        public List<int> pages { get; set; }
    }
}