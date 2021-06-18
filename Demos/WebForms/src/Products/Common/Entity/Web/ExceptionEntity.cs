namespace GroupDocs.Viewer.WebForms.Products.Common.Entity.Web
{
    /// <summary>
    /// DTO-class, represents exception entity.
    /// </summary>
    public class ExceptionEntity
    {
        /// <summary>
        /// Exception message.
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Exception object.
        /// </summary>
        public System.Exception exception { get; set; }
    }
}