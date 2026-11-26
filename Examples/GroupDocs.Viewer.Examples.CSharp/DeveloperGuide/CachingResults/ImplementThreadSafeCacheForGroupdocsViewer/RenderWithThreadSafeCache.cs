namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.CachingResults.ImplementThreadSafeCacheForGroupdocsViewer;

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Viewer.Caching;
using GroupDocs.Viewer.Interfaces;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

    static class Program
    {
        private static readonly ConcurrentDictionary<string, object> KeyLockerMap = new ConcurrentDictionary<string, object>();

        static void Main()
        {
            string fileName = "sample.pdf";
            string cacheFolder = fileName.Replace('.', '_');
            string cachePath = Path.Combine("cache", cacheFolder);
            string uniqueKeyPrefix = cachePath;

            ICache fileCache = new FileCache(cachePath);
            IKeyLockerStore keyLockerStore = new ConcurrentDictionaryKeyLockerStore(KeyLockerMap, uniqueKeyPrefix);
            ICache threadSafeCache = new ThreadSafeCache(fileCache, keyLockerStore);

            ViewerSettings viewerSettings = new ViewerSettings(threadSafeCache);

            List<MemoryStream> pages = new List<MemoryStream>();
            using (Viewer viewer = new Viewer(fileName, viewerSettings))
            {
                IPageStreamFactory pageStreamFactory = new MemoryPageStreamFactory(pages);
                ViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources(pageStreamFactory);
                viewer.View(viewOptions);
            }
        }
    }

    class ThreadSafeCache : ICache
    {
        private readonly ICache _cache;
        private readonly IKeyLockerStore _keyLockerStore;

        public ThreadSafeCache(ICache cache, IKeyLockerStore keyLockerStore)
        {
            _cache = cache;
            _keyLockerStore = keyLockerStore;
        }

        public void Set(string key, object value)
        {
            lock (_keyLockerStore.GetLockerFor(key))
            {
                _cache.Set(key, value);
            }
        }

        public bool TryGetValue<TEntry>(string key, out TEntry value)
        {
            lock (_keyLockerStore.GetLockerFor(key))
            {
                return _cache.TryGetValue(key, out value);
            }
        }

        public IEnumerable<string> GetKeys(string filter)
        {
            lock (_keyLockerStore.GetLockerFor("get_keys"))
            {
                return _cache.GetKeys(filter);
            }
        }
    }

    interface IKeyLockerStore
    {
        object GetLockerFor(string key);
    }

    class ConcurrentDictionaryKeyLockerStore : IKeyLockerStore
    {
        private readonly ConcurrentDictionary<string, object> _keyLockerMap;
        private readonly string _uniqueKeyPrefix;

        public ConcurrentDictionaryKeyLockerStore(ConcurrentDictionary<string, object> keyLockerMap, string uniqueKeyPrefix)
        {
            _keyLockerMap = keyLockerMap;
            _uniqueKeyPrefix = uniqueKeyPrefix;
        }

        public object GetLockerFor(string key)
        {
            string uniqueKey = GetUniqueKey(key);
            return _keyLockerMap.GetOrAdd(uniqueKey, k => new object());
        }

        private string GetUniqueKey(string key)
        {
            return $"{_uniqueKeyPrefix}_{key}";
        }
    }

    class MemoryPageStreamFactory : IPageStreamFactory
    {
        private readonly List<MemoryStream> _pages;

        public MemoryPageStreamFactory(List<MemoryStream> pages)
        {
            _pages = pages;
        }

        public Stream CreatePageStream(int pageNumber)
        {
            MemoryStream pageStream = new MemoryStream();
            _pages.Add(pageStream);

            return pageStream;
        }

        public void ReleasePageStream(int pageNumber, Stream pageStream)
        {
            //Do not release page stream as we'll need to keep the stream open
        }
    }

public static class RenderWithThreadSafeCache
{
    public static void Run()
    {
        namespace ThreadSafeCacheExample
        {




        }
    }
}
