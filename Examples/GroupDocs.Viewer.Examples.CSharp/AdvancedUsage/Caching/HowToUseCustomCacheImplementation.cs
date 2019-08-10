using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using GroupDocs.Viewer.Caching;
using GroupDocs.Viewer.Options;
using StackExchange.Redis;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Caching
{
    class HowToUseCustomCacheImplementation
    {
        /// <summary>
        /// This example demonstrates how to implement custom cache when rendering document.
        /// </summary>
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            RedisCache cache = new RedisCache("sample_");
            ViewerSettings settings = new ViewerSettings(cache);

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX, settings))
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
        private readonly string _host = "192.168.0.1:6379";

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
