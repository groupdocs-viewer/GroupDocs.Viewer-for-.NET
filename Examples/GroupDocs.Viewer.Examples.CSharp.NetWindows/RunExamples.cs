// GroupDocs.Viewer for .NET examples -- NetWindows runner (net10.0-windows7.0).
// Generated. Regenerate rather than editing: every runner must dispatch
// identically, and drift between the copies is a conformance failure.

using System;
using System.IO;
using System.Threading.Tasks;
using GroupDocs.Viewer;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.CachingResults.ImplementThreadSafeCacheForGroupdocsViewer;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.CachingResults._index;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.GettingUsedFonts;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadPasswordProtectedDocument;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingDocumentsFromDifferentSources.LoadDocumentFromLocalDisk;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingDocumentsFromDifferentSources.LoadingDocumentsFromStream.LoadDocumentFromUrl;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingDocumentsFromDifferentSources.LoadingDocumentsFromStream._index;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.LoadingExternalResources;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.SpecifyEncodingWhenLoadingDocuments;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.LoadingDocuments.SpecifyFileTypeWhenLoadingADocument;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.Logging;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.ProcessingAttachments.HowToConvertAndViewAttachments;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.ProcessingAttachments.HowToExtractAndSaveAttachments;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.ProcessingAttachments.HowToListAttachments;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.AddTextWatermark;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.CancelRendering;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.FlipOrRotatePages;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.ExcludeFonts;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.MinifyHtml;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.OptimizeHtmlForPrinting;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.RenderWithResponsiveLayout;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.SetImageSizeLimitsWhenRenderingToHtml;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml._index;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.AdjustJpegImagesQuality;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizationPdfForWeb;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizationPdfResources;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizationPdfSpreadsheets;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeContent.OptimizationPdfRemoveAnnotations;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeContent.OptimizationPdfRemoveFields;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeFonts.OptimizationPdfSubsetFonts;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeImages.OptimizationPdfConvertGrayscale;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeImages.OptimizationPdfReduceImageQuality;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeImages.OptimizationPdfSetMaxResolution;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.PdfRemoveUnusedResources;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.ProtectPdfDocument;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.ReorderPages;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.SetImageSizeLimitsWhenRenderingToPdf;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf._index;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg.ImageViewerAdjustImageSize;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg.ImageViewerAdjustQualityForJpg;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg.ImageViewerGetTextCoordinates;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg.SetImageSizeLimitsWhenRenderingToPngJpg;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg._index;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.ReplaceMissingFont;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.SaveOutputToStream;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.SetCustomFonts;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.ShowHiddenPages;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.ViewSpecificPages;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments._index;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.GetPdfOutputFileInfo;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToCheckIfFileIsEncrypted;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToDetermineFileType;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToGetFileTypeAndPagesCount;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToGetPageWidthAndHeight;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RetrievingDocumentInformation.HowToListAndPrintAllSupportedFileTypes;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.SearchHighlightText;
using GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.Troubleshooting.HowToMigrateToGroupdocsViewer198OrHigher;
using GroupDocs.Viewer.Examples.CSharp.GettingStarted.LicensingAndSubscription;
using GroupDocs.Viewer.Examples.CSharp.ProductOverview;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives._index;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.RenderCadDocuments;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.SpecifyRenderingOptions;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEbooks;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEmailMessages;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderImages;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderLotusNotesFiles;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderMsProjectFiles;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderOutlookDataFiles;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPresentations;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.RenderExcelAndAppleNumbersSpreadsheets;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SpecifyRenderingOptions;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SplitWorksheetIntoPages;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderTextFiles;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderVisioDocuments;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWebDocuments;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;
using GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderXmlDocuments;
using GroupDocs.Viewer.Examples.CSharp._index;

// Set working directory to the output folder where sample files are copied
Directory.SetCurrentDirectory(AppContext.BaseDirectory);

// =================================================================
//  GroupDocs.Viewer for .NET Examples
// =================================================================

var examples = new (string Name, string Dir, Action Run)[]
{
    ("ApplyLicenseFromFile", "GettingStarted/LicensingAndSubscription", ApplyLicenseFromFile.Run),
    ("ApplyLicenseFromStream", "GettingStarted/LicensingAndSubscription", ApplyLicenseFromStream.Run),
    ("ApplyMeteredLicense", "GettingStarted/LicensingAndSubscription", ApplyMeteredLicense.Run),
    ("ApplyLicenseFromEmbeddedResource", "GettingStarted/LicensingAndSubscription", ApplyLicenseFromEmbeddedResource.Run),
    ("RenderExcelToHtml", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderExcelToHtml.Run),
    ("RenderNumbersToHtml", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderNumbersToHtml.Run),
    ("RenderExcelToHtmlExternal", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderExcelToHtmlExternal.Run),
    ("RenderNumbersToHtmlExternal", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderNumbersToHtmlExternal.Run),
    ("RenderExcelToSingleHtml", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderExcelToSingleHtml.Run),
    ("RenderExcelToPdf", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderExcelToPdf.Run),
    ("RenderNumbersToPdf", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderNumbersToPdf.Run),
    ("RenderExcelToPng", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderExcelToPng.Run),
    ("RenderNumbersToPng", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderNumbersToPng.Run),
    ("RenderExcelToJpg", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderExcelToJpg.Run),
    ("RenderNumbersToJpg", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderNumbersToJpg.Run),
    ("RenderCsvWithSeparatorDetection", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", RenderCsvWithSeparatorDetection.Run),
    ("GetWorksheetNames", "RenderingBasics/RenderSpreadsheets/RenderExcelAndAppleNumbersSpreadsheets", GetWorksheetNames.Run),
    ("RenderWordToHtml", "RenderingBasics/RenderWordDocuments", RenderWordToHtml.Run),
    ("RenderWordToHtmlExternal", "RenderingBasics/RenderWordDocuments", RenderWordToHtmlExternal.Run),
    ("RenderWordToPdf", "RenderingBasics/RenderWordDocuments", RenderWordToPdf.Run),
    ("RenderWordToPng", "RenderingBasics/RenderWordDocuments", RenderWordToPng.Run),
    ("RenderWordToJpg", "RenderingBasics/RenderWordDocuments", RenderWordToJpg.Run),
    ("RenderWordWithMargins", "RenderingBasics/RenderWordDocuments", RenderWordWithMargins.Run),
    ("RenderWordWithTrackedChanges", "RenderingBasics/RenderWordDocuments", RenderWordWithTrackedChanges.Run),
    ("RenderWordWithComments", "RenderingBasics/RenderWordDocuments", RenderWordWithComments.Run),
    ("RenderWordUnlinkToc", "RenderingBasics/RenderWordDocuments", RenderWordUnlinkToc.Run),
    ("RenderWordWithoutUpdatingFields", "RenderingBasics/RenderWordDocuments", RenderWordWithoutUpdatingFields.Run),
    ("RenderWordHtmlWithoutJavascript", "RenderingBasics/RenderWordDocuments", RenderWordHtmlWithoutJavascript.Run),
    ("RenderWordWithDpi", "RenderingBasics/RenderWordDocuments", RenderWordWithDpi.Run),
    ("RenderWordWithPageNumbers", "RenderingBasics/RenderWordDocuments", RenderWordWithPageNumbers.Run),
    ("RenderPdfToHtml", "RenderingBasics/RenderPdfDocuments", RenderPdfToHtml.Run),
    ("RenderPdfToHtmlExternal", "RenderingBasics/RenderPdfDocuments", RenderPdfToHtmlExternal.Run),
    ("RenderPdfFluidLayout", "RenderingBasics/RenderPdfDocuments", RenderPdfFluidLayout.Run),
    ("RenderPdfWithImageQuality", "RenderingBasics/RenderPdfDocuments", RenderPdfWithImageQuality.Run),
    ("RenderPdfTextAsImage", "RenderingBasics/RenderPdfDocuments", RenderPdfTextAsImage.Run),
    ("RenderPdfWithLayeredRendering", "RenderingBasics/RenderPdfDocuments", RenderPdfWithLayeredRendering.Run),
    ("RenderPdfToPng", "RenderingBasics/RenderPdfDocuments", RenderPdfToPng.Run),
    ("RenderPdfToJpg", "RenderingBasics/RenderPdfDocuments", RenderPdfToJpg.Run),
    ("RenderPdfPreservePageSize", "RenderingBasics/RenderPdfDocuments", RenderPdfPreservePageSize.Run),
    ("RenderPdfWithFontHinting", "RenderingBasics/RenderPdfDocuments", RenderPdfWithFontHinting.Run),
    ("RenderPdfDisableCharGrouping", "RenderingBasics/RenderPdfDocuments", RenderPdfDisableCharGrouping.Run),
    ("RenderPdfWithComments", "RenderingBasics/RenderPdfDocuments", RenderPdfWithComments.Run),
    ("GetPdfInformation", "RenderingBasics/RenderPdfDocuments", GetPdfInformation.Run),
    ("ExtractPdfText", "RenderingBasics/RenderPdfDocuments", ExtractPdfText.Run),
    ("RenderXpsSkipFontLicenseCheck", "RenderingBasics/RenderPdfDocuments", RenderXpsSkipFontLicenseCheck.Run),
    ("RenderPdfImagesInSvg", "RenderingBasics/RenderPdfDocuments", RenderPdfImagesInSvg.Run),
    ("RenderPdfDisableCopyProtection", "RenderingBasics/RenderPdfDocuments", RenderPdfDisableCopyProtection.Run),
    ("RepairCorruptedPdf", "RenderingBasics/RenderPdfDocuments", RepairCorruptedPdf.Run),
    ("RenderOfdDocument", "RenderingBasics/RenderPdfDocuments", RenderOfdDocument.Run),
    ("RenderPdfPopupAnnotations", "RenderingBasics/RenderPdfDocuments", RenderPdfPopupAnnotations.Run),
    ("RenderWorksheetOnOnePage", "RenderingBasics/RenderSpreadsheets/SplitWorksheetIntoPages", RenderWorksheetOnOnePage.Run),
    ("SplitWorksheetByPageBreaks", "RenderingBasics/RenderSpreadsheets/SplitWorksheetIntoPages", SplitWorksheetByPageBreaks.Run),
    ("RenderOnlyPrintArea", "RenderingBasics/RenderSpreadsheets/SplitWorksheetIntoPages", RenderOnlyPrintArea.Run),
    ("RenderPrintAreaByPageBreaks", "RenderingBasics/RenderSpreadsheets/SplitWorksheetIntoPages", RenderPrintAreaByPageBreaks.Run),
    ("SplitWorksheetByRows", "RenderingBasics/RenderSpreadsheets/SplitWorksheetIntoPages", SplitWorksheetByRows.Run),
    ("SplitWorksheetByRowsAndColumns", "RenderingBasics/RenderSpreadsheets/SplitWorksheetIntoPages", SplitWorksheetByRowsAndColumns.Run),
    ("RenderHeadings", "RenderingBasics/RenderSpreadsheets/SpecifyRenderingOptions", RenderHeadings.Run),
    ("RenderGridLines", "RenderingBasics/RenderSpreadsheets/SpecifyRenderingOptions", RenderGridLines.Run),
    ("SetTextOverflowMode", "RenderingBasics/RenderSpreadsheets/SpecifyRenderingOptions", SetTextOverflowMode.Run),
    ("RenderHiddenRowsAndColumns", "RenderingBasics/RenderSpreadsheets/SpecifyRenderingOptions", RenderHiddenRowsAndColumns.Run),
    ("RenderHiddenPages", "RenderingBasics/RenderSpreadsheets/SpecifyRenderingOptions", RenderHiddenPages.Run),
    ("SkipEmptyRowsAndColumns", "RenderingBasics/RenderSpreadsheets/SpecifyRenderingOptions", SkipEmptyRowsAndColumns.Run),
    ("RenderComments", "RenderingBasics/RenderSpreadsheets/SpecifyRenderingOptions", RenderComments.Run),
    ("SetWorksheetMargins", "RenderingBasics/RenderSpreadsheets/SpecifyRenderingOptions", SetWorksheetMargins.Run),
    ("RenderPresentationToHtml", "RenderingBasics/RenderPresentations", RenderPresentationToHtml.Run),
    ("RenderPresentationToHtmlExternal", "RenderingBasics/RenderPresentations", RenderPresentationToHtmlExternal.Run),
    ("RenderPresentationPureHtml", "RenderingBasics/RenderPresentations", RenderPresentationPureHtml.Run),
    ("RenderPresentationToPdf", "RenderingBasics/RenderPresentations", RenderPresentationToPdf.Run),
    ("RenderPresentationToPng", "RenderingBasics/RenderPresentations", RenderPresentationToPng.Run),
    ("RenderPresentationToJpg", "RenderingBasics/RenderPresentations", RenderPresentationToJpg.Run),
    ("RenderPresentationWithResolution", "RenderingBasics/RenderPresentations", RenderPresentationWithResolution.Run),
    ("RenderPresentationWithHiddenSlides", "RenderingBasics/RenderPresentations", RenderPresentationWithHiddenSlides.Run),
    ("RenderPresentationWithComments", "RenderingBasics/RenderPresentations", RenderPresentationWithComments.Run),
    ("RenderPresentationWithNotes", "RenderingBasics/RenderPresentations", RenderPresentationWithNotes.Run),
    ("RenderVisioToHtml", "RenderingBasics/RenderVisioDocuments", RenderVisioToHtml.Run),
    ("RenderVisioToHtmlExternal", "RenderingBasics/RenderVisioDocuments", RenderVisioToHtmlExternal.Run),
    ("RenderVisioToPdf", "RenderingBasics/RenderVisioDocuments", RenderVisioToPdf.Run),
    ("RenderVisioToPng", "RenderingBasics/RenderVisioDocuments", RenderVisioToPng.Run),
    ("RenderVisioToJpg", "RenderingBasics/RenderVisioDocuments", RenderVisioToJpg.Run),
    ("RenderVisioShapesOnly", "RenderingBasics/RenderVisioDocuments", RenderVisioShapesOnly.Run),
    ("RenderProjectToHtml", "RenderingBasics/RenderMsProjectFiles", RenderProjectToHtml.Run),
    ("RenderProjectToHtmlExternal", "RenderingBasics/RenderMsProjectFiles", RenderProjectToHtmlExternal.Run),
    ("RenderProjectToPdf", "RenderingBasics/RenderMsProjectFiles", RenderProjectToPdf.Run),
    ("RenderProjectToPng", "RenderingBasics/RenderMsProjectFiles", RenderProjectToPng.Run),
    ("RenderProjectToJpg", "RenderingBasics/RenderMsProjectFiles", RenderProjectToJpg.Run),
    ("GetProjectInfo", "RenderingBasics/RenderMsProjectFiles", GetProjectInfo.Run),
    ("RenderProjectWithPageSize", "RenderingBasics/RenderMsProjectFiles", RenderProjectWithPageSize.Run),
    ("RenderProjectWithTimeUnit", "RenderingBasics/RenderMsProjectFiles", RenderProjectWithTimeUnit.Run),
    ("RenderProjectSpecificDates", "RenderingBasics/RenderMsProjectFiles", RenderProjectSpecificDates.Run),
    ("RenderProjectWithNotes", "RenderingBasics/RenderMsProjectFiles", RenderProjectWithNotes.Run),
    ("RenderEbookToHtml", "RenderingBasics/RenderEbooks", RenderEbookToHtml.Run),
    ("RenderEbookToHtmlExternal", "RenderingBasics/RenderEbooks", RenderEbookToHtmlExternal.Run),
    ("RenderEbookToPdf", "RenderingBasics/RenderEbooks", RenderEbookToPdf.Run),
    ("RenderEbookToPng", "RenderingBasics/RenderEbooks", RenderEbookToPng.Run),
    ("RenderEbookToJpg", "RenderingBasics/RenderEbooks", RenderEbookToJpg.Run),
    ("RenderWebToPdf", "RenderingBasics/RenderWebDocuments", RenderWebToPdf.Run),
    ("RenderWebToPng", "RenderingBasics/RenderWebDocuments", RenderWebToPng.Run),
    ("RenderWebToJpg", "RenderingBasics/RenderWebDocuments", RenderWebToJpg.Run),
    ("RenderChmToHtml", "RenderingBasics/RenderWebDocuments", RenderChmToHtml.Run),
    ("RenderChmToHtmlExternal", "RenderingBasics/RenderWebDocuments", RenderChmToHtmlExternal.Run),
    ("RenderWebWithMargins", "RenderingBasics/RenderWebDocuments", RenderWebWithMargins.Run),
    ("RenderWebWithPageSize", "RenderingBasics/RenderWebDocuments", RenderWebWithPageSize.Run),
    ("LoadXmlDocument", "RenderingBasics/RenderXmlDocuments", LoadXmlDocument.Run),
    ("RenderXmlToHtml", "RenderingBasics/RenderXmlDocuments", RenderXmlToHtml.Run),
    ("RenderXmlToPdf", "RenderingBasics/RenderXmlDocuments", RenderXmlToPdf.Run),
    ("RenderXmlToImages", "RenderingBasics/RenderXmlDocuments", RenderXmlToImages.Run),
    ("GetXmlViewInfo", "RenderingBasics/RenderXmlDocuments", GetXmlViewInfo.Run),
    ("RenderTextWithLoadOptions", "RenderingBasics/RenderTextFiles", RenderTextWithLoadOptions.Run),
    ("RenderTextToHtml", "RenderingBasics/RenderTextFiles", RenderTextToHtml.Run),
    ("RenderTextToHtmlExternal", "RenderingBasics/RenderTextFiles", RenderTextToHtmlExternal.Run),
    ("RenderTextToSingleHtml", "RenderingBasics/RenderTextFiles", RenderTextToSingleHtml.Run),
    ("RenderTextToPdf", "RenderingBasics/RenderTextFiles", RenderTextToPdf.Run),
    ("RenderTextToPng", "RenderingBasics/RenderTextFiles", RenderTextToPng.Run),
    ("RenderTextToJpg", "RenderingBasics/RenderTextFiles", RenderTextToJpg.Run),
    ("RenderTextWithOptions", "RenderingBasics/RenderTextFiles", RenderTextWithOptions.Run),
    ("RenderImageToHtml", "RenderingBasics/RenderImages", RenderImageToHtml.Run),
    ("RenderImageToHtmlExternal", "RenderingBasics/RenderImages", RenderImageToHtmlExternal.Run),
    ("RenderImageToPdf", "RenderingBasics/RenderImages", RenderImageToPdf.Run),
    ("RenderImageToPng", "RenderingBasics/RenderImages", RenderImageToPng.Run),
    ("RenderImageToJpg", "RenderingBasics/RenderImages", RenderImageToJpg.Run),
    ("RenderPsdWithCustomFonts", "RenderingBasics/RenderImages", RenderPsdWithCustomFonts.Run),
    ("RenderEmailToHtml", "RenderingBasics/RenderEmailMessages", RenderEmailToHtml.Run),
    ("RenderEmailToHtmlExternal", "RenderingBasics/RenderEmailMessages", RenderEmailToHtmlExternal.Run),
    ("RenderEmailToPdf", "RenderingBasics/RenderEmailMessages", RenderEmailToPdf.Run),
    ("RenderEmailToPng", "RenderingBasics/RenderEmailMessages", RenderEmailToPng.Run),
    ("RenderEmailToJpg", "RenderingBasics/RenderEmailMessages", RenderEmailToJpg.Run),
    ("RenderEmailWithPageSize", "RenderingBasics/RenderEmailMessages", RenderEmailWithPageSize.Run),
    ("RenderEmailWithRenamedFields", "RenderingBasics/RenderEmailMessages", RenderEmailWithRenamedFields.Run),
    ("RenderEmailWithDatetimeFormat", "RenderingBasics/RenderEmailMessages", RenderEmailWithDatetimeFormat.Run),
    ("GetEmailInfo", "RenderingBasics/RenderEmailMessages", GetEmailInfo.Run),
    ("RenderOutlookToHtml", "RenderingBasics/RenderOutlookDataFiles", RenderOutlookToHtml.Run),
    ("RenderOutlookToPdf", "RenderingBasics/RenderOutlookDataFiles", RenderOutlookToPdf.Run),
    ("RenderOutlookToPng", "RenderingBasics/RenderOutlookDataFiles", RenderOutlookToPng.Run),
    ("RenderOutlookToJpg", "RenderingBasics/RenderOutlookDataFiles", RenderOutlookToJpg.Run),
    ("GetOutlookFoldersInfo", "RenderingBasics/RenderOutlookDataFiles", GetOutlookFoldersInfo.Run),
    ("RenderOutlookSpecificFolder", "RenderingBasics/RenderOutlookDataFiles", RenderOutlookSpecificFolder.Run),
    ("RenderOutlookWithMaxItems", "RenderingBasics/RenderOutlookDataFiles", RenderOutlookWithMaxItems.Run),
    ("RenderOutlookWithFilters", "RenderingBasics/RenderOutlookDataFiles", RenderOutlookWithFilters.Run),
    ("RenderNsfToHtml", "RenderingBasics/RenderLotusNotesFiles", RenderNsfToHtml.Run),
    ("RenderNsfToPdf", "RenderingBasics/RenderLotusNotesFiles", RenderNsfToPdf.Run),
    ("RenderNsfToPng", "RenderingBasics/RenderLotusNotesFiles", RenderNsfToPng.Run),
    ("RenderNsfToJpg", "RenderingBasics/RenderLotusNotesFiles", RenderNsfToJpg.Run),
    ("RenderNsfWithMaxItems", "RenderingBasics/RenderLotusNotesFiles", RenderNsfWithMaxItems.Run),
    ("RenderNsfWithFilters", "RenderingBasics/RenderLotusNotesFiles", RenderNsfWithFilters.Run),
    ("RenderCadToHtml", "RenderingBasics/RenderCadDocuments/RenderCadDocuments", RenderCadToHtml.Run),
    ("RenderCadToHtmlExternal", "RenderingBasics/RenderCadDocuments/RenderCadDocuments", RenderCadToHtmlExternal.Run),
    ("RenderCadToPdf", "RenderingBasics/RenderCadDocuments/RenderCadDocuments", RenderCadToPdf.Run),
    ("RenderCadToPng", "RenderingBasics/RenderCadDocuments/RenderCadDocuments", RenderCadToPng.Run),
    ("RenderCadToJpg", "RenderingBasics/RenderCadDocuments/RenderCadDocuments", RenderCadToJpg.Run),
    ("GetCadInfo", "RenderingBasics/RenderCadDocuments/RenderCadDocuments", GetCadInfo.Run),
    ("RenderAllLayouts", "RenderingBasics/RenderCadDocuments/RenderCadDocuments", RenderAllLayouts.Run),
    ("RenderSpecificLayout", "RenderingBasics/RenderCadDocuments/RenderCadDocuments", RenderSpecificLayout.Run),
    ("RenderSpecificLayers", "RenderingBasics/RenderCadDocuments/RenderCadDocuments", RenderSpecificLayers.Run),
    ("SetBackgroundColor", "RenderingBasics/RenderCadDocuments/SpecifyRenderingOptions", SetBackgroundColor.Run),
    ("SetImageSize", "RenderingBasics/RenderCadDocuments/SpecifyRenderingOptions", SetImageSize.Run),
    ("ApplyPc3File", "RenderingBasics/RenderCadDocuments/SpecifyRenderingOptions", ApplyPc3File.Run),
    ("SplitDrawingIntoTiles", "RenderingBasics/RenderCadDocuments/SpecifyRenderingOptions", SplitDrawingIntoTiles.Run),
    ("EnablePerformanceMode", "RenderingBasics/RenderCadDocuments/SpecifyRenderingOptions", EnablePerformanceMode.Run),
    ("LoadArchive", "RenderingBasics/RenderArchives/_index", LoadArchive.Run),
    ("RenderArchiveToHtml", "RenderingBasics/RenderArchives/_index", RenderArchiveToHtml.Run),
    ("RenderArchiveToPdf", "RenderingBasics/RenderArchives/_index", RenderArchiveToPdf.Run),
    ("RenderArchiveToImages", "RenderingBasics/RenderArchives/_index", RenderArchiveToImages.Run),
    ("RenderArchiveWithOptions", "RenderingBasics/RenderArchives/_index", RenderArchiveWithOptions.Run),
    ("ExtractFilesFromArchive", "RenderingBasics/RenderArchives/_index", ExtractFilesFromArchive.Run),
    ("GetArchiveInfo", "RenderingBasics/RenderArchives/_index", GetArchiveInfo.Run),
    ("LoadDocumentFromLocalDisk", "DeveloperGuide/LoadingDocuments/LoadingDocumentsFromDifferentSources/LoadDocumentFromLocalDisk", LoadDocumentFromLocalDisk.Run),
    ("LoadPasswordProtectedDocument", "DeveloperGuide/LoadingDocuments/LoadPasswordProtectedDocument", LoadPasswordProtectedDocument.Run),
    ("SpecifyFileTypeWhenLoading", "DeveloperGuide/LoadingDocuments/SpecifyFileTypeWhenLoadingADocument", SpecifyFileTypeWhenLoading.Run),
    ("SpecifyEncodingWhenLoading", "DeveloperGuide/LoadingDocuments/SpecifyEncodingWhenLoadingDocuments", SpecifyEncodingWhenLoading.Run),
    ("SkipLoadingExternalResources", "DeveloperGuide/LoadingDocuments/LoadingExternalResources", SkipLoadingExternalResources.Run),
    ("LoadExternalResourcesFromSafelist", "DeveloperGuide/LoadingDocuments/LoadingExternalResources", LoadExternalResourcesFromSafelist.Run),
    ("SetExternalResourcesTimeout", "DeveloperGuide/LoadingDocuments/LoadingExternalResources", SetExternalResourcesTimeout.Run),
    ("GetFileTypeFromExtension", "DeveloperGuide/RetrievingDocumentInformation/HowToDetermineFileType", GetFileTypeFromExtension.Run),
    ("GetFileTypeFromMediaType", "DeveloperGuide/RetrievingDocumentInformation/HowToDetermineFileType", GetFileTypeFromMediaType.Run),
    ("GetFileTypeFromStream", "DeveloperGuide/RetrievingDocumentInformation/HowToDetermineFileType", GetFileTypeFromStream.Run),
    ("LoadDocumentFromStream", "DeveloperGuide/LoadingDocuments/LoadingDocumentsFromDifferentSources/LoadingDocumentsFromStream/_index", LoadDocumentFromStream.Run),
    ("GetFileTypeAndPagesCount", "DeveloperGuide/RetrievingDocumentInformation/HowToGetFileTypeAndPagesCount", GetFileTypeAndPagesCount.Run),
    ("GetFileTypeAndPagesCountFromStream", "DeveloperGuide/RetrievingDocumentInformation/HowToGetFileTypeAndPagesCount", GetFileTypeAndPagesCountFromStream.Run),
    ("LoadDocumentFromUrl", "DeveloperGuide/LoadingDocuments/LoadingDocumentsFromDifferentSources/LoadingDocumentsFromStream/LoadDocumentFromUrl", LoadDocumentFromUrl.Run),
    ("CheckIfFileIsEncrypted", "DeveloperGuide/RetrievingDocumentInformation/HowToCheckIfFileIsEncrypted", CheckIfFileIsEncrypted.Run),
    ("ListSupportedFileTypes", "DeveloperGuide/RetrievingDocumentInformation/HowToListAndPrintAllSupportedFileTypes", ListSupportedFileTypes.Run),
    ("GetPageWidthAndHeight", "DeveloperGuide/RetrievingDocumentInformation/HowToGetPageWidthAndHeight", GetPageWidthAndHeight.Run),
    ("GetPdfOutputInfo", "DeveloperGuide/RetrievingDocumentInformation/GetPdfOutputFileInfo", GetPdfOutputInfo.Run),
    ("ViewSpecificPages", "DeveloperGuide/RenderingDocuments/ViewSpecificPages", ViewSpecificPages.Run),
    ("ViewPagesFromArray", "DeveloperGuide/RenderingDocuments/ViewSpecificPages", ViewPagesFromArray.Run),
    ("RenderDocumentToPng", "DeveloperGuide/RenderingDocuments/_index", RenderDocumentToPng.Run),
    ("RenderSpecificPages", "DeveloperGuide/RenderingDocuments/_index", RenderSpecificPages.Run),
    ("CancelRendering", "DeveloperGuide/RenderingDocuments/CancelRendering", CancelRendering.Run),
    ("ShowHiddenPages", "DeveloperGuide/RenderingDocuments/ShowHiddenPages", ShowHiddenPages.Run),
    ("FlipOrRotatePages", "DeveloperGuide/RenderingDocuments/FlipOrRotatePages", FlipOrRotatePages.Run),
    ("SetCustomFonts", "DeveloperGuide/RenderingDocuments/SetCustomFonts", SetCustomFonts.Run),
    ("ReplaceMissingFont", "DeveloperGuide/RenderingDocuments/ReplaceMissingFont", ReplaceMissingFont.Run),
    ("SaveOutputToStream", "DeveloperGuide/RenderingDocuments/SaveOutputToStream", SaveOutputToStream.Run),
    ("AddTextWatermark", "DeveloperGuide/RenderingDocuments/AddTextWatermark", AddTextWatermark.Run),
    ("ListAttachments", "DeveloperGuide/ProcessingAttachments/HowToListAttachments", ListAttachments.Run),
    ("ReduceImageQuality", "DeveloperGuide/RenderingDocuments/RenderingToPdf/OptimizationPdfOptions/OptimizeImages/OptimizationPdfReduceImageQuality", ReduceImageQuality.Run),
    ("ExtractAndSaveAttachments", "DeveloperGuide/ProcessingAttachments/HowToExtractAndSaveAttachments", ExtractAndSaveAttachments.Run),
    ("SetMaxResolution", "DeveloperGuide/RenderingDocuments/RenderingToPdf/OptimizationPdfOptions/OptimizeImages/OptimizationPdfSetMaxResolution", SetMaxResolution.Run),
    ("ConvertAndViewAttachments", "DeveloperGuide/ProcessingAttachments/HowToConvertAndViewAttachments", ConvertAndViewAttachments.Run),
    ("ConvertToGrayscale", "DeveloperGuide/RenderingDocuments/RenderingToPdf/OptimizationPdfOptions/OptimizeImages/OptimizationPdfConvertGrayscale", ConvertToGrayscale.Run),
    ("WriteLogsToFile", "DeveloperGuide/Logging", WriteLogsToFile.Run),
    ("WriteLogsToConsole", "DeveloperGuide/Logging", WriteLogsToConsole.Run),
    ("WriteLogsWithCustomLogger", "DeveloperGuide/Logging", WriteLogsWithCustomLogger.Run),
    ("GetUsedFonts", "DeveloperGuide/GettingUsedFonts", GetUsedFonts.Run),
    ("HighlightWordInWordDocument", "DeveloperGuide/SearchHighlightText", HighlightWordInWordDocument.Run),
    ("HighlightRegexMatchesInPdf", "DeveloperGuide/SearchHighlightText", HighlightRegexMatchesInPdf.Run),
    ("RemoveAnnotations", "DeveloperGuide/RenderingDocuments/RenderingToPdf/OptimizationPdfOptions/OptimizeContent/OptimizationPdfRemoveAnnotations", RemoveAnnotations.Run),
    ("ThreadSafeCacheClass", "DeveloperGuide/CachingResults/ImplementThreadSafeCacheForGroupdocsViewer", ThreadSafeCacheClass.Run),
    ("ThreadSafeCacheKeyLocker", "DeveloperGuide/CachingResults/ImplementThreadSafeCacheForGroupdocsViewer", ThreadSafeCacheKeyLocker.Run),
    ("RemoveFormFields", "DeveloperGuide/RenderingDocuments/RenderingToPdf/OptimizationPdfOptions/OptimizeContent/OptimizationPdfRemoveFields", RemoveFormFields.Run),
    ("CacheRenderingResults", "DeveloperGuide/CachingResults/_index", CacheRenderingResults.Run),
    ("OptimizePdfForWeb", "DeveloperGuide/RenderingDocuments/RenderingToPdf/OptimizationPdfOptions/OptimizationPdfForWeb", OptimizePdfForWeb.Run),
    ("OptimizePdfResources", "DeveloperGuide/RenderingDocuments/RenderingToPdf/OptimizationPdfOptions/OptimizationPdfResources", OptimizePdfResources.Run),
    ("SubsetFonts", "DeveloperGuide/RenderingDocuments/RenderingToPdf/OptimizationPdfOptions/OptimizeFonts/OptimizationPdfSubsetFonts", SubsetFonts.Run),
    ("OptimizeSpreadsheets", "DeveloperGuide/RenderingDocuments/RenderingToPdf/OptimizationPdfOptions/OptimizationPdfSpreadsheets", OptimizeSpreadsheets.Run),
    ("RemoveUnusedResources", "DeveloperGuide/RenderingDocuments/RenderingToPdf/OptimizationPdfOptions/PdfRemoveUnusedResources", RemoveUnusedResources.Run),
    ("MigrateNewApi", "DeveloperGuide/Troubleshooting/HowToMigrateToGroupdocsViewer198OrHigher", MigrateNewApi.Run),
    ("RenderResponsiveHtml", "DeveloperGuide/RenderingDocuments/RenderingToHtml/RenderWithResponsiveLayout", RenderResponsiveHtml.Run),
    ("OptimizeHtmlForPrinting", "DeveloperGuide/RenderingDocuments/RenderingToHtml/OptimizeHtmlForPrinting", OptimizeHtmlForPrinting.Run),
    ("ExcludeAllFonts", "DeveloperGuide/RenderingDocuments/RenderingToHtml/ExcludeFonts", ExcludeAllFonts.Run),
    ("ExcludeSpecificFonts", "DeveloperGuide/RenderingDocuments/RenderingToHtml/ExcludeFonts", ExcludeSpecificFonts.Run),
    ("MinifyHtml", "DeveloperGuide/RenderingDocuments/RenderingToHtml/MinifyHtml", MinifyHtml.Run),
    ("LimitImageSizeInHtml", "DeveloperGuide/RenderingDocuments/RenderingToHtml/SetImageSizeLimitsWhenRenderingToHtml", LimitImageSizeInHtml.Run),
    ("RenderToHtmlExternal", "DeveloperGuide/RenderingDocuments/RenderingToHtml/_index", RenderToHtmlExternal.Run),
    ("RenderToHtmlEmbedded", "DeveloperGuide/RenderingDocuments/RenderingToHtml/_index", RenderToHtmlEmbedded.Run),
    ("RenderHtmlWithAndWithoutJavascript", "DeveloperGuide/RenderingDocuments/RenderingToHtml/_index", RenderHtmlWithAndWithoutJavascript.Run),
    ("AdjustImageSize", "DeveloperGuide/RenderingDocuments/RenderingToPngOrJpeg/ImageViewerAdjustImageSize", AdjustImageSize.Run),
    ("AdjustJpgQuality", "DeveloperGuide/RenderingDocuments/RenderingToPngOrJpeg/ImageViewerAdjustQualityForJpg", AdjustJpgQuality.Run),
    ("GetTextCoordinates", "DeveloperGuide/RenderingDocuments/RenderingToPngOrJpeg/ImageViewerGetTextCoordinates", GetTextCoordinates.Run),
    ("LimitImageSizeInPngAndJpg", "DeveloperGuide/RenderingDocuments/RenderingToPngOrJpeg/SetImageSizeLimitsWhenRenderingToPngJpg", LimitImageSizeInPngAndJpg.Run),
    ("RenderToPngImages", "DeveloperGuide/RenderingDocuments/RenderingToPngOrJpeg/_index", RenderToPngImages.Run),
    ("RenderToJpegImages", "DeveloperGuide/RenderingDocuments/RenderingToPngOrJpeg/_index", RenderToJpegImages.Run),
    ("ReorderPages", "DeveloperGuide/RenderingDocuments/RenderingToPdf/ReorderPages", ReorderPages.Run),
    ("ProtectPdfDocument", "DeveloperGuide/RenderingDocuments/RenderingToPdf/ProtectPdfDocument", ProtectPdfDocument.Run),
    ("AdjustJpegQuality", "DeveloperGuide/RenderingDocuments/RenderingToPdf/AdjustJpegImagesQuality", AdjustJpegQuality.Run),
    ("SetImageSizeLimits", "DeveloperGuide/RenderingDocuments/RenderingToPdf/SetImageSizeLimitsWhenRenderingToPdf", SetImageSizeLimits.Run),
    ("RenderToPdf", "DeveloperGuide/RenderingDocuments/RenderingToPdf/_index", RenderToPdf.Run),
    ("RenderDocxToHtml", "_index", RenderDocxToHtml.Run),
    ("QuickExampleHtml", "ProductOverview", QuickExampleHtml.Run),
    ("QuickExampleProtectedPdf", "ProductOverview", QuickExampleProtectedPdf.Run)
};

var asyncExamples = new (string Name, string Dir, Func<Task> Run)[]
{

};

// Examples that threw in run-all mode. A non-empty list means a non-zero exit.
var failed = new System.Collections.Generic.List<string>();

// Each example runs in its own directory: sample files keep their structure in
// the output, and one example's artifacts cannot land on top of another's.
void EnterExampleDir(string dir)
{
    string path = string.IsNullOrEmpty(dir)
        ? AppContext.BaseDirectory
        : Path.Combine(AppContext.BaseDirectory, dir);
    Directory.CreateDirectory(path);
    Directory.SetCurrentDirectory(path);
}

// Skipped: LoadXmlWithEncoding (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/RenderingBasics/RenderXmlDocuments/LoadXmlWithEncoding.cs)
// Skipped: LegacyArchiveToHtml (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/RenderingBasics/RenderArchives/OldArchiveRendering/LegacyArchiveToHtml.cs)
// Skipped: LegacyArchiveItemsPerPage (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/RenderingBasics/RenderArchives/OldArchiveRendering/LegacyArchiveItemsPerPage.cs)
// Skipped: LegacyArchiveSingleHtml (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/RenderingBasics/RenderArchives/OldArchiveRendering/LegacyArchiveSingleHtml.cs)
// Skipped: LegacyArchiveToPdf (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/RenderingBasics/RenderArchives/OldArchiveRendering/LegacyArchiveToPdf.cs)
// Skipped: LegacyArchiveToPng (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/RenderingBasics/RenderArchives/OldArchiveRendering/LegacyArchiveToPng.cs)
// Skipped: LegacyArchiveToJpeg (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/RenderingBasics/RenderArchives/OldArchiveRendering/LegacyArchiveToJpeg.cs)
// Skipped: LegacyArchiveFoldersInfo (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/RenderingBasics/RenderArchives/OldArchiveRendering/LegacyArchiveFoldersInfo.cs)
// Skipped: LegacyArchiveSpecificFolder (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/RenderingBasics/RenderArchives/OldArchiveRendering/LegacyArchiveSpecificFolder.cs)
// Skipped: LegacyArchiveFileName (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/RenderingBasics/RenderArchives/OldArchiveRendering/LegacyArchiveFileName.cs)
// Skipped: LoadDocumentFromFtp (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/DeveloperGuide/LoadingDocuments/LoadingDocumentsFromDifferentSources/LoadingDocumentsFromStream/LoadDocumentFromFtp/LoadDocumentFromFtp.cs)
// Skipped: LoadDocumentFromAmazonS3 (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/DeveloperGuide/LoadingDocuments/LoadingDocumentsFromDifferentSources/LoadingDocumentsFromStream/LoadDocumentFromAmazonS3Storage/LoadDocumentFromAmazonS3.cs)
// Skipped: LoadDocumentFromAzureBlob (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/DeveloperGuide/LoadingDocuments/LoadingDocumentsFromDifferentSources/LoadingDocumentsFromStream/LoadDocumentFromAzureBlobStorage/LoadDocumentFromAzureBlob.cs)
// Skipped: UseCustomCache (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/DeveloperGuide/CachingResults/HowToUseCustomCacheImplementation/UseCustomCache.cs)
// Skipped: RenderWithThreadSafeCache (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/DeveloperGuide/CachingResults/ImplementThreadSafeCacheForGroupdocsViewer/RenderWithThreadSafeCache.cs)
// Skipped: MigrateOldApi (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/DeveloperGuide/Troubleshooting/HowToMigrateToGroupdocsViewer198OrHigher/MigrateOldApi.cs)
// Skipped: HtmlImageSizeProperties (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/DeveloperGuide/RenderingDocuments/RenderingToHtml/SetImageSizeLimitsWhenRenderingToHtml/HtmlImageSizeProperties.cs)
// Skipped: ImageSizeProperties (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/DeveloperGuide/RenderingDocuments/RenderingToPngOrJpeg/SetImageSizeLimitsWhenRenderingToPngJpg/ImageSizeProperties.cs)
// Skipped: PdfImageSizeProperties (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/DeveloperGuide/RenderingDocuments/RenderingToPdf/SetImageSizeLimitsWhenRenderingToPdf/PdfImageSizeProperties.cs)
// Skipped: AspnetCoreProgram (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/Showcases/HowToIntegrateGroupdocsViewerInAspNetCoreWebApp/AspnetCoreProgram.cs)
// Skipped: AspnetCoreLicense (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/Showcases/HowToIntegrateGroupdocsViewerInAspNetCoreWebApp/AspnetCoreLicense.cs)
// Skipped: AspnetCoreAuthorization (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/Showcases/HowToIntegrateGroupdocsViewerInAspNetCoreWebApp/AspnetCoreAuthorization.cs)
// Skipped: AspnetCoreUiOptions (non-runnable reference, see GroupDocs.Viewer.Examples.CSharp/Showcases/HowToIntegrateGroupdocsViewerInAspNetCoreWebApp/AspnetCoreUiOptions.cs)

// =================================================================
//  CLI dispatch for generate_outputs.py (build once, run many)
// =================================================================

if (args.Length >= 2 && args[0] == "--example")
{
    string exName = args[1];

    // generate_outputs.py pins the directory so it can diff what the example
    // produced; otherwise fall back to the example's own directory.
    string? workDir = Environment.GetEnvironmentVariable("EXAMPLE_WORK_DIR");

    string? licPath = Environment.GetEnvironmentVariable("GROUPDOCS_LIC_PATH");

    foreach (var (n, d, r) in examples)
    {
        if (string.Equals(n, exName, StringComparison.OrdinalIgnoreCase))
        {
            if (!string.IsNullOrEmpty(workDir)) Directory.SetCurrentDirectory(workDir);
            else EnterExampleDir(d);
            PrepareWorkingDir();
            if (!string.IsNullOrEmpty(licPath) && File.Exists(licPath))
                new License().SetLicense(licPath);
            r();
            return 0;
        }
    }
    foreach (var (n, d, r) in asyncExamples)
    {
        if (string.Equals(n, exName, StringComparison.OrdinalIgnoreCase))
        {
            if (!string.IsNullOrEmpty(workDir)) Directory.SetCurrentDirectory(workDir);
            else EnterExampleDir(d);
            PrepareWorkingDir();
            if (!string.IsNullOrEmpty(licPath) && File.Exists(licPath))
                new License().SetLicense(licPath);
            await r();
            return 0;
        }
    }

    Console.Error.WriteLine($"Unknown example: {exName}");
    return 1;
}

if (args.Length >= 1 && args[0] == "--list")
{
    foreach (var (name, _, _) in examples) Console.WriteLine(name);
    foreach (var (name, _, _) in asyncExamples) Console.WriteLine(name);
    return 0;
}

// =================================================================
//  Default mode: run all examples with interactive output
// =================================================================

PrintIntro();
SetLicense();

foreach (var (name, dir, run) in examples)
{
    EnterExampleDir(dir);
    PrepareWorkingDir();
    if (!RunExample(name, run)) failed.Add(name);
}

foreach (var (name, dir, run) in asyncExamples)
{
    EnterExampleDir(dir);
    PrepareWorkingDir();
    if (!await RunExampleAsync(name, run)) failed.Add(name);
}

Console.WriteLine();
// A failing example has to fail the build, not just print in red.
if (failed.Count > 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine($"{failed.Count} example(s) failed: {string.Join(", ", failed)}");
    Console.ResetColor();
    return 1;
}

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(new string('=', 65));
Console.WriteLine("  All examples completed. Enjoy exploring the GroupDocs API!");
Console.WriteLine(new string('=', 65));
Console.ResetColor();
return 0;

// =================================================================
//  Helper methods
// =================================================================

static void PrepareWorkingDir()
{
    // nothing to prepare
}

static void PrintIntro()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine();
    Console.WriteLine("=================================================================");
    Console.WriteLine("  Welcome to the GroupDocs.Viewer for .NET Examples!");
    Console.WriteLine("=================================================================");
    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine("  This project demonstrates the features of GroupDocs.Viewer for .NET.");
    Console.WriteLine("  Each example demonstrates different use cases such as:");
    Console.WriteLine();
    Console.WriteLine("  - Rendering documents to HTML, PDF and images.");
    Console.WriteLine("  - Reading document information.");
    Console.WriteLine("  - Format-specific rendering options.");
    Console.WriteLine();
}

static void SetLicense()
{
    // Option 1: Set license from environment variable
    string? licensePath = Environment.GetEnvironmentVariable("GROUPDOCS_LIC_PATH");

    // Option 2: Look for .lic file in the current directory
    if (string.IsNullOrEmpty(licensePath))
    {
        foreach (string file in Directory.GetFiles(".", "*.lic"))
        {
            licensePath = file;
            break;
        }
    }

    if (!string.IsNullOrEmpty(licensePath) && File.Exists(licensePath))
    {
        new License().SetLicense(licensePath);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  License set from: {licensePath}");
        Console.ResetColor();
        Console.WriteLine();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  No license file found. Running in evaluation mode.");
        Console.ResetColor();
        Console.WriteLine();
    }
}

// Returns false if the example threw, so run-all can exit non-zero.
static bool RunExample(string name, Action run)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Running {name}...");
    Console.ResetColor();
    try
    {
        run();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  Completed {name}");
        Console.ResetColor();
        Console.WriteLine();
        return true;
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  Error: {ex.Message}");
        Console.ResetColor();
        Console.WriteLine();
        return false;
    }
}

static async Task<bool> RunExampleAsync(string name, Func<Task> run)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Running {name}...");
    Console.ResetColor();
    try
    {
        await run();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  Completed {name}");
        Console.ResetColor();
        Console.WriteLine();
        return true;
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  Error: {ex.Message}");
        Console.ResetColor();
        Console.WriteLine();
        return false;
    }
}
