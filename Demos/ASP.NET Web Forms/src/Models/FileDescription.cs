using Newtonsoft.Json;

namespace GroupDocs.Viewer.AspNetWebForms.Models
{
    public class FileDescription
    {
        /// <summary>
        /// File unique ID.
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; }
        
        /// <summary>
        /// File file name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// <value>True</value> when it is a directory.
        /// </summary>
        [JsonProperty("isDirectory")]
        public bool IsDirectory { get; }

        /// <summary>
        /// Size in bytes.
        /// </summary>
        [JsonProperty("size")]
        public long Size { get; }

        /// <summary>
        /// .ctor
        /// </summary>
        public FileDescription(string guid, string name, bool isDirectory, long size)
        {
            Guid = guid;
            Name = name;
            IsDirectory = isDirectory;
            Size = size;
        }
    }
}