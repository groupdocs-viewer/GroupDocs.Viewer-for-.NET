using GroupDocs.Viewer.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupDocs.Viewer.Examples.CSharp.SimpleFileStorageInterfaces
{
    //ExStart:FileInfo_18.4
    /// <summary>
    /// File information
    /// </summary>
    public struct FileInfo : IFileInfo
    {
        /// <summary>
        /// File or directory path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// File size in bytes
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Last modification date
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Indicates if file is directory
        /// </summary>
        public bool IsDirectory { get; set; }
    }
    //ExEnd:FileInfo_18.4
}
