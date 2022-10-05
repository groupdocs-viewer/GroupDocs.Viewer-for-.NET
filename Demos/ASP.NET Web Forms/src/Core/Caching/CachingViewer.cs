using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupDocs.Viewer.AspNetWebForms.Core.Entities;
using GroupDocs.Viewer.AspNetWebForms.Core.Extensions;

namespace GroupDocs.Viewer.AspNetWebForms.Core.Caching
{
    public class CachingViewer : IViewer
    {
        private readonly IViewer _viewer;
        private readonly IFileCache _fileCache;
        private readonly IAsyncLock _asyncLock;

        public string PageExtension =>
            _viewer.PageExtension;

        public Page CreatePage(int pageNumber, byte[] data) =>
            _viewer.CreatePage(pageNumber, data);

        public CachingViewer(IViewer viewer, IFileCache fileCache, IAsyncLock asyncLock)
        {
            _viewer = viewer;
            _fileCache = fileCache;
            _asyncLock = asyncLock;
        }

        public async Task<Pages> GetPagesAsync(FileCredentials fileCredentials, int[] pageNumbers)
        {
            var pagesOrNulls = GetPagesOrNullsFromCache(fileCredentials.FilePath, pageNumbers);
            var missingPageNumbers = GetMissingPageNumbers(pagesOrNulls);

            if (missingPageNumbers.Length == 0)
                return ToPages(pagesOrNulls);

            var createdPages = await CreatePages(fileCredentials, missingPageNumbers);

            var pages = Combine(pagesOrNulls, createdPages);

            return pages;
        }

        public async Task<Page> GetPageAsync(FileCredentials fileCredentials, int pageNumber)
        {
            var cacheKey = CacheKeys.GetPageCacheKey(pageNumber, PageExtension);
            var bytes = await _fileCache.GetValueAsync(cacheKey, fileCredentials.FilePath, async () =>
            {
                using (await _asyncLock.LockAsync(fileCredentials.FilePath))
                {
                    return await _fileCache.GetValueAsync(cacheKey, fileCredentials.FilePath, async () =>
                    {
                        var newPage = await _viewer.GetPageAsync(fileCredentials, pageNumber);

                        await SaveResourcesAsync(fileCredentials.FilePath, newPage.PageNumber, newPage.Resources);

                        return newPage.Data;
                    });
                }
            });

            var page = CreatePage(pageNumber, bytes);
            return page;
        }

        public Task<DocumentInfo> GetDocumentInfoAsync(FileCredentials fileCredentials)
        {
            var cacheKey = CacheKeys.FILE_INFO_CACHE_KEY;
            return _fileCache.GetValueAsync(cacheKey, fileCredentials.FilePath, async () =>
            {
                using (await _asyncLock.LockAsync(fileCredentials.FilePath))
                {
                    return await _fileCache.GetValueAsync(cacheKey, fileCredentials.FilePath, () =>
                        _viewer.GetDocumentInfoAsync(fileCredentials));
                }
            });
        }

        public Task<byte[]> GetPdfAsync(FileCredentials fileCredentials)
        {
            var cacheKey = CacheKeys.PDF_FILE_CACHE_KEY;
            return _fileCache.GetValueAsync(cacheKey, fileCredentials.FilePath, async () =>
            {
                using (await _asyncLock.LockAsync(fileCredentials.FilePath))
                {
                    return await _fileCache.GetValueAsync(cacheKey, fileCredentials.FilePath, () =>
                        _viewer.GetPdfAsync(fileCredentials));
                }
            });
        }

        public Task<byte[]> GetPageResourceAsync(FileCredentials fileCredentials, int pageNumber,
            string resourceName)
        {
            var cacheKey = CacheKeys.GetHtmlPageResourceCacheKey(pageNumber, resourceName);
            return _fileCache.GetValueAsync(cacheKey, fileCredentials.FilePath,
                async () =>
                {
                    using (await _asyncLock.LockAsync(fileCredentials.FilePath))
                    {
                        return await _fileCache.GetValueAsync(cacheKey, fileCredentials.FilePath, () =>
                            _viewer.GetPageResourceAsync(fileCredentials, pageNumber, resourceName));
                    }
                });
        }

        private async Task SaveResourcesAsync(string filePath, int pageNumber, IEnumerable<PageResource> pageResources)
        {
            var tasks = pageResources.Select(resource =>
            {
                var resourceCacheKey =
                    CacheKeys.GetHtmlPageResourceCacheKey(pageNumber, resource.ResourceName);

                return _fileCache.SetAsync(resourceCacheKey, filePath, resource.Data);
            });

            await Task.WhenAll(tasks);
        }

        private async Task<Pages> CreatePages(FileCredentials fileCredentials, int[] pageNumbers)
        {
            using (await _asyncLock.LockAsync(fileCredentials.FilePath))
            {
                var pagesOrNulls = GetPagesOrNullsFromCache(fileCredentials.FilePath, pageNumbers);
                var missingPageNumbers = GetMissingPageNumbers(pagesOrNulls);

                if (missingPageNumbers.Length == 0)
                    return ToPages(pagesOrNulls);

                var createdPages = await _viewer.GetPagesAsync(fileCredentials, missingPageNumbers);

                await SaveToCache(fileCredentials.FilePath, createdPages);

                var pages = Combine(pagesOrNulls, createdPages);

                return pages;
            }   
        }

        private Pages Combine(List<CachedPage> dst, Pages missing)
        {
            var pages = dst
                .Select(pageOrNull =>
                {
                    if (pageOrNull.Data == null)
                    {
                        var page = missing
                            .Where(p => p.PageNumber == pageOrNull.PageNumber)
                            .Select(p => p)
                            .FirstOrDefault();

                        return page;
                    }

                    return CreatePage(pageOrNull.PageNumber, pageOrNull.Data);
                }).ToList();

            return new Pages(pages);
        }

        private Task SaveToCache(string filePath, Pages createdPages)
        {
            var tasks = createdPages
                .SelectMany(page =>
                {
                    var cacheKey = CacheKeys.GetPageCacheKey(page.PageNumber, _viewer.PageExtension);

                    var savePageTask = _fileCache.SetAsync(cacheKey, filePath, page.Data);
                    var saveResourcesTask = SaveResourcesAsync(filePath, page.PageNumber, page.Resources);

                    return new[] {savePageTask, saveResourcesTask};
                });

            return Task.WhenAll(tasks);
        }

        private Pages ToPages(List<CachedPage> pagesOrNulls)
        {
            var pages = pagesOrNulls
                .Select(p => CreatePage(p.PageNumber, p.Data))
                .ToList();

            var result = new Pages(pages);
            return result;
        }

        private int[] GetMissingPageNumbers(List<CachedPage> pagesOrNulls)
        {
            return pagesOrNulls
                .Where(p => p.Data == null)
                .Select(p => p.PageNumber)
                .ToArray();
        }

        private List<CachedPage> GetPagesOrNullsFromCache(string filePath, int[] pageNumbers)
        {
            return pageNumbers
                .Select(pageNumber =>
                    (pageNumber, cacheKey: CacheKeys.GetPageCacheKey(pageNumber, PageExtension)))
                .Select(page =>
                    new CachedPage(page.pageNumber, _fileCache.TryGetValue<byte[]>(page.cacheKey, filePath)))
                .ToList();
        }
    }
}