using System.Collections.Generic;
using System.Threading.Tasks;
using GroupDocs.Viewer.AspNetMvc.Core.Entities;

namespace GroupDocs.Viewer.AspNetMvc.Core
{
    public interface IFileStorage
    {
        Task<IEnumerable<FileSystemEntry>> ListDirsAndFilesAsync(string dirPath);

        Task<byte[]> ReadFileAsync(string filePath);

        Task<string> WriteFileAsync(string fileName, byte[] bytes, bool rewrite);
    }
}