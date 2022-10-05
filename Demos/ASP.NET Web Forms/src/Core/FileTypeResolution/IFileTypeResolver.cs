using System.Threading.Tasks;

namespace GroupDocs.Viewer.AspNetWebForms.Core.FileTypeResolution
{
    public interface IFileTypeResolver
    {
        Task<FileType> ResolveFileTypeAsync(string filePath);
    }
}