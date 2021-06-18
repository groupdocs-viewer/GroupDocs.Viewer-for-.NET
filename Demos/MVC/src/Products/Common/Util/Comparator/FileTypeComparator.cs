using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GroupDocs.Viewer.MVC.Products.Common.Util.Comparator
{
    /// <summary>
    /// FileTypeComparator.
    /// </summary>
    public class FileTypeComparator : IComparer<string>
    {
        /// <summary>
        /// Compare file types.
        /// </summary>
        /// <param name="x">string.</param>
        /// <param name="y">string.</param>
        /// <returns></returns>
        public int Compare(string x, string y)
        {
            string strExt1 = Path.GetExtension(x);
            string strExt2 = Path.GetExtension(y);

            if (string.Equals(strExt1, strExt2, StringComparison.Ordinal))
            {
                return string.Compare(x, y, false, CultureInfo.InvariantCulture);
            }
            else
            {
                return string.Compare(strExt1, strExt2, false, CultureInfo.InvariantCulture);
            }
        }
    }
}