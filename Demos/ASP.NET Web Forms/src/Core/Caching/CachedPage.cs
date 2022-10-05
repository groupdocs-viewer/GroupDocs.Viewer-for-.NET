namespace GroupDocs.Viewer.AspNetWebForms.Core.Caching
{
    internal class CachedPage
    {
        /// <summary>
        /// The page number.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// The data. Can be null.
        /// </summary>
        public byte[] Data { get; }

        public CachedPage(int pageNumber, byte[] data)
        {
            PageNumber = pageNumber;
            Data = data;
        }
    }
}