using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace GroupDocs.Viewer.WebForms.Products.Viewer.Cache
{
    internal class FileViewerCache : IViewerCache
    {
        private readonly TimeSpan waitTimeout = TimeSpan.FromMilliseconds(100);

        /// <summary>
        /// Gets the Relative or absolute path to the cache folder.
        /// </summary>
        public string CachePath { get; }

        /// <summary>
        /// Gets the sub-folder to append to the <see cref="CachePath"/>.
        /// </summary>
        public string CacheSubFolder { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileViewerCache"/> class.
        /// </summary>
        /// <param name="cachePath">Relative or absolute path where document cache will be stored.</param>
        /// <param name="cacheSubFolder">The sub-folder to append to <paramref name="cachePath"/>.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="cachePath"/> is null.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="cacheSubFolder"/> is null.</exception>
        public FileViewerCache(string cachePath, string cacheSubFolder)
        {
            if (cachePath == null)
            {
                throw new ArgumentNullException(nameof(cachePath));
            }

            if (cacheSubFolder == null)
            {
                throw new ArgumentNullException(nameof(cacheSubFolder));
            }

            this.CachePath = cachePath;
            this.CacheSubFolder = cacheSubFolder;
        }

        /// <summary>
        /// Serializes data to the local disk.
        /// </summary>
        /// <param name="key">An unique identifier for the cache entry.</param>
        /// <param name="value">The object to serialize.</param>
        public void Set(string key, object value)
        {
            if (value == null)
            {
                return;
            }

            string filePath = this.GetCacheFilePath(key);

            Stream src = value as Stream;
            if (src != null)
            {
                using (FileStream dst = this.GetStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    src.Position = 0;
                    this.CopyStream(src, dst);
                }
            }
            else
            {
                using (FileStream stream = this.GetStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, value);
                }
            }
        }

        /// <summary>
        /// Deserializes data associated with this key if present.
        /// </summary>
        /// <param name="key">A key identifying the requested entry.</param>
        /// <returns><code>True</code> if the key was found.</returns>
        public T GetValue<T>(string key)
        {
            string cacheFilePath = this.GetCacheFilePath(key);
            T value = typeof(T) == typeof(Stream)
                    ? (T)this.ReadStream(cacheFilePath)
                    : (T)this.Deserialize(cacheFilePath);

            return value;
        }

        /// <summary>
        /// Deserializes data associated with this key if present.
        /// </summary>
        /// <param name="key">A key identifying the requested entry.</param>
        /// <param name="value">The located value or null.</param>
        /// <returns><code>True</code> if the key was found.</returns>
        public bool TryGetValue<T>(string key, out T value)
        {
            string cacheFilePath = this.GetCacheFilePath(key);

            if (File.Exists(cacheFilePath))
            {
                value = typeof(T) == typeof(Stream)
                    ? (T)this.ReadStream(cacheFilePath)
                    : (T)this.Deserialize(cacheFilePath);

                return true;
            }

            value = default(T);
            return false;
        }

        private object ReadStream(string cacheFilePath)
        {
            return this.GetStream(cacheFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        private object Deserialize(string cachePath)
        {
            object data;
            using (FileStream stream = this.GetStream(cachePath, FileMode.Open, FileAccess.Read, FileShare.Read))
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

        public string GetCacheFilePath(string key)
        {
            string folderPath = Path.Combine(this.CachePath, this.CacheSubFolder);
            string filePath = Path.Combine(folderPath, key);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return filePath;
        }

        public bool Contains(string key)
        {
            string file = Path.Combine(this.CachePath, this.CacheSubFolder, key);
            return File.Exists(file);
        }

        private FileStream GetStream(string path, FileMode mode, FileAccess access, FileShare share)
        {
            FileStream stream = null;
            TimeSpan interval = new TimeSpan(0, 0, 0, 0, 50);
            TimeSpan totalTime = new TimeSpan();

            while (stream == null)
            {
                try
                {
                    stream = File.Open(path, mode, access, share);
                }
                catch (IOException)
                {
                    Thread.Sleep(interval);
                    totalTime += interval;

                    if (this.waitTimeout.Ticks != 0 && totalTime > this.waitTimeout)
                    {
                        throw;
                    }
                }
            }

            return stream;
        }

        private void CopyStream(Stream src, Stream dst)
        {
            const int bufferSize = 81920; //NOTE: taken from System.IO
            byte[] buffer = new byte[bufferSize];
            int read;
            while ((read = src.Read(buffer, 0, buffer.Length)) != 0)
            {
                dst.Write(buffer, 0, read);
            }
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