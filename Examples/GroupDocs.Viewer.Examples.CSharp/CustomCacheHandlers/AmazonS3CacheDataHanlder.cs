using Amazon.S3;
using Amazon.S3.IO;
using Amazon.S3.Model;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Handler.Cache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GroupDocs.Viewer.Examples.CSharp
{
    /// <summary>
    /// GroupDocs.Viewer Input, Cache and FileData handlers implementation
    /// </summary>
    public class AmazonS3CacheDataHanlder : ICacheDataHandler
    {
        private readonly IFileManager _fileManager;

        private const string PageNamePrefix = "p";
        private const string CacheFolderName = "cache";
        private const string ResourcesDirectory = "r";
        private const string AttachmentDirectory = "a";
        private const string ImageFolderNameFormat = "{0}x{1}px";
        private const string PdfFileName = "file.pdf";

        public AmazonS3CacheDataHanlder(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public bool Exists(CacheFileDescription cacheFileDescription)
        {
            string path = GetFilePath(cacheFileDescription);
            return _fileManager.FileExist(path);
        }

        public Stream GetInputStream(CacheFileDescription cacheFileDescription)
        {
            string path = GetFilePath(cacheFileDescription);

            return _fileManager.Download(path);
        }

        public Stream GetOutputSaveStream(CacheFileDescription cacheFileDescription)
        {
            string path = GetFilePath(cacheFileDescription);

            return new OutputStream(stream => _fileManager.Upload(stream, path));
        }

        public string GetHtmlPageResourcesFolder(CachedPageDescription cachedPageDescription)
        {
            string resourcesForPageFolderName = string.Format("{0}{1}", PageNamePrefix, cachedPageDescription.PageNumber);

            string path = cachedPageDescription.Guid.Contains(CacheFolderName)
                ? cachedPageDescription.Guid.Replace(CacheFolderName, string.Empty)
                : cachedPageDescription.Guid;

            string documentFolder = ToRelativeDirectoryName(path);
            string result = Path.Combine(CacheFolderName, documentFolder, ResourcesDirectory, resourcesForPageFolderName);

            return NormalizePath(result);
        }

        public List<CachedPageResourceDescription> GetHtmlPageResources(CachedPageDescription cachedPageDescription)
        {
            List<CachedPageResourceDescription> result = new List<CachedPageResourceDescription>();
            string resourcesFolder = GetHtmlPageResourcesFolder(cachedPageDescription);

            var pathDelimiter = _fileManager.PathDelimiter.ToString();
            if (!resourcesFolder.EndsWith(pathDelimiter))
                resourcesFolder += pathDelimiter;

            var files = _fileManager.GetFiles(resourcesFolder);

            foreach (var file in files)
            {
                if (!file.IsDirectory)
                {
                    CachedPageResourceDescription resource =
                        new CachedPageResourceDescription(cachedPageDescription, Path.GetFileName(file.Path));
                    result.Add(resource);
                }
            }

            return result;
        }

        public DateTime? GetLastModificationDate(CacheFileDescription cacheFileDescription)
        {
            string fullPath = GetFilePath(cacheFileDescription);
            var entity = _fileManager.GetFile(fullPath);

            return entity.LastModified;
        }

        public void ClearCache()
        {
            _fileManager.DeleteDirectory(CacheFolderName);
        }

        public void ClearCache(TimeSpan olderThan)
        {
            // Obsolete method
            _fileManager.DeleteDirectory(CacheFolderName);
        }
        public void ClearCache(string guid)
        {
            _fileManager.DeleteDirectory(CacheFolderName + "/" + ToRelativeDirectoryName(guid));
        }
        public string GetFilePath(CacheFileDescription cacheFileDescription)
        {
            string path;
            switch (cacheFileDescription.CacheFileType)
            {
                case CacheFileType.Page:
                    path = GetPageFilePath(cacheFileDescription);
                    break;
                case CacheFileType.PageResource:
                    path = GetResourceFilePath(cacheFileDescription);
                    break;
                case CacheFileType.Attachment:
                    path = GetAttachmentFilePath(cacheFileDescription);
                    break;
                case CacheFileType.Document:
                    path = GetDocumentFilePath(cacheFileDescription);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return NormalizePath(path);
        }

        private string GetDocumentFilePath(CacheFileDescription cacheFileDescription)
        {
            CachedDocumentDescription document = cacheFileDescription as CachedDocumentDescription;

            if (document == null)
                throw new InvalidOperationException(
                    "cacheFileDescription object should be an instance of CachedDocumentDescription class");

            string documentName = document.Name.Equals("document") && (document.OutputExtension.Equals("pdf") || document.OutputExtension.Equals(".pdf"))
                ? PdfFileName
                : Path.ChangeExtension(document.Name, document.OutputExtension);

            string documentFolder = BuildCachedDocumentFolderPath(document);
            return Path.Combine(documentFolder, documentName);
        }

        private string BuildCachedDocumentFolderPath(CachedDocumentDescription cachedPageDescription)
        {
            string path = cachedPageDescription.Guid.Contains(CacheFolderName)
                ? cachedPageDescription.Guid.Replace(CacheFolderName, string.Empty)
                : cachedPageDescription.Guid;

            string relativePath = ToRelativeDirectoryName(path);
            return Path.Combine(CacheFolderName, relativePath);
        }

        private string GetAttachmentFilePath(CacheFileDescription cacheFileDescription)
        {
            CachedAttachmentDescription attachmentDescription =
                cacheFileDescription as CachedAttachmentDescription;

            if (attachmentDescription == null)
                throw new InvalidOperationException(
                    "cacheFileDescription object should be an instance of CachedAttachmentDescription class");

            string path = attachmentDescription.Guid.Contains(CacheFolderName)
               ? attachmentDescription.Guid.Replace(CacheFolderName, string.Empty)
               : attachmentDescription.Guid;

            return Path.Combine(
               CacheFolderName,
               ToRelativeDirectoryName(path),
               AttachmentDirectory,
               attachmentDescription.AttachmentName);
        }

        private string GetResourceFilePath(CacheFileDescription cacheFileDescription)
        {
            CachedPageResourceDescription resourceDescription = cacheFileDescription as CachedPageResourceDescription;

            if (resourceDescription == null)
                throw new InvalidOperationException(
                    "cacheFileDescription object should be an instance of CachedPageResourceDescription class");

            string resourcesPath = GetHtmlPageResourcesFolder(resourceDescription.CachedPageDescription);
            return Path.Combine(resourcesPath, resourceDescription.ResourceName);
        }

        private string GetPageFilePath(CacheFileDescription cacheFileDescription)
        {
            CachedPageDescription pageDescription = cacheFileDescription as CachedPageDescription;

            if (pageDescription == null)
                throw new InvalidOperationException(
                    "cacheFileDescription object should be an instance of CachedPageDescription class");

            string fileName = BuildPageFileName(pageDescription);
            string folder = BuildCachedPageFolderPath(pageDescription);
            return Path.Combine(folder, fileName);
        }

        private string BuildPageFileName(CachedPageDescription cachedPageDescription)
        {
            var extension = cachedPageDescription.OutputExtension;

            if (string.IsNullOrEmpty(extension))
                extension = ".html";
            else if (!extension.Contains("."))
                extension = string.Format(".{0}", extension);

            return string.Format("{0}{1}{2}", PageNamePrefix, cachedPageDescription.PageNumber, extension);
        }

        private string BuildCachedPageFolderPath(CachedPageDescription cachedPageDescription)
        {
            string path = cachedPageDescription.Guid.Contains(CacheFolderName)
               ? cachedPageDescription.Guid.Replace(CacheFolderName, string.Empty)
               : cachedPageDescription.Guid;

            string relativeDirectoryName = ToRelativeDirectoryName(path);
            string dimmensionsSubFolder = GetDimmensionsSubFolder(cachedPageDescription);

            return !string.IsNullOrEmpty(dimmensionsSubFolder)
                ? Path.Combine(CacheFolderName, relativeDirectoryName, dimmensionsSubFolder)
                : Path.Combine(CacheFolderName, relativeDirectoryName);
        }

        private string GetDimmensionsSubFolder(CachedPageDescription cachedPageDescription)
        {
            //based on GroupDocs.Viewer.Converter.Options.ConvertImageFileType
            string outputExtension = !string.IsNullOrEmpty(cachedPageDescription.OutputExtension) && cachedPageDescription.OutputExtension.Contains(".")
                ? cachedPageDescription.OutputExtension
                : string.Format(".{0}", cachedPageDescription.OutputExtension);

            var possibleImageExtensions = new[] { ".jpg", ".png", ".bmp" };
            if (!possibleImageExtensions.Contains(outputExtension))
                return string.Empty;

            return string.Format(ImageFolderNameFormat, cachedPageDescription.Width, cachedPageDescription.Height);
        }

        private static string ToRelativeDirectoryName(string guid)
        {
            if (string.IsNullOrEmpty(guid))
                return string.Empty;

            string result = guid;
            const char replacementCharacter = '_';

            if (Path.IsPathRooted(result))
            {
                string root = Path.GetPathRoot(result);
                if (root.Equals(@"\"))
                    result = result.Substring(root.Length);

                if (root.Contains(":"))
                    result = result.Replace(':', replacementCharacter).Replace('\\', replacementCharacter).Replace('/', replacementCharacter);
            }

            if (result.StartsWith("http") || result.StartsWith("ftp"))
                result = result.Replace(':', replacementCharacter).Replace('\\', replacementCharacter).Replace('/', replacementCharacter);

            result = Regex.Replace(result, "[_]{2,}", new string(replacementCharacter, 1));
            result = result.TrimStart(replacementCharacter);

            return result.Replace('.', replacementCharacter);
        }

        #region Privates

        private string NormalizePath(string path)
        {
            return Regex.Replace(path, @"\\+", _fileManager.PathDelimiter.ToString())
                .Trim(_fileManager.PathDelimiter);
        }

        #endregion
    }

    public interface IFileManager
    {
        char PathDelimiter { get; }
        bool FileExist(string path);
        void Upload(Stream content, string path);
        Stream Download(string path);
        IFile GetFile(string path);
        IEnumerable<IFile> GetFiles(string normalizedPath);
        void DeleteDirectory(string path);
    }

    public interface IFile
    {
        /// <summary>
        /// Path to the file or directory in storage
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// The file size in bytes
        /// </summary>
        long Size { get; set; }

        /// <summary>
        /// The last modification date.
        /// </summary>
        DateTime LastModified { get; set; }

        /// <summary>
        /// Indicates if file is directory
        /// </summary>
        bool IsDirectory { get; set; }
    }

    public class OutputStream : MemoryStream
    {
        private readonly Action<Stream> _onCloseAction;
        private bool _closed;

        public OutputStream(Action<Stream> onCloseAction)
        {
            _onCloseAction = onCloseAction;
        }

        public override void Close()
        {
            if (this.CanSeek && this.CanRead && !_closed)
            {
                this.Position = 0;
                this._closed = true;
                _onCloseAction(this);
            }

            base.Close();
        }
    }

    public class AmazonS3File : IFile
    {
        public string Path { get; set; }
        public long Size { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDirectory { get; set; }
    }

    public class AmazonS3FileManager : IFileManager, IDisposable
    {
        private IAmazonS3 _client;

        private readonly string _bucketName;

        public AmazonS3FileManager(IAmazonS3 client, string bucketName)
        {
            _client = client;
            _bucketName = bucketName;
        }

        public char PathDelimiter
        {
            get { return '/'; }
        }

        public bool FileExist(string path)
        {
            try
            {
                GetObjectMetadataRequest request = new GetObjectMetadataRequest
                {
                    BucketName = _bucketName,
                    Key = path
                };

                _client.GetObjectMetadata(request);

                return true;
            }
            catch (AmazonS3Exception)
            {
                return false;
            }
        }

        public void Upload(Stream content, string path)
        {
            PutObjectRequest request = new PutObjectRequest
            {
                Key = path,
                BucketName = _bucketName,
                InputStream = content
            };

            _client.PutObject(request);
        }

        public Stream Download(string path)
        {
            GetObjectRequest request = new GetObjectRequest
            {
                Key = path,
                BucketName = _bucketName,
            };

            using (GetObjectResponse response = _client.GetObject(request))
            {
                MemoryStream stream = new MemoryStream();
                response.ResponseStream.CopyTo(stream);
                stream.Position = 0;

                return stream;
            }
        }

        public IFile GetFile(string path)
        {
            GetObjectMetadataRequest request = new GetObjectMetadataRequest
            {
                BucketName = _bucketName,
                Key = path
            };

            GetObjectMetadataResponse response = _client.GetObjectMetadata(request);

            IFile file = new AmazonS3File();
            file.Path = path;
            file.Size = response.ContentLength;
            file.LastModified = response.LastModified;

            return file;
        }

        public IEnumerable<IFile> GetFiles(string path)
        {
            var prefix = path.Length > 1 ? path : string.Empty;

            ListObjectsRequest request = new ListObjectsRequest
            {
                BucketName = _bucketName,
                Prefix = prefix,
                Delimiter = PathDelimiter.ToString()
            };

            ListObjectsResponse response = _client.ListObjects(request);

            List<IFile> files = new List<IFile>();

            // add directories 
            foreach (string directory in response.CommonPrefixes)
            {
                IFile file = new AmazonS3File();
                file.Path = directory;
                file.IsDirectory = true;

                files.Add(file);
            }

            // add files
            foreach (S3Object entry in response.S3Objects)
            {
                IFile fileDescription = new AmazonS3File()
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

        public void DeleteDirectory(string path)
        {
            S3DirectoryInfo directory = new S3DirectoryInfo(_client, _bucketName, path);
            directory.Delete(true);
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
}
