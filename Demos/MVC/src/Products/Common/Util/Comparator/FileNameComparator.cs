using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GroupDocs.Viewer.MVC.Products.Common.Util.Comparator
{
    /// <summary>
    /// FileNameComparator.
    /// </summary>
    public class FileNameComparator : IComparer<string>
    {
        /// <summary>
        /// Compare file names.
        /// </summary>
        /// <param name="x">string.</param>
        /// <param name="y">string.</param>
        /// <returns></returns>
        public int Compare(string x, string y)
        {
            string strExt1 = Path.GetFileName(x);
            string strExt2 = Path.GetFileName(y);

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