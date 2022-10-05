using System.Threading.Tasks;
using GroupDocs.Viewer.AspNetWebForms.Core.Entities;

namespace GroupDocs.Viewer.AspNetWebForms.Core.PageFormatting
{
    public class NoopPageFormatter : IPageFormatter
    {
        public Task<Page> FormatAsync(FileCredentials fileCredentials, Page page) => 
            Task.FromResult(page);
    }
}