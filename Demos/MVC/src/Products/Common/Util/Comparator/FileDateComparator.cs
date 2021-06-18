using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GroupDocs.Viewer.MVC.Products.Common.Util.Comparator
{
    /// <summary>
    /// FileDateComparator.
    /// </summary>
    public class FileDateComparator : IComparer<string>
    {
        /// <summary>
        /// Compare file creation dates.
        /// </summary>
        /// <param name="x">string.</param>
        /// <param name="y">string.</param>
        /// <returns></returns>
        public int Compare(string x, string y)
        {
            string strExt1 = File.GetCreationTime(x).ToString(CultureInfo.InvariantCulture);
            string strExt2 = File.GetCreationTime(y).ToString(CultureInfo.InvariantCulture);

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