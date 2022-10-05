using System;
using System.Threading.Tasks;

namespace GroupDocs.Viewer.AspNetWebForms.Core
{
    public interface IAsyncLock
    {
        Task<IDisposable> LockAsync(object key);
    }
}