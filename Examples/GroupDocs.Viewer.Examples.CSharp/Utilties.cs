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
        public const string STORAGE_PATH = "../../../Data/Storage/";
        public const string OUTPUT_HTML_PATH = "../../../Data/Output/html/";
        public const string OUTPUT_IMAGE_PATH = "../../../Data/Output/images/";
        public const string OUTPUT_PATH = "../../../Data/Output/";
        public const string LICENSE_PATH = "../../../Data/Storage/GroupDocs.Total.lic";

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
            config.StoragePath = STORAGE_PATH;
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
            config.StoragePath = STORAGE_PATH;
            //Uncomment the below line for cache purpose
            //config.UseCache = true;
            return config;
            //ExEnd:ConfigurationsWithDefaultFontName

        }
        #endregion
        
        #region ProductLicense
        /// <summary>
        /// Set product's license 
        /// </summary>
        public static void ApplyLicense()
        {
            License lic = new License();
            lic.SetLicense(LICENSE_PATH);
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
                String fname = Path.Combine(Path.GetFullPath(OUTPUT_HTML_PATH), Path.GetFileNameWithoutExtension(filename) + ".html");

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
                img.Save(Path.Combine(Path.GetFullPath(OUTPUT_IMAGE_PATH), Path.GetFileNameWithoutExtension(imageName)) + ".Jpeg", ImageFormat.Jpeg);
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
                FileStream fsSource = new FileStream(STORAGE_PATH + DocumentName,
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
                FileStream fileStream = File.Create(Path.Combine(Path.GetFullPath(OUTPUT_PATH), filename), (int)content.Length);

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
