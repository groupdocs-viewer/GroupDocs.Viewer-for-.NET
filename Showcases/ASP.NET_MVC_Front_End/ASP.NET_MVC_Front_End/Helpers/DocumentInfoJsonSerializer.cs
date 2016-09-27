using System;
using System.Globalization;
using System.Linq;
using System.Text;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;

namespace MvcSample.Helpers
{
    /// <summary>
    /// Class FileDataJsonSerializer.
    /// </summary>
    public class DocumentInfoJsonSerializer
    {
        /// <summary>
        /// The document info
        /// </summary>
        private readonly DocumentInfoContainer _documentInfo;

        /// <summary>
        /// The _options
        /// </summary>
        private readonly SerializationOptions _options;

        /// <summary>
        /// The _default culture
        /// </summary>
        private readonly CultureInfo _defaultCulture = CultureInfo.InvariantCulture;

        /// <summary>
        /// Two decimals places format
        /// </summary>
        private const string TwoDecimalPlacesFormat = "0.##";

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentInfoContainer"/> class.
        /// </summary>
        /// <param name="documentInfo">The document info.</param>
        /// <param name="options">The options.</param>
        public DocumentInfoJsonSerializer(DocumentInfoContainer documentInfo, SerializationOptions options)
        {
            _documentInfo = documentInfo;
            _options = options;
        }

        /// <summary>
        /// Serializes this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Serialize()
        {
            var isCellsFileData = _documentInfo.Pages.Any(_ => !string.IsNullOrEmpty(_.Name));
            if (isCellsFileData && _options.IsHtmlMode)
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

            var maxWidth = 0;
            var maxHeight = 0;
            foreach (var pageData in _documentInfo.Pages)
            {
                if (pageData.Height > maxHeight)
                {
                    maxHeight = pageData.Height;
                    maxWidth = pageData.Width;
                }
            }
          
            json.Append("{\"pages\":[");

            int pageCount = _documentInfo.Pages.Count;
            for (int i = 0; i < pageCount; i++)
            {
                PageData pageData = _documentInfo.Pages[i];

                bool needSeparator = i > 0;
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

            json.Append(string.Format(",\"maxPageHeight\":{0},\"widthForMaxHeight\":{1}",
              maxHeight, maxWidth));
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

            int pageCount = _documentInfo.Pages.Count;
            for (int i = 0; i < pageCount; i++)
            {
                PageData pageData = _documentInfo.Pages[i];

                bool needSeparator = i > 0;
                if (needSeparator)
                    json.Append(",");

                json.Append(string.Format("{{\"name\":\"{0}\"}}", pageData.Name));
            }

            json.Append("]"); // pages
            json.Append("}"); // document

            return json.ToString();
        }

        

        /// <summary>
        /// Appends the page.
        /// </summary>
        /// <param name="pageData">The page data.</param>
        /// <param name="json">The json.</param>
        private void AppendPage(PageData pageData, StringBuilder json)
        {
            if (pageData.Angle == 0)
            {
                json.Append(string.Format("{{\"w\":{0},\"h\":{1},\"number\":{2}",
                   pageData.Width.ToString(_defaultCulture),
                   pageData.Height.ToString(_defaultCulture),
                   (pageData.Number).ToString(_defaultCulture)));
            }
            else
            {
                json.Append(string.Format("{{\"w\":{0},\"h\":{1},\"number\":{2},\"rotation\":{3}",
                    pageData.Width.ToString(_defaultCulture),
                    pageData.Height.ToString(_defaultCulture),
                    (pageData.Number).ToString(_defaultCulture),
                    pageData.Angle));
            }
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
                textCoordinates[i] = rowData.TextCoordinates[i].ToString(TwoDecimalPlacesFormat, _defaultCulture);

            string[] characterCoordinates = new string[rowData.CharacterCoordinates.Count];
            for (int i = 0; i < rowData.CharacterCoordinates.Count; i++)
                characterCoordinates[i] = rowData.CharacterCoordinates[i].ToString(TwoDecimalPlacesFormat, _defaultCulture);

            json.Append(String.Format("{{\"l\":{0},\"t\":{1},\"w\":{2},\"h\":{3},\"c\":[{4}],\"s\":\"{5}\",\"ch\":[{6}]}}",
                rowData.LineLeft.ToString(TwoDecimalPlacesFormat, _defaultCulture),
                rowData.LineTop.ToString(TwoDecimalPlacesFormat, _defaultCulture),
                rowData.LineWidth.ToString(TwoDecimalPlacesFormat, _defaultCulture),
                rowData.LineHeight.ToString(TwoDecimalPlacesFormat, _defaultCulture),
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

    public class SerializationOptions
    {
        public bool UsePdf { get; set; }
        public bool IsHtmlMode { get; set; }
        public bool SupportListOfBookmarks { get; set; }
        public bool SupportListOfContentControls { get; set; }
    }
}