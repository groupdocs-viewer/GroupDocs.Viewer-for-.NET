using System.IO;
using System.Runtime.CompilerServices;

namespace GroupDocs.Viewer.Examples.CSharp
{
    internal static class Utils
    {
        public const string LicensePath = "./Resources/GroupDocs.Viewer.lic";

        public const string SamplesPath = @"./Resources/SampleFiles";
        public const string FontsPath = @"./Resources/Fonts";
        public const string OutputPath = @"./Output";

        public static string GetOutputDirectoryPath([CallerFilePath] string callerFilePath = null)
        {
            string outputDirectory = Path.Combine(OutputPath, Path.GetFileNameWithoutExtension(callerFilePath));

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            string path = Path.GetFullPath(outputDirectory);

            return path;
        }
    }
}
