using System;
using System.IO;
using GroupDocs.Viewer.AspNetMvc.Core.Configuration;

namespace GroupDocs.Viewer.AspNetMvc.Core.Licensing
{
    internal class LicenseFileViewerLicenser : IViewerLicenser
    {
        private readonly ViewerConfig _config;
        private readonly object _lock = new object();
        private bool _licenseSet;

        public LicenseFileViewerLicenser(ViewerConfig config)
        {
            _config = config;
        }

        public void SetLicense()
        {
            if (_licenseSet)
                return;

            TrySetLicense(_config.LicensePath);

            string licensePath = Environment.GetEnvironmentVariable("GROUPDOCS_LIC_PATH");
            TrySetLicense(licensePath);
        }

        private void TrySetLicense(string licensePath)
        {
            if (string.IsNullOrWhiteSpace(licensePath))
                return;

            // Local file path: apply only when the file exists.
            // Remote/URL licenses are attempted, but failures must not break the demo (trial mode).
            bool looksLikeLocalPath = !licensePath.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                && !licensePath.StartsWith("https://", StringComparison.OrdinalIgnoreCase);

            if (looksLikeLocalPath && !File.Exists(licensePath))
                return;

            try
            {
                lock (_lock)
                {
                    if (_licenseSet)
                        return;

                    License license = new License();
                    license.SetLicense(licensePath);
                    _licenseSet = true;
                }
            }
            catch (Exception)
            {
                // Keep running in evaluation mode when a license cannot be applied.
            }
        }
    }
}
