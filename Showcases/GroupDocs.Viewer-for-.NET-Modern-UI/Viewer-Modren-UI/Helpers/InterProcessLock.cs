using System;
using System.Threading;

namespace Viewer_Modren_UI.Helpers
{
    public class InterProcessLock : IDisposable
    {
        private const string MutexPrefix = "GD96B6_";
        private Mutex _mutex;

        public InterProcessLock(string path)
        {
            bool newMutexCreated = false;
            string mutexName = MutexPrefix + path.Replace('\\', '_');
            _mutex = new Mutex(true, mutexName, out newMutexCreated);
            if (!newMutexCreated)
                _mutex.WaitOne();
        }

        // Used to determine if Dispose() 
        // has already been called. 
        private bool disposed = false;

        public void Dispose()
        {
            // Call our helper method. 
            // Specifying "true" signifies that 
            // the object user triggered the cleanup. 
            CleanUp(true);

            // Now suppress finalization. 
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            // Be sure we have not already been disposed! 
            if (!this.disposed)
            {
                // If disposing equals true, dispose all 
                // managed resources. 
                if (disposing)
                {
                    _mutex.ReleaseMutex();
                }

                if (_mutex != null)
                    _mutex.Close();
                // Clean up unmanaged resources here. 
                disposed = true;
            }
        }

        ~InterProcessLock()
        {
            // Call our helper method. 
            // Specifying "false" signifies that 
            // the GC triggered the cleanup. 
            CleanUp(false);
        }
    }
}