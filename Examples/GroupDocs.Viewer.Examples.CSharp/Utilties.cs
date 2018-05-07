using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Domain.Image;
using GroupDocs.Viewer.Domain.Options;
using GroupDocs.Viewer.Handler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupDocs.Viewer.Examples
{
    public static class Utilities
    {
        public const string StoragePath = "../../../Data/Storage/";
        public const string OutputHtmlPath = "../../../Data/Output/html/";
        public const string OutputImagePath = "../../../Data/Output/images/";
        public const string OutputPath = "../../../Data/Output/";
        public const string licensePath = "../../../Data/Storage/GroupDocs.Total.lic";

        #region Configurations


        /// <summary>
        /// Initialize, populate and return the ViewerConfig object
        /// </summary>
        /// <returns>Populated ViewerConfig Object</returns>
        public static ViewerConfig GetConfigurations()
        {
            //ExStart:Configurations
            ViewerConfig config = new ViewerConfig();
            //set the storage path
            config.StoragePath = StoragePath;
            //Uncomment the below line for cache purpose
            config.EnableCaching = true;
            config.CacheFolderName = "cachefolder";
            return config;
            //ExEnd:Configurations

        }

        /// <summary>
        /// Initialize, populate and return the ViewerConfig object
        /// </summary>
        /// <param name="DefaultFontName">Font Name</param>
        /// <returns>Populated ViewerConfig Object</returns>
        public static ViewerConfig GetConfigurations(string DefaultFontName)
        {
            //ExStart:ConfigurationsWithDefaultFontName
            ViewerConfig config = new ViewerConfig();
            //set the storage path
            config.StoragePath = StoragePath;
            //Uncomment the below line for cache purpose
            //config.UseCache = true;
            return config;
            //ExEnd:ConfigurationsWithDefaultFontName

        }

        #endregion

        #region Transformations

        public static class PageTransformations
        {
            /// <summary>
            /// Rotate a Page before rendering html
            /// </summary>
            /// <param name="options"></param>
            /// <param name="angle"></param>

            public static void RotatePages(ref ViewerHandler<PageHtml> handler, String guid, int PageNumber, int angle)
            {
                //ExStart:rotationAngle
                // Set the property of handler's rotate Page
                handler.RotatePage(guid, new RotatePageOptions( PageNumber, angle));
                //ExEnd:rotationAngle
            }
            /// <summary>
            /// Rotate a Page before rendering image
            /// </summary>
            /// <param name="options"></param>
            /// <param name="angle"></param>
            public static void RotatePages(ref ViewerHandler<PageImage> handler, String guid, int PageNumber, int angle)
            {
                //ExStart:rotationAngle
                // Set the property of handler's rotate Page
                handler.RotatePage(guid, new RotatePageOptions( PageNumber, angle));
                //ExEnd:rotationAngle
            }
            /// <summary>
            /// Reorder a page before rendering html
            /// </summary>
            /// <param name="Handler">Base class of handlers</param>
            /// <param name="guid">File name</param>
            /// <param name="currentPageNumber">Existing number of page</param>
            /// <param name="newPageNumber">New number of page</param>
            public static void ReorderPage(ref ViewerHandler<PageHtml> Handler, String guid, int currentPageNumber, int newPageNumber)
            {
                //ExStart:reorderPage
                //Initialize the ReorderPageOptions object by passing guid as document name, current Page Number, new page number
                ReorderPageOptions options = new ReorderPageOptions(currentPageNumber, newPageNumber);
                // call ViewerHandler's Reorder page function by passing initialized ReorderPageOptions object.
                Handler.ReorderPage(guid, options);
                //ExEnd:reorderPage
            }
            /// <summary>
            /// Reorder a page before rendering image
            /// </summary>
            /// <param name="Handler">Base class of handlers</param>
            /// <param name="guid">File name</param>
            /// <param name="currentPageNumber">Existing number of page</param>
            /// <param name="newPageNumber">New number of page</param>
            public static void ReorderPage(ref ViewerHandler<PageImage> Handler, String guid, int currentPageNumber, int newPageNumber)
            {
                //ExStart:reorderPage
                //Initialize the ReorderPageOptions object by passing guid as document name, current Page Number, new page number
                ReorderPageOptions options = new ReorderPageOptions(currentPageNumber, newPageNumber);
                // call ViewerHandler's Reorder page function by passing initialized ReorderPageOptions object.
                Handler.ReorderPage(guid, options);
                //ExEnd:reorderPage
            }
            /// <summary>
            /// add a watermark text to all rendered images.
            /// </summary>
            /// <param name="options">HtmlOptions by reference</param>
            /// <param name="text">Watermark text</param>
            /// <param name="color">System.Drawing.Color</param>
            /// <param name="position"></param>
            /// <param name="width"></param>
            public static void AddWatermark(ref ImageOptions options, String text, Color color, WatermarkPosition position, int width)
            {
                //ExStart:AddWatermark
                //Initialize watermark object by passing the text to display.
                Watermark watermark = new Watermark(text);
                //Apply the watermark color by assigning System.Drawing.Color.
                watermark.Color = color;
                //Set the watermark's position by assigning an enum WatermarkPosition's value.
                watermark.Position = position;
                //set an integer value as watermark width 
                watermark.Width = width;
                // Set font name
                watermark.FontName = "MS Gothic";
                //Assign intialized and populated watermark object to ImageOptions or HtmlOptions objects
                options.Watermark = watermark;
                //ExEnd:AddWatermark
            }
            /// <summary>
            /// add a watermark text to all rendered Html pages.
            /// </summary>
            /// <param name="options">HtmlOptions by reference</param>
            /// <param name="text">Watermark text</param>
            /// <param name="color">System.Drawing.Color</param>
            /// <param name="position"></param>
            /// <param name="width"></param>
            public static void AddWatermark(ref HtmlOptions options, String text, Color color, WatermarkPosition position, int width)
            {

                Watermark watermark = new Watermark(text);
                watermark.Color = color;
                watermark.Position = position;
                watermark.Width = width;
                watermark.FontName = "\"Comic Sans MS\", cursive, sans-serif";
                options.Watermark = watermark; 
               

            }

        }

        #endregion

        #region ProductLicense

        /// <summary>
        /// Set product's license 
        /// </summary>
        public static void ApplyLicense()
        {
            License lic = new License();
            lic.SetLicense(licensePath);
        }

        /// <summary>
        /// Set metered license 
        /// </summary>
        public static void ApplyMeteredLicense()
        {
            //ExStart:ApplyMeteredLicense
            // Create new instance of GroupDocs.Viewer.Metered class
            GroupDocs.Viewer.Metered metered = new GroupDocs.Viewer.Metered();

            // Set public and private keys
            string publicKey = "***";
            string privateKey = "***";

            // Set public and private keys to metered instance
            metered.SetMeteredKey(publicKey, privateKey);
            //ExEnd:ApplyMeteredLicense
        }

        /// <summary>
        /// Get metered license consumption
        /// </summary>
        public static void GetMeteredLicenseConsumption()
        {
            //ExStart:GetMeteredLicenseConsumption
            // Create new instance of GroupDocs.Viewer.Metered class
            GroupDocs.Viewer.Metered metered = new GroupDocs.Viewer.Metered();

            // Set public and private keys
            string publicKey = "***";
            string privateKey = "***";

            // Set public and private keys to metered instance
            metered.SetMeteredKey(publicKey, privateKey);

            // Get metered value before usage of the comparison
            decimal amountBefore = GroupDocs.Viewer.Metered.GetConsumptionQuantity();

            Console.WriteLine("Amount (MB) consumed before:" + amountBefore);

            // Get pages
            GroupDocs.Viewer.Handler.ViewerHtmlHandler htmlHandler = new GroupDocs.Viewer.Handler.ViewerHtmlHandler();
            List<GroupDocs.Viewer.Domain.Html.PageHtml> pages = htmlHandler.GetPages("input.pdf");

            // Get metered value after usage of the comparison
            decimal amountAfter = GroupDocs.Viewer.Metered.GetConsumptionQuantity();

            Console.WriteLine("Amount (MB) consumed after: " + amountAfter);
            //ExEnd:GetMeteredLicenseConsumption
        }
        #endregion

        #region OutputHandling
        /// <summary>
        /// Save file in html form
        /// </summary>
        /// <param name="filename">Save as provided string</param>
        /// <param name="content">Html contents in String form</param>
        public static void SaveAsHtml(String filename, String content)
        {
            try
            {
                //ExStart:SaveAsHTML
                // set an html file name with absolute path
                String fname = Path.Combine(Path.GetFullPath(OutputHtmlPath), Path.GetFileNameWithoutExtension(filename) + ".html");

                // create a file at the disk
                System.IO.File.WriteAllText(fname, content);
                //ExEnd:SaveAsHTML
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Save the rendered images at disk
        /// </summary>
        /// <param name="imageName">Save as provided string</param>
        /// <param name="imageContent">stream of image contents</param>
        public static void SaveAsImage(String imageName, Stream imageContent)
        {
            try
            {
                //ExStart:SaveAsImage
                // extract the image from stream
                Image img = Image.FromStream(imageContent);

                //save the image in the form of jpeg
                img.Save(Path.Combine(Path.GetFullPath(OutputImagePath), Path.GetFileNameWithoutExtension(imageName)) + ".Jpeg", ImageFormat.Jpeg);
                //ExEnd:SaveAsImage
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Get document stream
        /// </summary>
        /// <param name="DocumentName">Input document name</param> 
        public static Stream GetDocumentStream(string DocumentName)
        {
            try
            {
                //ExStart:GetDocumentStream
                FileStream fsSource = new FileStream(StoragePath + DocumentName,
                     FileMode.Open, FileAccess.Read);

                // Read the source file into a byte array.
                byte[] bytes = new byte[fsSource.Length];
                int numBytesToRead = (int)fsSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                    // Break when the end of the file is reached.
                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                numBytesToRead = bytes.Length;

                return fsSource;


                //ExEnd:GetDocumentStream
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
                return null;
            }
        }

        /// <summary>
        /// Save file in any format
        /// </summary>
        /// <param name="filename">Save as provided string</param>
        /// <param name="content">Stream as content of a file</param>
        public static void SaveFile(String filename, Stream content)
        {
            try
            {
                //ExStart:SaveAnyFile
                //Create file stream
                FileStream fileStream = File.Create(Path.Combine(Path.GetFullPath(OutputPath), filename), (int)content.Length);

                // Initialize the bytes array with the stream length and then fill it with data
                byte[] bytesInStream = new byte[content.Length];
                content.Read(bytesInStream, 0, bytesInStream.Length);

                // Use write method to write to the file specified above
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                //ExEnd:SaveAnyFile
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }

}
