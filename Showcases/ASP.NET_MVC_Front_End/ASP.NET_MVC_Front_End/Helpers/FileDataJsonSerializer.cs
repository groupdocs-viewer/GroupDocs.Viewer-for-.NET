using System;
using System.Globalization;
using System.Linq;
using System.Text;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;

namespace MvcSample.Helpers
{
    /// <summary>
    /// Class FileDataJsonSerializer.
    /// </summary>
    public class FileDataJsonSerializer
    { 
         
        /// <summary>
        /// The _default culture
        /// </summary>
        private readonly CultureInfo _defaultCulture = CultureInfo.InvariantCulture;

          

        /// <summary>
        /// Appends the page.
        /// </summary>
        /// <param name="pageData">The page data.</param>
        /// <param name="json">The json.</param>
        private void AppendPage(PageData pageData, StringBuilder json)
        {
            json.Append(string.Format("{{\"w\":{0},\"h\":{1},\"number\":{2},\"rotation\":{3}",
                pageData.Width.ToString(_defaultCulture),
                pageData.Height.ToString(_defaultCulture),
                (pageData.Number).ToString(_defaultCulture),
                pageData.Angle));
        }

        /// <summary>
        /// Appends the row.
        /// </summary>
        /// <param name="rowData">The row data.</param>
        /// <param name="json">The json.</param>
        private void AppendRow(RowData rowData, StringBuilder json)
        {
            string[] textCoordinates = new string[rowData.TextCoordinates.Count];
            for (int i = 0; i < rowData.TextCoordinates.Count; i++)
                textCoordinates[i] = rowData.TextCoordinates[i].ToString(_defaultCulture);

            string[] characterCoordinates = new string[rowData.CharacterCoordinates.Count];
            for (int i = 0; i < rowData.CharacterCoordinates.Count; i++)
                characterCoordinates[i] = rowData.CharacterCoordinates[i].ToString(_defaultCulture);

            json.Append(String.Format("{{\"l\":{0},\"t\":{1},\"w\":{2},\"h\":{3},\"c\":[{4}],\"s\":\"{5}\",\"ch\":[{6}]}}",
                rowData.LineLeft.ToString(_defaultCulture),
                rowData.LineTop.ToString(_defaultCulture),
                rowData.LineWidth.ToString(_defaultCulture),
                rowData.LineHeight.ToString(_defaultCulture),
                string.Join(",", textCoordinates),
                JsonEncode(rowData.Text),
                string.Join(",", characterCoordinates)));
        }
        
        /// <summary>
        /// Jsons the encode.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        private string JsonEncode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            int i;
            int length = text.Length;
            StringBuilder stringBuilder = new StringBuilder(length + 4);
            for (i = 0; i < length; i += 1)
            {
                char c = text[i];
                switch (c)
                {
                    case '\\':
                    case '"':
                    case '/':
                        stringBuilder.Append('\\');
                        stringBuilder.Append(c);
                        break;
                    case '\b':
                        stringBuilder.Append("\\b");
                        break;
                    case '\t':
                        stringBuilder.Append("\\t");
                        break;
                    case '\n':
                        stringBuilder.Append("\\n");
                        break;
                    case '\f':
                        stringBuilder.Append("\\f");
                        break;
                    case '\r':
                        stringBuilder.Append("\\r");
                        break;
                    default:
                        if (c < ' ')
                        {
                            string t = "000" + Convert.ToByte(c).ToString("X");
                            stringBuilder.Append("\\u" + t.Substring(t.Length - 4));
                        }
                        else
                        {
                            stringBuilder.Append(c);
                        }
                        break;
                }
            }
            return stringBuilder.ToString();
        }
    }
}