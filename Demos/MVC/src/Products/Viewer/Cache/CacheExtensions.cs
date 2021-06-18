using System;

namespace GroupDocs.Viewer.MVC.Products.Viewer.Cache
{
    /// <summary>
    /// CacheExtensions.
    /// </summary>
    internal static class CacheExtensions
    {
        /// <summary>
        /// Gets the entry associated with this key if present or acquires and sets the entry if not present.
        /// </summary>
        /// <typeparam name="TEntry">Type of entry.</typeparam>
        /// <param name="cache">The cache.</param>
        /// <param name="key">A key identifying the requested entry.</param>
        /// <param name="acquire">The method which returns entry.</param>
        /// <returns>The entry associated with this key if present or acquires and sets the entry if not present.</returns>
        public static TEntry GetValue<TEntry>(this IViewerCache cache, string key, Func<TEntry> acquire)
        {
            TEntry entry;
            if (!cache.TryGetValue(key, out entry))
            {
                entry = acquire();
                cache.Set(key, entry);
            }

            return entry;
        }
    }
}