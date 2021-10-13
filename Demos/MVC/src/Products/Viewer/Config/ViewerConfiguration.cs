using GroupDocs.Viewer.MVC.Products.Common.Config;
using GroupDocs.Viewer.MVC.Products.Common.Util.Parser;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace GroupDocs.Viewer.MVC.Products.Viewer.Config
{
    /// <summary>
    /// ViewerConfiguration.
    /// </summary>
    public class ViewerConfiguration : CommonConfiguration
    {
        [JsonProperty]
        private string filesDirectory = "DocumentSamples/Viewer";

        [JsonProperty]
        private string fontsDirectory = string.Empty;

        [JsonProperty]
        private string defaultDocument = string.Empty;

        [JsonProperty]
        private string watermarkText = string.Empty;

        [JsonProperty]
        private int preloadPageCount;

        [JsonProperty]
        private bool zoom = true;

        [JsonProperty]
        private bool search = true;

        [JsonProperty]
        private bool thumbnails = true;

        [JsonProperty]
        private bool rotate = true;

        [JsonProperty]
        private bool htmlMode = true;

        [JsonProperty]
        private bool cache = true;

        [JsonProperty]
        private bool saveRotateState = true;

        [JsonProperty]
        private bool printAllowed = true;

        [JsonProperty]
        private bool showGridLines = true;

        [JsonProperty]
        private string cacheFolderName = "cache";

        [JsonProperty]
        private bool showLanguageMenu = true;

        [JsonProperty]
        private string defaultLanguage = "en";

        [JsonProperty] 
        private string[] supportedLanguages = new string[] 
        {
            "ar", // العربية
            "ca", // Català
            "cs", // Čeština
            "da", // Dansk
            "de", // Deutsch
            "el", // Ελληνικά
            "en", // English
            "es", // Español
            "fil", // Filipino
            "fr", // Français
            "he", // עברית
            "hi", // हिन्दी
            "id", // Indonesia
            "it", // Italiano
            "ja", // 日本語
            "kk", // Қазақ Тілі
            "ko", // 한국어
            "ms", // Melayu
            "nl", // Nederlands
            "pl", // Polski
            "pt", // Português
            "ro", // Română
            "ru", // Русский
            "sv", // Svenska
            "vi", // Tiếng Việt
            "th", // ไทย
            "tr", // Türkçe
            "uk", // Українська
            "zh-hans", // 中文
            "zh-hant", // 中文
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewerConfiguration"/> class.
        /// </summary>
        public ViewerConfiguration()
        {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("viewer");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);

            // get Viewer configuration section from the web.config
            this.filesDirectory = valuesGetter.GetStringPropertyValue("filesDirectory", this.filesDirectory);
            if (!IsFullPath(this.filesDirectory))
            {
                this.filesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.filesDirectory);
                if (!Directory.Exists(this.filesDirectory))
                {
                    Directory.CreateDirectory(this.filesDirectory);
                }
            }

            this.cacheFolderName = valuesGetter.GetStringPropertyValue("cacheFolderName", this.cacheFolderName);
            if (!IsFullPath(this.cacheFolderName))
            {
                var cacheDirectory = Path.Combine(this.filesDirectory, this.cacheFolderName);
                if (!Directory.Exists(cacheDirectory))
                {
                    Directory.CreateDirectory(cacheDirectory);
                }
            }

            this.fontsDirectory = valuesGetter.GetStringPropertyValue("fontsDirectory", this.fontsDirectory);
            this.defaultDocument = valuesGetter.GetStringPropertyValue("defaultDocument", this.defaultDocument);
            this.preloadPageCount = valuesGetter.GetIntegerPropertyValue("preloadPageCount", this.preloadPageCount);
            this.zoom = valuesGetter.GetBooleanPropertyValue("zoom", this.zoom);
            this.search = valuesGetter.GetBooleanPropertyValue("search", this.search);
            this.thumbnails = valuesGetter.GetBooleanPropertyValue("thumbnails", this.thumbnails);
            this.rotate = valuesGetter.GetBooleanPropertyValue("rotate", this.rotate);
            this.htmlMode = valuesGetter.GetBooleanPropertyValue("htmlMode", this.htmlMode);
            this.cache = valuesGetter.GetBooleanPropertyValue("cache", this.cache);
            this.saveRotateState = valuesGetter.GetBooleanPropertyValue("saveRotateState", this.saveRotateState);
            this.watermarkText = valuesGetter.GetStringPropertyValue("watermarkText", this.watermarkText);
            this.printAllowed = valuesGetter.GetBooleanPropertyValue("printAllowed", this.printAllowed);
            this.showGridLines = valuesGetter.GetBooleanPropertyValue("showGridLines", this.showGridLines);
            this.showLanguageMenu = valuesGetter.GetBooleanPropertyValue("showLanguageMenu", this.showLanguageMenu);
            this.defaultLanguage = valuesGetter.GetStringPropertyValue("defaultLanguage", this.defaultLanguage);
            this.supportedLanguages = valuesGetter.GetStringArrayPropertyValue("supportedLanguages", this.supportedLanguages);
        }

        private static bool IsFullPath(string path)
        {
            return !string.IsNullOrWhiteSpace(path)
                && path.IndexOfAny(System.IO.Path.GetInvalidPathChars().ToArray()) == -1
                && Path.IsPathRooted(path)
                && !Path.GetPathRoot(path).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
        }

        public void SetFilesDirectory(string filesDirectory)
        {
            this.filesDirectory = filesDirectory;
        }

        public string GetFilesDirectory()
        {
            return this.filesDirectory;
        }

        public void SetCacheFolderName(string cacheFolderName)
        {
            this.cacheFolderName = cacheFolderName;
        }

        public string GetCacheFolderName()
        {
            return this.cacheFolderName;
        }

        public void SetFontsDirectory(string fontsDirectory)
        {
            this.fontsDirectory = fontsDirectory;
        }

        public string GetFontsDirectory()
        {
            return this.fontsDirectory;
        }

        public void SetDefaultDocument(string defaultDocument)
        {
            this.defaultDocument = defaultDocument;
        }

        public string GetDefaultDocument()
        {
            return this.defaultDocument;
        }

        public void SetPreloadPageCount(int preloadPageCount)
        {
            this.preloadPageCount = preloadPageCount;
        }

        public int GetPreloadPageCount()
        {
            return this.preloadPageCount;
        }

        public void SetIsZoom(bool isZoom)
        {
            this.zoom = isZoom;
        }

        public bool GetIsZoom()
        {
            return this.zoom;
        }

        public void SetIsSearch(bool isSearch)
        {
            this.search = isSearch;
        }

        public bool GetIsSearch()
        {
            return this.search;
        }

        public void SetIsThumbnails(bool isThumbnails)
        {
            this.thumbnails = isThumbnails;
        }

        public bool GetIsThumbnails()
        {
            return this.thumbnails;
        }

        public void SetIsRotate(bool isRotate)
        {
            this.rotate = isRotate;
        }

        public bool GetIsRotate()
        {
            return this.rotate;
        }

        public void SetIsHtmlMode(bool isHtmlMode)
        {
            this.htmlMode = isHtmlMode;
        }

        public bool GetIsHtmlMode()
        {
            return this.htmlMode;
        }

        public void SetCache(bool Cache)
        {
            this.cache = Cache;
        }

        public bool GetCache()
        {
            return this.cache;
        }

        public void SetSaveRotateState(bool saveRotateState)
        {
            this.saveRotateState = saveRotateState;
        }

        public bool GetSaveRotateState()
        {
            return this.saveRotateState;
        }

        public void SetWatermarkText(string watermarkText)
        {
            this.watermarkText = watermarkText;
        }

        public string GetWatermarkText()
        {
            return this.watermarkText;
        }

        public void SetPrintAllowed(bool printAllowed)
        {
            this.printAllowed = printAllowed;
        }

        public bool GetPrintAllowed()
        {
            return this.printAllowed;
        }

        public void SetShowGridLines(bool showGridLines)
        {
            this.showGridLines = showGridLines;
        }

        public bool GetShowGridLines()
        {
            return this.showGridLines;
        }

        public void SetShowLanguageMenu(bool showLanguageMenu)
        {
            this.showLanguageMenu = showLanguageMenu;
        }

        public bool GetShowLanguageMenu()
        {
            return this.showLanguageMenu;
        }

        public void SetDefaultLanguage(string defaultLanguage)
        {
            this.defaultLanguage = defaultLanguage;
        }

        public string GetDefaultLanguage()
        {
            return this.defaultLanguage;
        }

        public void SetSupportedLanguages(string[] supportedLanguages)
        {
            this.supportedLanguages = supportedLanguages;
        }

        public string[] GetSupportedLanguages()
        {
            return this.supportedLanguages;
        }
    }
}
