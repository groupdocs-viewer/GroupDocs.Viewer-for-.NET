using System.Linq;

namespace GroupDocs.Viewer.AspNetMvc.Core.Configuration
{
    public class UIConfig
    {
        public static readonly UIConfig Instance = new UIConfig();

        internal string DefaultDocument { get; private set; } = string.Empty;
        internal int PreloadPageCount { get; private set; } = 3;
        internal bool PageSelector { get; private set; } = true;
        internal bool Thumbnails { get; private set; } = true;
        internal bool Zoom { get; private set; } = true;
        internal bool Search { get; private set; } = true;
        internal bool EnableRightClick { get; private set; } = true;
        internal bool Download { get; private set; } = true;
        internal bool Upload { get; private set; } = true;
        internal bool Rewrite { get; private set; } = false;
        internal bool Print { get; private set; } = true;
        internal bool Browse { get; private set; } = true;
        internal bool PrintAllowed { get; private set; } = true;
        internal bool HtmlMode { get; private set; } = true;
        internal bool ShowLanguageMenu { get; private set; } = true;
        internal string DefaultLanguage { get; private set; } = "en";
        internal string[] SupportedLanguages { get; private set; } = new string[]
        {
            "ar", // ar - العربية
            "ca", // ca-ES - Català
            "cs", // cs-CZ - Čeština
            "da", // da-DK - Dansk
            "de", // de-DE - Deutsch
            "el", // el-GR - Ελληνικά
            "en", // en-US - English
            "es", // es-ES - Español
            "fil", // fil-PH - Filipino
            "fr", // fr-FR - Français
            "he", // he-IL - עברית
            "hi", // hi-IN - हिन्दी
            "id", // id-ID - Indonesia
            "it", // it-IT - Italiano
            "ja", // ja-JP - 日本語
            "kk", // kk-KZ - Қазақ Тілі
            "ko", // ko-KR - 한국어
            "ms", // ms-MY - Melayu
            "nl", // nl-NL - Nederlands
            "pl", // pl-PL - Polski
            "pt", // pt-PT - Português
            "ro", // ro-RO - Română
            "ru", // ru-RU - Русский
            "sv", // sv-SE - Svenska
            "vi", // vi-VN - Tiếng Việt
            "th", // th-TH - ไทย
            "tr", // tr-TR - Türkçe
            "uk", // uk-UA - Українська
            "zh-hans", // zh-Hans - 中文(简体)
            "zh-hant", // zh-Hant" - 中文(繁體)
        };

        internal bool Rotate { get; private set; } = false;
        internal bool SaveRotateState { get; private set; } = false;
        internal ViewerType ViewerType { get; private set; }

        public UIConfig SetViewerType(ViewerType viewerType)
        {
            ViewerType = viewerType;    
            HtmlMode = viewerType == ViewerType.HtmlWithExternalResources ||
                       viewerType == ViewerType.HtmlWithEmbeddedResources;
            return this;
        }

        public UIConfig SetPreloadPageCount(int countPages)
        {
            PreloadPageCount = countPages;
            return this;
        }

        public UIConfig SetDefaultDocument(string filePath)
        {
            DefaultDocument = filePath;
            return this;
        }

        public UIConfig HidePageSelectorControl()
        {
            PageSelector = false;
            return this;
        }

        public UIConfig HideThumbnailsControl()
        {
            Thumbnails = false;
            return this;
        }

        public UIConfig DisableFileDownload()
        {
            Download = false;
            return this;
        }

        public UIConfig DisableFileUpload()
        {
            Upload = false;
            return this;
        }

        public UIConfig RewriteFilesOnUpload()
        {
            Rewrite = true;
            return this;
        }

        public UIConfig DisablePrint()
        {
            Print = false;
            PrintAllowed = false;
            return this;
        }

        public UIConfig DisableFileBrowsing()
        {
            Browse = false;
            return this;
        }

        public UIConfig HideZoomButton()
        {
            Zoom = false;
            return this;
        }

        public UIConfig HideSearchControl()
        {
            Search = false;
            return this;
        }

        public UIConfig HidePageRotationControl()
        {
            Rotate = false;
            return this;
        }

        public UIConfig DisableRightClick()
        {
            EnableRightClick = false;
            return this;
        }

        public UIConfig HideLanguageMenu()
        {
            ShowLanguageMenu = false;
            return this;
        }

        /// <summary>
        /// Sets default language out of supported:
        /// <see cref="Language.Arabic"/>,
        /// <see cref="Language.Catalan"/>,
        /// <see cref="Language.Czech"/>,
        /// <see cref="Language.Danish"/>,
        /// <see cref="Language.German"/>,
        /// <see cref="Language.Greek"/>,
        /// <see cref="Language.English"/>,
        /// <see cref="Language.Spanish"/>,
        /// <see cref="Language.Filipino"/>,
        /// <see cref="Language.French"/>,
        /// <see cref="Language.Hebrew"/>,
        /// <see cref="Language.Hindi"/>,
        /// <see cref="Language.Indonesian"/>,
        /// <see cref="Language.Italian"/>,
        /// <see cref="Language.Japanese"/>,
        /// <see cref="Language.Kazakh"/>,
        /// <see cref="Language.Korean"/>,
        /// <see cref="Language.Malay"/>,
        /// <see cref="Language.Dutch"/>,
        /// <see cref="Language.Polish"/>,
        /// <see cref="Language.Portuguese"/>,
        /// <see cref="Language.Romanian"/>,
        /// <see cref="Language.Russian"/>,
        /// <see cref="Language.Swedish"/>,
        /// <see cref="Language.Vietnamese"/>,
        /// <see cref="Language.Thai"/>,
        /// <see cref="Language.Turkish"/>,
        /// <see cref="Language.Ukrainian"/>,
        /// <see cref="Language.ChineseSimplified"/>,
        /// <see cref="Language.ChineseTraditional"/>
        /// </summary>
        /// <param name="language">Default language e.g. <see cref="Language.English"/>.</param>
        /// <returns>This UIConfig instance.</returns>
        public UIConfig SetDefaultLanguage(Language language)
        {
            DefaultLanguage = language.Code;
            return this;
        }

        /// <summary>
        /// Set supported UI languages. The following languages are supported:
        /// <see cref="Language.Arabic"/>,
        /// <see cref="Language.Catalan"/>,
        /// <see cref="Language.Czech"/>,
        /// <see cref="Language.Danish"/>,
        /// <see cref="Language.German"/>,
        /// <see cref="Language.Greek"/>,
        /// <see cref="Language.English"/>,
        /// <see cref="Language.Spanish"/>,
        /// <see cref="Language.Filipino"/>,
        /// <see cref="Language.French"/>,
        /// <see cref="Language.Hebrew"/>,
        /// <see cref="Language.Hindi"/>,
        /// <see cref="Language.Indonesian"/>,
        /// <see cref="Language.Italian"/>,
        /// <see cref="Language.Japanese"/>,
        /// <see cref="Language.Kazakh"/>,
        /// <see cref="Language.Korean"/>,
        /// <see cref="Language.Malay"/>,
        /// <see cref="Language.Dutch"/>,
        /// <see cref="Language.Polish"/>,
        /// <see cref="Language.Portuguese"/>,
        /// <see cref="Language.Romanian"/>,
        /// <see cref="Language.Russian"/>,
        /// <see cref="Language.Swedish"/>,
        /// <see cref="Language.Vietnamese"/>,
        /// <see cref="Language.Thai"/>,
        /// <see cref="Language.Turkish"/>,
        /// <see cref="Language.Ukrainian"/>,
        /// <see cref="Language.ChineseSimplified"/>,
        /// <see cref="Language.ChineseTraditional"/>
        /// </summary>
        /// <param name="languages">Supported languages.</param>
        /// <returns>This UIConfig instance.</returns>
        public UIConfig SetSupportedLanguages(params Language[] languages)
        {
            SupportedLanguages = languages.Select(l => l.Code).ToArray();
            return this;
        }
    }
}
