using System;
using System.IO;
using System.Reflection;

namespace GroupDocs.Viewer.MVC.AppDomainGenerator
{
    public class DomainGenerator
    {
        private readonly Products.Common.Config.GlobalConfiguration globalConfiguration;
        private readonly Type CurrentType;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainGenerator"/> class.
        /// </summary>
        public DomainGenerator(string assemblyName, string className)
        {
            this.globalConfiguration = new Products.Common.Config.GlobalConfiguration();

            // Get assembly path
            string assemblyPath = GetAssemblyPath(assemblyName);

            // Initiate GroupDocs license class
            this.CurrentType = this.CreateDomain(assemblyName + "Domain", assemblyPath, className);
        }

        /// <summary>
        /// Get assembly full path by its name.
        /// </summary>
        /// <param name="assemblyName">string.</param>
        /// <returns></returns>
        private static string GetAssemblyPath(string assemblyName)
        {
            string path = string.Empty;

            // Get path of the executable
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string uriPath = Uri.UnescapeDataString(uri.Path);

            // Get path of the assembly
            path = Path.Combine(Path.GetDirectoryName(uriPath), assemblyName);
            return path;
        }

        /// <summary>
        /// Create AppDomain for the assembly.
        /// </summary>
        /// <param name="domainName">string.</param>
        /// <param name="assemblyPath">string.</param>
        /// <param name="className">string.</param>
        /// <returns></returns>
        private Type CreateDomain(string domainName, string assemblyPath, string className)
        {
            // Create domain
            AppDomain dom = AppDomain.CreateDomain(domainName);
            AssemblyName assemblyName = new AssemblyName { CodeBase = assemblyPath };

            // Load assembly into the domain
            Assembly assembly = dom.Load(assemblyName);

            // Initiate class from the loaded assembly
            Type type = assembly.GetType(className);
            return type;
        }

        /// <summary>
        /// Set GroupDocs.Viewer license.
        /// </summary>
        /// <param name="type">Type.</param>
        public void SetViewerLicense()
        {
            // Initiate license class
            var obj = (GroupDocs.Viewer.License)Activator.CreateInstance(this.CurrentType);

            // Set license
            this.SetLicense(obj);
        }

        private void SetLicense(dynamic obj)
        {
            if (!string.IsNullOrEmpty(this.globalConfiguration.Application.LicensePath))
            {
                obj.SetLicense(this.globalConfiguration.Application.LicensePath);
            }
        }
    }
}