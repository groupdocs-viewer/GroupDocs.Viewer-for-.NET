using System.Threading.Tasks;
using GroupDocs.Viewer.AspNetMvc.Core.Entities;

namespace GroupDocs.Viewer.AspNetMvc.Core.PageFormatting
{
    public class NoopPageFormatter : IPageFormatter
    {
        public Task<Page> FormatAsync(FileCredentials fileCredentials, Page page) => 
            Task.FromResult(page);
    }
}