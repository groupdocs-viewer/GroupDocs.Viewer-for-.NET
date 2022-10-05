using System;
using System.IO;
using GroupDocs.Viewer.AspNetWebForms.Core.Configuration;

namespace GroupDocs.Viewer.AspNetWebForms.Core.Licensing
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

            if (File.Exists(_config.LicensePath))
                SetLicense(_config.LicensePath);

            string licensePath = Environment.GetEnvironmentVariable("GROUPDOCS_LIC_PATH");
            if (!string.IsNullOrEmpty(licensePath))
                SetLicense(licensePath);
        }

        private void SetLicense(string licensePath)
        {
            lock (_lock)
            {
                if (!_licenseSet)
                {
                    License license = new License();
                    license.SetLicense(licensePath);

                    _licenseSet = true;
                }
            }
        }
    }
}