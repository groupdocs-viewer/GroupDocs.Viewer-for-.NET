using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Options;
using GroupDocs.Viewer.Handler.Input;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GroupDocs.Viewer.Examples.CSharp
{
    /// <summary>
    /// The implementation of GroupDocs.Viewer data handler for Azure Blob Storage.
    /// </summary>
    public class AzureInputDataHandler : IInputDataHandler
    {
        /// <summary>
        /// The blob delimiter.
        /// </summary>
        private const char Delimiter = '/';
        /// <summary>
        /// The endpoint template.
        /// </summary>
        private const string EndpointTemplate = "https://{account-name}.blob.core.windows.net/";
        /// <summary>
        /// The cloud blob container.
        /// </summary>
        private readonly CloudBlobContainer _container;
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureInputDataHandler"/> class.
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="accountKey"></param>
        /// <param name="containerName"></param>
        public AzureInputDataHandler(string accountName, string accountKey, string containerName)
            : this(GetEndpoint(accountName), accountName, accountKey, containerName)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureInputDataHandler"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint e.g. https://youraccountname.blob.core.windows.net/ </param>
        /// <param name="accountName">The account name.</param>
        /// <param name="accountKey">The account key.</param>
        /// <param name="containerName">The container name.</param>
        public AzureInputDataHandler(Uri endpoint, string accountName, string accountKey, string containerName)
        {
            try
            {
                StorageCredentials storageCredentials = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(storageCredentials, endpoint, null, null, null);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                TimeSpan? serverTimeout = cloudBlobClient.DefaultRequestOptions.ServerTimeout;
                cloudBlobClient.DefaultRequestOptions.ServerTimeout = TimeSpan.FromSeconds(10);
                _container = cloudBlobClient.GetContainerReference(containerName);
                _container.CreateIfNotExists();
                cloudBlobClient.DefaultRequestOptions.ServerTimeout = serverTimeout;
            }
            catch (StorageException e)
            {
                throw new System.Exception("Unable to recognize that Account Name/Account Key or container name is invalid.", e);
            }
            catch (FormatException e)
            {
                throw new System.Exception("Unable to recognize that Account Name/Account Key.", e);
            }
        }
        /// <summary>
        /// Gets the file description.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>GroupDocs.Viewer.Domain.FileDescription.</returns>
        public FileDescription GetFileDescription(string guid)
        {
            try
            {
                string blobName = GetNormalizedBlobName(guid);
                CloudBlob blob = _container.GetBlobReference(blobName);
                blob.FetchAttributes();
                return new FileDescription(blobName, false)
                {
                    LastModificationDate = GetDateTimeOrEmptyDate(blob.Properties.LastModified),
                    Size = blob.Properties.Length
                };
            }
            catch (StorageException ex)
            {
                throw new System.Exception("Unabled to get file description.", ex);
            }
        }
        public Stream GetFile(string guid)
        {
            try
            {
                string blobName = GetNormalizedBlobName(guid);
                CloudBlob blob = _container.GetBlobReference(blobName);
                MemoryStream memoryStream = new MemoryStream();
                blob.DownloadToStream(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
            catch (StorageException ex)
            {
                throw new System.Exception("Unabled to get file.", ex);
            }
        }
        /// <summary>
        /// Gets the last modification date.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>System.DateTime.</returns>
        public DateTime GetLastModificationDate(string guid)
        {
            FileDescription fileDescription = GetFileDescription(guid);
            return fileDescription.LastModificationDate;
        }
        /// <summary>
        /// Gets files and folders for specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.Collections.Generic.List&lt;GroupDocs.Viewer.Domain.FileDescription&gt;.</returns>
        public List<FileDescription> GetEntities(string path)
        {
            try
            {
                string normalizedPath = GetNormalizedBlobName(path);
                return GetFilesAndDirectories(normalizedPath);
            }
            catch (StorageException ex)
            {
                throw new System.Exception("Failed to load file tree.", ex);
            }
        }

        /// <summary>
        /// Gets the file tree.
        /// </summary>
        /// <param name="blobName">The blob name.</param>
        /// <returns>The file tree.</returns>
        private List<FileDescription> GetFilesAndDirectories(string blobName)
        {
            CloudBlobDirectory directory = _container.GetDirectoryReference(blobName);
            List<FileDescription> fileTree = new List<FileDescription>();
            foreach (IListBlobItem blob in directory.ListBlobs())
            {
                FileDescription fileDescription;
                CloudBlobDirectory blobDirectory = blob as CloudBlobDirectory;
                if (blobDirectory != null)
                {
                    fileDescription = new FileDescription(blobDirectory.Prefix, true);
                }
                else
                {
                    ICloudBlob blobFile = (ICloudBlob)blob;
                    fileDescription = new FileDescription(blobFile.Name, false)
                    {
                        Size = blobFile.Properties.Length,
                        LastModificationDate = GetDateTimeOrEmptyDate(blobFile.Properties.LastModified)
                    };
                }
                fileTree.Add(fileDescription);
            }
            return fileTree;
        }
        /// <summary>
        /// Gets normalized blob name, updates guid from dir\\file.ext to dir/file.ext
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>Normalized blob name.</returns>
        private string GetNormalizedBlobName(string guid)
        {
            return Regex.Replace(guid, @"\\+", Delimiter.ToString()).Trim(Delimiter);
        }

        /// <summary>
        /// Gets the endpoint e.g. https://youraccountname.blob.core.windows.net/
        /// </summary>
        /// <param name="accountName">The account name.</param>
        /// <returns>Endpoint Uri.</returns>
        private static Uri GetEndpoint(string accountName)
        {
            string endpoint = EndpointTemplate.Replace("{account-name}", accountName);
            return new Uri(endpoint);
        }
        /// <summary>
        /// Gets the file tree.
        /// </summary>
        /// <param name="blobName">The blob name.</param>
        /// <returns>The file tree.</returns>
        private List<FileDescription> GetFileTree(string blobName)
        {
            CloudBlobDirectory directory = _container.GetDirectoryReference(blobName);
            List<FileDescription> fileTree = new List<FileDescription>();
            foreach (IListBlobItem blob in directory.ListBlobs())
            {
                FileDescription fileDescription;
                CloudBlobDirectory blobDirectory = blob as CloudBlobDirectory;
                if (blobDirectory != null)
                {
                    fileDescription = new FileDescription(blobDirectory.Prefix, true);
                }
                else
                {
                    ICloudBlob blobFile = (ICloudBlob)blob;
                    fileDescription = new FileDescription(blobFile.Name, false)
                    {
                        Size = blobFile.Properties.Length,
                        LastModificationDate = GetDateTimeOrEmptyDate(blobFile.Properties.LastModified)
                    };
                }
                fileTree.Add(fileDescription);
            }
            return fileTree;
        }
        /// <summary>
        /// Gets date time or empty date.
        /// </summary>
        /// <param name="dateTimeOffset">The date time offset.</param>
        /// <returns>Date time or empty date.</returns>
        private DateTime GetDateTimeOrEmptyDate(DateTimeOffset? dateTimeOffset)
        {
            DateTime emptyDate = new DateTime(1, 1, 1);
            return dateTimeOffset.HasValue ? dateTimeOffset.Value.DateTime : emptyDate;
        }

        public void SaveDocument(CachedDocumentDescription description, Stream stream)
        {
            //TODO
        }
        /// <summary>
        /// Adds file to storage.
        /// </summary>
        /// <param name="guid">This is user defined key that identifies file in the storage.</param>
        /// <param name="content">Stream to save data to storage.</param>
        public void AddFile(string guid, Stream content)
        {
            try
            {
                string blobName = GetNormalizedBlobName(guid);
                ICloudBlob blob = _container.GetBlockBlobReference(blobName);
                blob.UploadFromStream(content);
            }
            catch (StorageException ex)
            {
                throw new System.Exception("Unabled to add file.", ex);
            }
        }

        public List<FileDescription> LoadFileTree(FileListOptions fileListOptions)
        {
            //TODO
            return new List<FileDescription>();
        }
        [Obsolete]
        public List<FileDescription> LoadFileTree(FileTreeOptions fileTreeOptions)
        {
            //TODO
            return new List<FileDescription>();
        }
    }
}
