using System.Threading.Tasks;
using GroupDocs.Viewer.AspNetMvc.Core.Entities;

namespace GroupDocs.Viewer.AspNetMvc.Core
{
    public interface IPageFormatter
    {
        Task<Page> FormatAsync(FileCredentials fileCredentials, Page page);
    }
}