using System;
using System.Globalization;
using System.Linq;
using System.Text;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Converter.Options;
using System.Collections.Generic;

namespace MvcSample.Controllers
{
    /// <summary>
    /// Class FileDataJsonSerializer.
    /// </summary>
    public class FileDataJsonSerializer
    {
        /// <summary>
        /// The _file data
        /// </summary>
        private readonly List<PageData> _fileData;
        /// <summary>
        /// The _options
        /// </summary>
        private readonly FileDataOptions _options;

        /// <summary>
        /// The _default culture
        /// </summary>
        private readonly CultureInfo _defaultCulture = CultureInfo.InvariantCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDataJsonSerializer"/> class.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        /// <param name="options">The options.</param>
        public FileDataJsonSerializer(List<PageData> fileData, FileDataOptions options)
        {
            _fileData = fileData;
            _options = options;
        }

        /// <summary>
        /// Serializes this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Serialize(bool isDefault)
        {
      

            var isCellsFileData = _fileData.Any(_ => !string.IsNullOrEmpty(_.Name));
            if (isCellsFileData && !isDefault)
                return SerializeCells();

            return SerializeDefault();
        }

        /// <summary>
        /// Serializes the default.
        /// </summary>
        /// <returns>System.String.</returns>
        private string SerializeDefault()
        {
            StringBuilder json = new StringBuilder();

            json.Append(string.Format("{{\"maxPageHeight\":{0},\"widthForMaxHeight\":{1}",
                _fileData[0].Height, _fileData[0].Height));
            json.Append(",\"pages\":[");

            int pageCount = _fileData.Count;
            for (int i = 0; i < pageCount; i++)
            {
                PageData pageData = _fileData[i];

                bool needSeparator = pageData.Number != 1;
                if (needSeparator)
                    json.Append(",");

                AppendPage(pageData, json);

                bool includeRows = _options.UsePdf && pageData.Rows.Count > 0;
                if (includeRows)
                {
                    json.Append(",\"rows\":[");
                    for (int j = 0; j < pageData.Rows.Count; j++)
                    {
                        bool appendRowSeaparator = j != 0;
                        if (appendRowSeaparator)
                            json.Append(",");

                        AppendRow(pageData.Rows[j], json);
                    }
                    json.Append("]"); // rows
                }
                json.Append("}"); // page
            }
            json.Append("]"); // pages
            json.Append("}"); // document

            return json.ToString();
        }

        /// <summary>
        /// Serializes cells.
        /// </summary>
        /// <returns>System.String.</returns>
        private string SerializeCells()
        {
            StringBuilder json = new StringBuilder();

            json.Append("{\"sheets\":[");

            int pageCount = _fileData.Count;
            for (int i = 0; i < pageCount; i++)
            {
                PageData pageData = _fileData[i];

                bool needSeparator = pageData.Number != 1;
                if (needSeparator)
                    json.Append(",");

                json.Append(string.Format("{{\"name\":\"{0}\"}}", pageData.Name));
            }

            json.Append("]"); // pages
            json.Append("}"); // document

            return json.ToString();
        }

        /// <summary>
        /// Serializes the specified words file data.
        /// </summary>
        /// <param name="wordsFileData">The words file data.</param>
        /// <returns>System.String.</returns>
        private string SerializeWords(PageData wordsFileData)
        {
         /*   StringBuilder json = new StringBuilder();

            json.Append(string.Format("{{\"maxPageHeight\":{0},\"widthForMaxHeight\":{1}",
                _fileData., _fileData.MaxHeight));
            json.Append(",\"pages\":[");

            int pageCount = wordsFileData.Pages.Count;
            for (int i = 0; i < pageCount; i++)
            {
                PageData pageData = wordsFileData.Pages[i];

                bool needSeparator = pageData.Number != 1;
                if (needSeparator)
                    json.Append(",");

                AppendPage(pageData, json);

                json.Append("}"); // page
            }
            json.Append("]"); // pages

            bool includeContentControls = _options.IncludeContentControls && wordsFileData.ContentControls.Count > 0;
            if (includeContentControls)
            {
                json.Append(", \"contentControls\":[");
                bool needSeparator = false;
                foreach (ContentControl contentControl in wordsFileData.ContentControls)
                {
                    if (needSeparator)
                        json.Append(',');

                    AppendContentControl(contentControl, json);

                    needSeparator = true;
                }
                json.Append("]"); //contentControls
            }
            json.Append("}"); //document

            return json.ToString();
          * */
            return "";
        }

        /// <summary>
        /// Appends the page.
        /// </summary>
        /// <param name="pageData">The page data.</param>
        /// <param name="json">The json.</param>
        private void AppendPage(PageData pageData, StringBuilder json)
        {
            json.Append(string.Format("{{\"w\":{0},\"h\":{1},\"number\":{2}",
                pageData.Width.ToString(_defaultCulture),
                pageData.Height.ToString(_defaultCulture),
                pageData.Number.ToString(_defaultCulture)));
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
        /// Appends the content control.
        /// </summary>
        /// <param name="contentControl">The content control.</param>
        /// <param name="json">The json.</param>
        private void AppendContentControl(ContentControl contentControl, StringBuilder json)
        {
            json.Append(string.Format("{{\"title\":\"{0}\", \"startPage\":{1}, \"endPage\":{2}}}",
                JsonEncode(contentControl.Title),
                contentControl.StartPageNumber.ToString(_defaultCulture),
                contentControl.EndPageNumber.ToString(_defaultCulture)));
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