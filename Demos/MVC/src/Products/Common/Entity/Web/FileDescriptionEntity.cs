namespace GroupDocs.Viewer.MVC.Products.Common.Entity.Web
{
    /// <summary>
    /// DTO-class, represents file or directory.
    /// </summary>
    public class FileDescriptionEntity
    {
        /// <summary>
        /// Absolute path to the file/directory.
        /// </summary>
        public string guid{ get; set; }

        /// <summary>
        /// Name of the file/directory.
        /// </summary>
        public string name{ get; set; }

        /// <summary>
        /// File or directory flag.
        /// </summary>
        public bool isDirectory{ get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        public long size{ get; set; }
    }
}