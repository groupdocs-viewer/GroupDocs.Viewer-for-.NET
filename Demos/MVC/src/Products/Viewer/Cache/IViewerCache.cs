namespace GroupDocs.Viewer.MVC.Products.Viewer.Cache
{
    /// <summary>
    /// Defines methods required for storing rendered document and document resources сache.
    /// </summary>
    interface IViewerCache
    {
        /// <summary>
        /// The Relative or absolute path to the cache folder.
        /// </summary>
        string CachePath { get; }

        /// <summary>
        /// The sub-folder to append to the <see cref="CachePath"/>.
        /// </summary>
        string CacheSubFolder { get; }

        /// <summary>
        /// Inserts a cache entry into the cache.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The object to insert.</param>
        void Set(string key, object value);


        T GetValue<T>(string key);

        /// <summary>
        /// Gets the entry associated with this key if present.
        /// </summary>
        /// <typeparam name="TEntry">Type of entry.</typeparam>
        /// <param name="key">A key identifying the requested entry.</param>
        /// <param name="value">The located value or null.</param>
        /// <returns><code>True</code> if the key was found.</returns>
        bool TryGetValue<TEntry>(string key, out TEntry value);

        /// <summary>
        /// Gets cache file path;.
        /// </summary>
        /// <param name="key">The cache file key.</param>
        /// <returns>Cache file path.</returns>
        string GetCacheFilePath(string key);

        bool Contains(string key);
    }
}