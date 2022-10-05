using System.Threading.Tasks;

namespace GroupDocs.Viewer.AspNetMvc.Core.FileTypeResolution
{
    public interface IFileTypeResolver
    {
        Task<FileType> ResolveFileTypeAsync(string filePath);
    }
}