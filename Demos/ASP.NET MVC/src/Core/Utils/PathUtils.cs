using System.IO;
using System;
using System.Linq;

namespace GroupDocs.Viewer.AspNetMvc.Core.Utils
{
    public static class PathUtils
    {
        public static string GetRelativePath(string relativeTo, string path)
        {
            if (string.IsNullOrEmpty(relativeTo))
                throw new ArgumentNullException(nameof(relativeTo));

            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            Uri fromUri = new Uri(AppendDirectorySeparatorChar(relativeTo));
            Uri toUri = new Uri(AppendDirectorySeparatorChar(path));

            if (fromUri.Scheme != toUri.Scheme)
                return path;

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (string.Equals(toUri.Scheme, Uri.UriSchemeFile, StringComparison.OrdinalIgnoreCase))
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

            return relativePath;
        }

        private static string AppendDirectorySeparatorChar(string path)
        {
            // Append a slash only if the path is a directory and does not have a slash.
            if (!Path.HasExtension(path) &&
                !path.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                return path + Path.DirectorySeparatorChar;
            }

            return path;
        }

        public static string RemoveInvalidFileNameChars(string path)
        {
            Path.GetInvalidFileNameChars().ToList().ForEach(ch =>
            {
                path = path.Replace(ch.ToString(), string.Empty);
            });

            return path;
        }
    }
}