using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp
{
    public static class TestFiles
    {
        // Archives
        public static string SAMPLE_ZIP =>
            GetSampleFilePath("sample.zip");
        public static string SAMPLE_ZIP_WITH_FOLDERS =>
            GetSampleFilePath("with_folders.zip");
        public static string SAMPLE_RAR_WITH_FOLDERS =>
            GetSampleFilePath("with_folders.rar");

        // CAD drawings
        public static string SAMPLE_DWG_WITH_LAYOUTS_AND_LAYERS =>
            GetSampleFilePath("with_layers_and_layouts.dwg");
        public static string SAMPLE_PLT =>
            GetSampleFilePath("sample.plt");
        public static string SAMPLE_CF2 =>
            GetSampleFilePath("sample.cf2");
        public static string SAMPLE_IGS =>
            GetSampleFilePath("sample.igs");
        public static string SAMPLE_OBJ =>
            GetSampleFilePath("sample.obj");
        public static string SAMPLE_HPG =>
            GetSampleFilePath("sample.hpg");

        // Email messages
        public static string SAMPLE_MSG =>
            GetSampleFilePath("sample.msg");
        public static string SAMPLE_MSG_WITH_ATTACHMENTS =>
            GetSampleFilePath("with_attachments.msg");
        public static string SAMPLE_OST =>
            GetSampleFilePath("sample.ost");
        public static string SAMPLE_PST =>
           GetSampleFilePath("sample.pst");
        public static string SAMPLE_OST_SUBFOLDERS =>
            GetSampleFilePath("with_subfolders.ost");

        // PDFs
        public static string SAMPLE_PDF =>
            GetSampleFilePath("sample.pdf");
        public static string HIEROGLYPHS_PDF =>
            GetSampleFilePath("hieroglyphs.pdf");
        public static string HIEROGLYPHS_1_PDF =>
            GetSampleFilePath("hieroglyphs_1.pdf");
        public static string ENCRYPTED =>
            GetSampleFilePath("encrypted.pdf");

        // Presentations
        public static string PPTX_WITH_NOTES =>
            GetSampleFilePath("with_notes.pptx");
        public static string SAMPLE_PPTX_HIDDEN_PAGE =>
            GetSampleFilePath("with_hidden_page.pptx");
        public static string MISSING_FONT_PPTX =>
            GetSampleFilePath("with_missing_font.pptx");
        public static string JPG_IMAGE_PPTX =>
            GetSampleFilePath("with_jpg_image.pptx");
        public static string SAMPLE_FODP =>
            GetSampleFilePath("sample.fodp");

        // Project Management documents
        public static string SAMPLE_MPP =>
            GetSampleFilePath("sample.mpp");

        // Spreadsheets
        public static string SAMPLE_XLSX =>
            GetSampleFilePath("sample.xlsx");
        public static string SAMPLE_XLSX_WITH_PRINT_AREAS =>
            GetSampleFilePath("with_four_print_areas.xlsx");
        public static string SAMPLE_XLSX_WITH_EMPTY_COLUMN =>
            GetSampleFilePath("with_empty_column.xlsx");
        public static string SAMPLE_XLSX_WITH_EMPTY_ROW =>
            GetSampleFilePath("with_empty_row.xlsx");
        public static string SAMPLE_XLSX_WITH_HIDDEN_ROW_AND_COLUMN =>
            GetSampleFilePath("with_hidden_row_and_column.xlsx");
        public static string SAMPLE_XLSX_WITH_TEXT_OVERFLOW =>
            GetSampleFilePath("with_overflowing_text.xlsx");
        public static string THREE_SHEETS =>
            GetSampleFilePath("three_sheets.xlsx");
        public static string SAMPLE_NUMBERS =>
            GetSampleFilePath("sample.numbers");
        public static string SAMPLE_XML_SPREADSHEETML =>
            GetSampleFilePath("excel-2003-xml.xml");

        // Word Processing documents

        public static string SAMPLE_DOCX =>
            GetSampleFilePath("sample.docx");
        public static string SAMPLE_DOCX_WITH_COMMENT =>
            GetSampleFilePath("with_comment.docx");
        public static string SAMPLE_DOCX_WITH_PASSWORD =>
            GetSampleFilePath("password_protected.docx");
        public static string SAMPLE_DOCX_WITH_TRACKED_CHANGES =>
            GetSampleFilePath("with_tracked_changes.docx");
        public static string SAMPLE_TXT_SHIFT_JS_ENCODED =>
            GetSampleFilePath("shift_jis_encoded.txt");
        public static string WITH_EXTERNAL_IMAGE_DOC =>
            GetSampleFilePath("with_external_image.doc");

        // Text
        public static string SAMPLE_TXT =>
            GetSampleFilePath("sample.txt");

        public static string SAMPLE_2_TXT =>
            GetSampleFilePath("sample2.txt");

        // Graphics
        public static string MISSING_FONT_ODG =>
            GetSampleFilePath("with_missing_font.odg");
        public static string SAMPLE_FODG =>
          GetSampleFilePath("sample.fodg");

        private static string GetSampleFilePath(string filePath) =>
           Path.Combine(Utils.SamplesPath, filePath);
    }
}