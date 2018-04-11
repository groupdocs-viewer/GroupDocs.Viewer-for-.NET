using Amazon.S3;
using Amazon.S3.IO;
using Amazon.S3.Model;
using GroupDocs.Viewer.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GroupDocs.Viewer.Examples.CSharp.SimpleFileStorageInterfaces
{
    //ExStart:AmazonS3FileStorage_18.4
    public class AmazonS3FileStorage : GroupDocs.Viewer.Storage.IFileStorage, IDisposable
    {
        private AmazonS3Client _client;
        private readonly string _bucketName;
        private char PathDelimiter
        {
            get { return '/'; }
        }

        public AmazonS3FileStorage(AmazonS3Client client, string bucketName)
        {
            _client = client;
            _bucketName = bucketName;
        }

        public bool FileExists(string path)
        {
            try
            {
                string key = GetKey(path);
                GetObjectMetadataRequest request = new GetObjectMetadataRequest
                {
                    BucketName = _bucketName,
                    Key = key
                };
                _client.GetObjectMetadata(request);
                return true;
            }
            catch (AmazonS3Exception)
            {
                return false;
            }
        }

        public Stream GetFile(string path)
        {
            string key = GetKey(path);
            GetObjectRequest request = new GetObjectRequest
            {
                Key = key,
                BucketName = _bucketName
            };
            using (GetObjectResponse response = _client.GetObject(request))
            {
                MemoryStream stream = new MemoryStream();
                response.ResponseStream.CopyTo(stream);
                stream.Position = 0;
                return stream;
            }
        }

        public void SaveFile(string path, Stream content)
        {
            string key = GetKey(path);
            PutObjectRequest request = new PutObjectRequest
            {
                Key = key,
                BucketName = _bucketName,
                InputStream = content
            };
            _client.PutObject(request);
        }
        public void DeleteDirectory(string path)
        {
            string key = GetKey(path);
            S3DirectoryInfo directory = new S3DirectoryInfo(_client, _bucketName, key);
            directory.Delete(true);
        }

        public IFileInfo GetFileInfo(string path)
        {
            string key = GetKey(path);
            GetObjectMetadataRequest request = new GetObjectMetadataRequest
            {
                BucketName = _bucketName,
                Key = key
            };
            GetObjectMetadataResponse response = _client.GetObjectMetadata(request);
            IFileInfo file = new GroupDocs.Viewer.Storage.FileInfo();
            file.Path = path;
            file.Size = response.ContentLength;
            file.LastModified = response.LastModified;
            file.IsDirectory = false;
            return file;
        }

        public IEnumerable<IFileInfo> GetFilesInfo(string path)
        {
            string key = GetKey(path);
            ListObjectsRequest request = new ListObjectsRequest
            {
                BucketName = _bucketName,
                Prefix = key.Length > 1 ? key : string.Empty,
                Delimiter = PathDelimiter.ToString()
            };
            ListObjectsResponse response = _client.ListObjects(request);
            List<IFileInfo> files = new List<IFileInfo>();

            // add directories 
            foreach (string directory in response.CommonPrefixes)
            {
                IFileInfo file = new GroupDocs.Viewer.Storage.FileInfo();
                file.Path = directory;
                file.IsDirectory = true;
                files.Add(file);
            }

            // add files
            foreach (S3Object entry in response.S3Objects)
            {
                IFileInfo fileDescription = new GroupDocs.Viewer.Storage.FileInfo
                {
                    Path = entry.Key,
                    IsDirectory = false,
                    LastModified = entry.LastModified,
                    Size = entry.Size
                };
                files.Add(fileDescription);
            }
            return files;
        }

        private string GetKey(string path)
        {
            return Regex.Replace(path, @"\\+", PathDelimiter.ToString())
                .Trim(PathDelimiter);
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
                _client = null;
            }
        }
    }
    //ExEnd:AmazonS3FileStorage_18.4


}
