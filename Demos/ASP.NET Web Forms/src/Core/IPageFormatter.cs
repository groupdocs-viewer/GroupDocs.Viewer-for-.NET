using System.Threading.Tasks;
using GroupDocs.Viewer.AspNetWebForms.Core.Entities;

namespace GroupDocs.Viewer.AspNetWebForms.Core
{
    public interface IPageFormatter
    {
        Task<Page> FormatAsync(FileCredentials fileCredentials, Page page);
    }
}