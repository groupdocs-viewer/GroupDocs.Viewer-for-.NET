using Newtonsoft.Json;

namespace GroupDocs.Viewer.WebForms.Products.Viewer.Entity.Web
{
    /// <summary>
    /// RotatedPageEntity.
    /// </summary>
    public class RotatedPageEntity
    {
        [JsonProperty]
        private int pageNumber;

        [JsonProperty]
        private string angle;

        public void SetPageNumber(int number)
        {
            this.pageNumber = number;
        }

        public int GetPageNumber()
        {
            return this.pageNumber;
        }

        public void SetAngle(string angle)
        {
            this.angle = angle;
        }

        public string GetAngle()
        {
            return this.angle;
        }
    }
}