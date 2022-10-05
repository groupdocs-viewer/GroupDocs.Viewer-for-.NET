namespace GroupDocs.Viewer.AspNetWebForms.Core.Caching
{
    public static class CacheKeys
    {
        public const string FILE_INFO_CACHE_KEY = "info.json";
        public const string PDF_FILE_CACHE_KEY = "file.pdf";

        public static string GetHtmlPageResourceCacheKey(int pageNumber, string resourceName) 
            => $"p{pageNumber}_{resourceName}";

        public static string GetPageCacheKey(int pageNumber, string extension) => 
            $"p{pageNumber}{extension}";
    }
}