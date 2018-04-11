using GroupDocs.Viewer.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupDocs.Viewer.Examples.CSharp.SimpleFileStorageInterfaces
{
    //ExStart:LocalFileStorage_18.4
    /// <summary>
    /// Local file storage
    /// </summary>
    public class LocalFileStorage : IFileStorage
    {
        /// <summary>
        /// Checks if file exists
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns><c>true</c> when file exists, otherwise <c>false</c></returns>
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
        /// <summary>
        /// Retrieves file content
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>Stream</returns>
        public Stream GetFile(string path)
        {
            return File.OpenRead(path);
        }
        /// <summary>
        /// Saves file
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="content">File content.</param>
        public void SaveFile(string path, Stream content)
        {
            string directory = Path.GetDirectoryName(path);
            if (directory != null)
            {
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
            }
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                if (content.Position != 0)
                    content.Position = 0;
                CopyStream(content, fileStream);
            }
        }
        /// <summary>
        /// Removes directory
        /// </summary>
        /// <param name="path">Directory path.</param>
        public void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch (IOException)
                {
                    //NOTE: ignore
                }
            }
        }
        /// <summary>
        /// Retrieves file information
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>File information.</returns>
        public IFileInfo GetFileInfo(string path)
        {
            System.IO.FileInfo info = new System.IO.FileInfo(path);
            Storage.FileInfo fileInfo = new Storage.FileInfo();
            if (info.Exists)
            {
                fileInfo.Path = path;
                fileInfo.LastModified = info.LastWriteTime;
                fileInfo.Size = info.Length;
                fileInfo.IsDirectory = false;
            }
            return fileInfo;
        }
        /// <summary>
        /// Retrieves list of files and folders
        /// </summary>
        /// <param name="path">Directory path.</param>
        /// <returns>Files and folders.</returns>
        public IEnumerable<IFileInfo> GetFilesInfo(string path)
        {
            List<IFileInfo> filesInfo = new List<IFileInfo>();
            foreach (string directory in Directory.GetDirectories(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                IFileInfo info = new Storage.FileInfo();
                info.IsDirectory = true;
                info.Path = directoryInfo.FullName;
                info.LastModified = directoryInfo.LastWriteTime;
                filesInfo.Add(info);
            }
            foreach (string file in Directory.GetFiles(path))
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                IFileInfo info = new Storage.FileInfo();
                info.IsDirectory = false;
                info.Path = fileInfo.FullName;
                info.LastModified = fileInfo.LastWriteTime;
                info.Size = fileInfo.Length;
                filesInfo.Add(info);
            }
            return filesInfo;
        }
        private void CopyStream(Stream src, Stream dst)
        {
            const int bufferSize = 81920; //NOTE: taken from System.IO
            byte[] buffer = new byte[bufferSize];
            int read;
            while ((read = src.Read(buffer, 0, buffer.Length)) != 0)
                dst.Write(buffer, 0, read);
        }
    }
    //ExEnd:LocalFileStorage_18.4
}
