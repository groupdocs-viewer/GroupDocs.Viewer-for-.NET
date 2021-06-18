using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Viewer.WebForms.Products.Common.Util.Comparator
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