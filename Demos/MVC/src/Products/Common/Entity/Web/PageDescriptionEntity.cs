using Newtonsoft.Json;

namespace GroupDocs.Viewer.MVC.Products.Common.Entity.Web
{
    /// <summary>
    /// DTO-class, represents document page data, dimensions and rotation angle.
    /// </summary>
    public class PageDescriptionEntity
    {
        /// <summary>
        /// Page width.
        /// </summary>
        public double width{ get; set; }

        /// <summary>
        /// Page height.
        /// </summary>
        public double height{ get; set; }

        /// <summary>
        /// Page number.
        /// </summary>
        public int number{ get; set; }

        /// <summary>
        /// Page rotation angle.
        /// </summary>
        public int angle { get; set; }

        /// <summary>
        /// Page content data.
        /// </summary>
        [JsonProperty]
        private string data;

        /// <summary>
        /// Sheet name.
        /// </summary>
        public string sheetName { get; set; }

        public void SetData(string data)
        {
            this.data = data;
        }

        public string GetData()
        {
            return this.data;
        }
    }
}