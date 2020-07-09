---
id: how-to-use-custom-cache-implementation
url: viewer/net/how-to-use-custom-cache-implementation
title: How to use custom cache implementation
weight: 1
description: "This article explains how to use custom caching implementation with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Despite the fact that GroupDocs.Viewerimplements caching to local drive out of the box, it also allows you to cache rendering result in your own way. You can do this by using *ICache* interface implementation.  
Let see how to implement some custom cache implementation with 

## Using Redis cache (example)

The following steps should be followed.

*   Create *RedisCache* class which implements [ICache](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.caching/icache) interface.
*   Instantiate the *RedisCache* class.
*   Pass the reference of the *RedisCache* class instance into the constructor of [ViewerSettings](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewersettings) classinstance.
*   Instantiate [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class with [ViewerSettings](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewersettings) object.
*   Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method of [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class.

Below is the code that demonstrates how to use custom caching for GroupDocs.Viewer:

```csharp
using GroupDocs.Viewer.Caching;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using StackExchange.Redis;
using GroupDocs.Viewer.Options;
using System.Diagnostics;
namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Common
{
    class UseCustomCacheWhenProcessingDocuments
    {
        /// <summary>
        /// This example demonstrates how to implement custom cache when rendering document.
        /// </summary>
        public static void Run()
        {
            string outputDirectory = @"C:\output";
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
           
 RedisCache cache = new RedisCache("sample_");
            ViewerSettings settings = new ViewerSettings(cache);

            using (Viewer viewer = new Viewer(@"C:\sample.docx", settings))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                Stopwatch stopWatch = Stopwatch.StartNew();
                viewer.View(options);
                stopWatch.Stop();
                Console.WriteLine("Time taken on first call to View method {0} (ms).", stopWatch.ElapsedMilliseconds);
                stopWatch.Restart();
                viewer.View(options);
                stopWatch.Stop();
                Console.WriteLine("Time taken on second call to View method {0} (ms).", stopWatch.ElapsedMilliseconds);
            }
            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
    public class RedisCache : ICache, IDisposable
    {
        private readonly string _cacheKeyPrefix;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;
        private readonly string _host = "192.168.0.13:6379";
        public RedisCache(string cacheKeyPrefix)
        {
            _cacheKeyPrefix = cacheKeyPrefix;
            _redis = ConnectionMultiplexer.Connect(_host);
            _db = _redis.GetDatabase();
        }
        public void Set(string key, object data)
        {
            if (data == null)
                return;
            string prefixedKey = GetPrefixedKey(key);
            using (MemoryStream stream = GetStream(data))
            {
                _db.StringSet(prefixedKey, RedisValue.CreateFrom(stream));
            }
        }
        public bool TryGetValue<TEntry>(string key, out TEntry value)
        {
            var prefixedKey = GetPrefixedKey(key);
            var redisValue = _db.StringGet(prefixedKey);
            if (redisValue.HasValue)
            {
                var data = typeof(TEntry) == typeof(Stream)
                    ? ReadStream(redisValue)
                    : Deserialize(redisValue);
                value = (TEntry)data;
                return true;
            }

            value = default;
            return false;
        }
        public IEnumerable<string> GetKeys(string filter)
        {
            return _redis.GetServer(_host).Keys(pattern: $"*{filter}*")
                .Select(x => x.ToString().Replace(_cacheKeyPrefix, string.Empty))
                .Where(x => x.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }
        private string GetPrefixedKey(string key)
            => $"{_cacheKeyPrefix}{key}";
        private object ReadStream(RedisValue redisValue)
        {
            return new MemoryStream(redisValue);
        }
        private object Deserialize(RedisValue redisValue)
        {
            object data;
            using (MemoryStream stream = new MemoryStream(redisValue))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Binder = new IgnoreAssemblyVersionSerializationBinder();
                try
                {
                    data = formatter.Deserialize(stream);
                }
                catch (SerializationException)
                {
                    data = null;
                }
            }
            return data;
        }
        private MemoryStream GetStream(object data)
        {
            MemoryStream result = new MemoryStream();
            if (data is Stream stream)
            {
                stream.Position = 0;
                stream.CopyTo(result);
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(result, data);
            }
            return result;
        }
        public void Dispose()
        {
            _redis.Dispose();
        }
        private class IgnoreAssemblyVersionSerializationBinder : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                string assembly = Assembly.GetExecutingAssembly().FullName;
                Type type = Type.GetType($"{typeName}, {assembly}");
                return type;
            }
        }
    }
}
```

## More resources
### GitHub Examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)    
*   [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)    
*   [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)     
*   [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)    
*   [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)    
*   [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App
Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.