---
id: how-to-make-cache-thread-safe-in-your-net-csharp-application
url: viewer/net/how-to-make-cache-thread-safe-in-your-net-csharp-application
title: How to make cache thread-safe in your .NET C# application
weight: 2
description: "This article explains how to make cache thread-safe with GroupDocs.Viewer within your .NET applications."
keywords: GroupDocs.Viewer, thread-safe, cache
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
This tutorial will explain how to make cache thread-safe by using [C# lock](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement) and [ConcurrentDictionary<,> class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2).

## Introduction

We can say that a method is thread-safe when multiple threads can call it without breaking the functionality of this method. Achieving thread safety is a complex task and so general-purpose classes are usually not thread-safe. The most common way to achieve thread-safety is by locking the resource for the exclusive use by a single thread at any given point of the time.

## The issue

We have a web-application where multiple users can simultaneously view the same file. The web-application uses GroupDocs.Viewer on the server-side and we want to make sure that multiple-threads can safely read from and write to the cache, in other words, make cache thread-safe.

The GroupDocs.Viewer enables users to use caching to improve the performance of the application when the same document is processed multiple times ([read more about caching here]({{< ref "viewer/net/developer-guide/advanced-usage/caching/_index.md" >}}).) The [FileCache](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.caching/filecache) is a simple implementation of [ICache](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.caching/icache) interface that uses a local disk to store the cache files is available from the GroupDocs.Viewer.Caching namespace. The FileCache is not thread-safe, so our task is to make it thread-safe.

## The solution

The FileCache class uses a local disk to read and write output file copies, so we need to make reads and writes to disk thread-safe. To do so we need some kind of the list where we can store key or file ID and associated object that we'll lock around. The simplest way is using [ConcurrentDictionary<,> class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2) that has been [introduced with .NET Framework 4.0](https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/). The ConcurrentDictionary is a thread-safe implementation of a dictionary of key-value pairs. Let's implement a class that will wrap around not thread-safe class that implements the ICache interface.

```csharp
internal class ThreadSafeCache : ICache
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
```

As you can see the all the ThreadSafeCache class methods use locks to make calls to the methods thread-safe. Let's see at ConcurrentDictionaryKeyLockerStore implementation. This class keeps uses ConcurrentDictionary to create a locker object or to retrieve it when it already exists. It also creates a unique key that identifies a cached file.

```csharp
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
```

Let's see the whole program listing with ThreadSafeCache and ConcurrentDictionaryKeyLockerStore.

```csharp
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Viewer;
using GroupDocs.Viewer.Caching;
using GroupDocs.Viewer.Interfaces;
using GroupDocs.Viewer.Options;

namespace ThreadSaveCacheExample
{
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
}
```

## Conclusion

With **lock** statement and **Concurrent Collections**, we can write quite a simple code to achieve thread-safety in our applications as shown in this tutorial.

## More resources

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App

Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.
