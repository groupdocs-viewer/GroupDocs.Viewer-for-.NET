using System.IO;
using System.Threading.Tasks;

namespace GroupDocs.Viewer.AspNetWebForms.Core.FileTypeResolution
{
    public class FileExtensionFileTypeResolver : IFileTypeResolver
    {
        public Task<FileType> ResolveFileTypeAsync(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            FileType fileType = FileType.FromExtension(extension);

            return Task.FromResult(fileType);
        }
    }
}