using System;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using GroupDocs.Viewer.Exceptions;

namespace GroupDocs.Viewer.MVC.Products.Viewer.Cache
{
    sealed class CrossProcessLock : IDisposable
    {
        private const int MaxMutexIdLength = 260;
        private readonly Mutex mutex;
        private readonly bool isMutexOwner;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrossProcessLock"/> class.
        /// </summary>
        /// <param name="path">The file path.</param>
        public CrossProcessLock(string path)
        {
            string mutexId = this.GetMutexId(path);
            MutexSecurity mutexSecurity = this.GetMutexSecurity();
            try
            {
                bool createdNew;
                this.mutex = new Mutex(false, mutexId, out createdNew, mutexSecurity);

                try
                {
                    this.isMutexOwner = this.mutex.WaitOne(10 * 60 * 1000);
                }
                catch (AbandonedMutexException)
                {
                    // NOTE: Log the fact the mutex was abandoned in another process, it will still get acquired
                }
            }
            catch (WaitHandleCannotBeOpenedException ex)
            {
                // the mutex cannot be opened, probably because a Win32 object of a different
                // type with the same name already exists.
                throw new GroupDocsViewerException("Mutex can't be opened: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                // the mutex exists, but the current process or thread token does not
                // have permission to open the mutex with SYNCHRONIZE | MUTEX_MODIFY rights.
                throw new GroupDocsViewerException("Current process does not have permission to open the mutex: " + ex.Message);
            }
        }

        /// <summary>
        /// Releases mutex.
        /// </summary>
        public void Dispose()
        {
            if (this.mutex != null)
            {
                if (this.isMutexOwner)
                {
                    this.mutex.ReleaseMutex();
                }

                this.mutex.Close();
            }
        }

        private MutexSecurity GetMutexSecurity()
        {
            SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            MutexAccessRule allowEveryone = new MutexAccessRule(everyone, MutexRights.Synchronize | MutexRights.Modify, AccessControlType.Allow);
            MutexSecurity mutexSecurity = new MutexSecurity();
            mutexSecurity.AddAccessRule(allowEveryone);

            return mutexSecurity;
        }

        private string GetMutexId(string path)
        {
            string normalized = path.Replace("\\", "_");

            string mutexId = normalized;
            if (mutexId.Length < MaxMutexIdLength)
            {
                return mutexId;
            }

            int maxPathLength = MaxMutexIdLength;

            string trimmedPath = normalized.Length > maxPathLength
                ? normalized.Substring(normalized.Length - maxPathLength)
                : normalized;

            return trimmedPath;
        }
    }
}