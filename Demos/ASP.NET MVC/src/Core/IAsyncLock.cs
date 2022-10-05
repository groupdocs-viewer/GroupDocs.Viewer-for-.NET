using System;
using System.Threading.Tasks;

namespace GroupDocs.Viewer.AspNetMvc.Core
{
    public interface IAsyncLock
    {
        Task<IDisposable> LockAsync(object key);
    }
}