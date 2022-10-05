namespace GroupDocs.Viewer.AspNetMvc.Core.Configuration
{
    public class Language
    {
        public static readonly Language Arabic = new Language("ar");
        public static readonly Language Catalan = new Language("ca");
        public static readonly Language Czech = new Language("cs");
        public static readonly Language Danish = new Language("da");
        public static readonly Language German = new Language("de");
        public static readonly Language Greek = new Language("el");
        public static readonly Language English = new Language("en");
        public static readonly Language Spanish = new Language("es");
        public static readonly Language Filipino = new Language("fil");
        public static readonly Language French = new Language("fr");
        public static readonly Language Hebrew = new Language("he");
        public static readonly Language Hindi = new Language("hi");
        public static readonly Language Indonesian = new Language("id");
        public static readonly Language Italian = new Language("it");
        public static readonly Language Japanese = new Language("ja");
        public static readonly Language Kazakh = new Language("kk");
        public static readonly Language Korean = new Language("ko");
        public static readonly Language Malay = new Language("ms");
        public static readonly Language Dutch = new Language("nl");
        public static readonly Language Polish = new Language("pl");
        public static readonly Language Portuguese = new Language("pt");
        public static readonly Language Romanian = new Language("ro");
        public static readonly Language Russian = new Language("ru");
        public static readonly Language Swedish = new Language("sv");
        public static readonly Language Vietnamese = new Language("vi");
        public static readonly Language Thai = new Language("th");
        public static readonly Language Turkish = new Language("tr");
        public static readonly Language Ukrainian = new Language("uk");
        public static readonly Language ChineseSimplified = new Language("zh-hans");
        public static readonly Language ChineseTraditional = new Language("zh-hant");

        public string Code { get; }

        public Language(string code)
        {
            Code = code;
        }
    }
}