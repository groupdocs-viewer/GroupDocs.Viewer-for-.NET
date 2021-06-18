using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GroupDocs.Viewer.WebForms.Products.Common.Util.Comparator
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

            if (strExt1.Equals(strExt2))
            {
                return string.CompareOrdinal(x, y);
            }
            else
            {
                return string.CompareOrdinal(strExt1, strExt2);
            }
        }
    }
}