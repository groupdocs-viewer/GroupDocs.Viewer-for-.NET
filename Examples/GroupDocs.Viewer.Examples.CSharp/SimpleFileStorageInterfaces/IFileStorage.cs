using GroupDocs.Viewer.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupDocs.Viewer.Examples.CSharp.SimpleFileStorageInterfaces
{
    //ExStart:IFileStorage_18.4
    /// <summary>
    /// File storage interface
    /// </summary>
    public interface IFileStorage
    {
        /// <summary>
        /// Checks if file exists
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns><c>true</c> when file exists, otherwise <c>false</c></returns>
        bool FileExists(string path);

        /// <summary>
        /// Retrieves file content
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>Stream</returns>
        Stream GetFile(string path);

        /// <summary>
        /// Saves file
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="content">File content.</param>
        void SaveFile(string path, Stream content);

        /// <summary>
        /// Removes directory
        /// </summary>
        /// <param name="path">Directory path.</param>
        void DeleteDirectory(string path);

        /// <summary>
        /// Retrieves file information
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>File information.</returns>
        IFileInfo GetFileInfo(string path);

        /// <summary>
        /// Retrieves list of files and folders
        /// </summary>
        /// <param name="path">Directory path.</param>
        /// <returns>Files and folders.</returns>
        IEnumerable<IFileInfo> GetFilesInfo(string path);
    }
    //ExEnd:IFileStorage_18.4
}
