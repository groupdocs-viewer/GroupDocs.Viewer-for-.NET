namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.CachingResults.HowToUseCustomCacheImplementation;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System;
using GroupDocs.Viewer.Caching;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;
using StackExchange.Redis;

public class RedisCache : ICache, IDisposable
{
    private readonly string _cacheKeyPrefix;
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _db;
    private readonly string _host;

    public RedisCache(string host, string cacheKeyPrefix)
    {
        _host = host;
        _cacheKeyPrefix = cacheKeyPrefix;
        _redis = ConnectionMultiplexer.Connect(_host);
        _db = _redis.GetDatabase();
    }

    public void Set(string key, object data)
    {
        if (data == null)
            return;

        string prefixedKey = GetPrefixedKey(key);
        MemoryStream memoryStream = null;

        if (data is Stream)
        {
            memoryStream = data is MemoryStream
                ? data as MemoryStream
                : CopyToMemoryStream(data as Stream);
        }
        else
        {
            memoryStream = new MemoryStream();

            XmlSerializer serializer = new XmlSerializer(data.GetType());
            serializer.Serialize(memoryStream, data);
        }

        _db.StringSet(prefixedKey, RedisValue.CreateFrom(memoryStream));
    }

    private MemoryStream CopyToMemoryStream(Stream data)
    {
        MemoryStream result = new MemoryStream();
        data.Position = 0;
        data.CopyTo(result);
        return result;
    }

    public bool TryGetValue<TEntry>(string key, out TEntry value)
    {
        var prefixedKey = GetPrefixedKey(key);
        var redisValue = _db.StringGet(prefixedKey);
        if (redisValue.HasValue)
        {
            var data = typeof(TEntry) == typeof(Stream)
                ? ReadStream(redisValue)
                : Deserialize<TEntry>(redisValue);
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

    private object ReadStream(RedisValue redisValue) =>
         new MemoryStream(redisValue);

    private T Deserialize<T>(RedisValue redisValue)
    {
        object data;
        using (MemoryStream stream = new MemoryStream(redisValue))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                data = serializer.Deserialize(stream);
            }
            catch (InvalidOperationException)
            {
                data = null;
            }
            catch (NullReferenceException)
            {
                data = null;
            }
        }

        return (T)data;
    }

    public void Dispose()
    {
        _redis.Dispose();
    }
}

public static class UseCustomCache
{
    public static void Run()
    {
        // ...

        // Specify the cache parameters.
        var serverAddress = "127.0.0.1:6379";
        var filePath = "sample.docx";

        // Create the cache.
        RedisCache cache = new RedisCache(serverAddress, filePath);
        ViewerSettings settings = new ViewerSettings(cache);

        using (Viewer viewer = new Viewer(filePath, settings))
        {
            // Create HTML files.
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();

            // Display rendering time.
            PrintTimeTaken(() => viewer.View(viewOptions), "The first call to View method took {0} ms.");
            // Display time to get cached results.
            PrintTimeTaken(() => viewer.View(viewOptions), "The second call to View method took {0} ms.");
        }

        // Get and display time taken.
        static void PrintTimeTaken(Action action, string format)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();

            Console.WriteLine(format, stopwatch.ElapsedMilliseconds);
        }
    }
}
