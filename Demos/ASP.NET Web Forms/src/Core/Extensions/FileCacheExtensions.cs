using System;
using System.Threading.Tasks;

namespace GroupDocs.Viewer.AspNetWebForms.Core.Extensions
{
    public static class FileCacheExtensions
    {
        /// <summary>
        /// Gets the entry associated with this key if present or acquires and sets the entry if not present.
        /// </summary>
        /// <typeparam name="TEntry">Type of entry.</typeparam>
        /// <param name="cache">The cache.</param>
        /// <param name="cacheKey">A key identifying the requested entry.</param>
        /// <param name="filePath">The source file relative file path.</param>
        /// <param name="acquire">The method which returns entry.</param>
        /// <returns>The entry associated with this key if present or acquires and sets the entry if not present.</returns>
        public static async Task<TEntry> GetValueAsync<TEntry>(this IFileCache cache, string cacheKey, string filePath, Func<Task<TEntry>> acquire)
        {
            var entry = await cache.TryGetValueAsync<TEntry>(cacheKey, filePath);
            if (entry == null)
            {
                entry = await acquire();
                await cache.SetAsync(cacheKey, filePath, entry);
            }

            return entry;
        }
    }
}