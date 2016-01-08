
Imports GroupDocs.Viewer.Config
Imports GroupDocs.Viewer.Converter.Options
Imports GroupDocs.Viewer.Domain
Imports GroupDocs.Viewer.Domain.Options
Imports GroupDocs.Viewer.Handler
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Linq
Imports System.Text

Namespace GroupDocs.Viewer.Examples
    Public NotInheritable Class Utilities
        Private Sub New()
        End Sub
        Public Const StoragePath As String = "../../../Data/Storage/"
        Public Const OutputHtmlPath As String = "../../../Data/Output/html/"
        Public Const OutputImagePath As String = "../../../Data/Output/images/"
        Public Const OutputPath As String = "../../../Data/Output/"
        Public Const licensePath As String = "../../../Data/Storage/GroupDocs.Total.lic"

#Region "Configurations"



        ''' <summary>
        ''' Initialize, populate and return the ViewerConfig object
        ''' </summary>
        ''' <returns>Populated ViewerConfig Object</returns>
        Public Shared Function GetConfigurations() As ViewerConfig
            'ExStart:Configurations
            Dim config As New ViewerConfig()
            'set the storage path
            config.StoragePath = StoragePath
            'Uncomment the below line for cache purpose
            'config.UseCache = true;
            Return config
            'ExEnd:Configurations

        End Function





#End Region

#Region "Transformations"

        Public NotInheritable Class PageTransformations
            Private Sub New()
            End Sub
            ''' <summary>
            ''' Rotate a Page before rendering
            ''' </summary>
            ''' <param name="options"></param>
            ''' <param name="angle"></param>

            Public Shared Sub RotatePages(ByRef options As ImageOptions, angle As Integer)
                'ExStart:rotationAngle
                ' Set the property of ImageOption's rotation angle
                options.RotationAngle = angle
                'ExEnd:rotationAngle
            End Sub
            ''' <summary>
            ''' Reorder a page before rendering
            ''' </summary>
            ''' <param name="Handler">Base class of handlers</param>
            ''' <param name="guid">File name</param>
            ''' <param name="currentPageNumber">Existing number of page</param>
            ''' <param name="newPageNumber">New number of page</param>
            Public Shared Sub ReorderPage(ByRef Handler As ViewerHandler, guid As [String], currentPageNumber As Integer, newPageNumber As Integer)
                'ExStart:reorderPage
                'Initialize the ReorderPageOptions object by passing guid as document name, current Page Number, new page number
                Dim options As New ReorderPageOptions(guid, currentPageNumber, newPageNumber)
                ' call ViewerHandler's Reorder page function by passing initialized ReorderPageOptions object.
                Handler.ReorderPage(options)
                'ExEnd:reorderPage
            End Sub
            ''' <summary>
            ''' add a watermark text to all rendered images.
            ''' </summary>
            ''' <param name="options">HtmlOptions by reference</param>
            ''' <param name="text">Watermark text</param>
            ''' <param name="color">System.Drawing.Color</param>
            ''' <param name="position"></param>
            ''' <param name="width"></param>
            Public Shared Sub AddWatermark(ByRef options As ImageOptions, text As [String], color As Color, position As WatermarkPosition, width As Integer)
                'ExStart:AddWatermark
                'Initialize watermark object by passing the text to display.
                Dim watermark As New Watermark(text)
                'Apply the watermark color by assigning System.Drawing.Color.
                watermark.Color = color
                'Set the watermark's position by assigning an enum WatermarkPosition's value.
                watermark.Position = position
                'set an integer value as watermark width 
                watermark.Width = width
                'Assign intialized and populated watermark object to ImageOptions or HtmlOptions objects
                options.Watermark = watermark
                'ExEnd:AddWatermark
            End Sub
            ''' <summary>
            ''' add a watermark text to all rendered Html pages.
            ''' </summary>
            ''' <param name="options">HtmlOptions by reference</param>
            ''' <param name="text">Watermark text</param>
            ''' <param name="color">System.Drawing.Color</param>
            ''' <param name="position"></param>
            ''' <param name="width"></param>
            Public Shared Sub AddWatermark(ByRef options As HtmlOptions, text As [String], color As Color, position As WatermarkPosition, width As Integer)

                Dim watermark As New Watermark(text)
                watermark.Color = color
                watermark.Position = position
                watermark.Width = width
                options.Watermark = watermark
            End Sub

        End Class

#End Region

#Region "ProductLicense"

        ''' <summary>
        ''' Set product's license for HTML Handler
        ''' </summary>
        Public Shared Sub ApplyLicense(ByRef handler As ViewerHtmlHandler)
            'ExStart:ApplyLicense
            ' Setup license whereas handler can be ViewerHtmlHandler or ViewerImageHandler.
            handler.SetLicense(licensePath)
            'ExEnd:ApplyLicense
        End Sub
        ''' <summary>
        ''' Set product's license for HTML Handler
        ''' </summary>
        ''' <param name="handler"></param>
        Public Shared Sub ApplyLicense(ByRef handler As ViewerImageHandler)
            ' Setup license
            handler.SetLicense(licensePath)
        End Sub

#End Region

#Region "OutputHandling"
        ''' <summary>
        ''' Save file in html form
        ''' </summary>
        ''' <param name="filename">Save as provided string</param>
        ''' <param name="content">Html contents in String form</param>
        Public Shared Sub SaveAsHtml(filename As [String], content As [String])
            Try
                'ExStart:SaveAsHTML
                ' set an html file name with absolute path
                Dim fname As [String] = Path.Combine(Path.GetFullPath(OutputHtmlPath), Path.GetFileNameWithoutExtension(filename) + ".html")

                ' create a file at the disk
                'ExEnd:SaveAsHTML
                System.IO.File.WriteAllText(fname, content)
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            End Try

        End Sub
        ''' <summary>
        ''' Save the rendered images at disk
        ''' </summary>
        ''' <param name="imageName">Save as provided string</param>
        ''' <param name="imageContent">stream of image contents</param>
        Public Shared Sub SaveAsImage(imageName As [String], imageContent As Stream)
            Try
                'ExStart:SaveAsImage
                ' extract the image from stream
                Dim img As Image = Image.FromStream(imageContent)

                'save the image in the form of jpeg
                'ExEnd:SaveAsImage
                img.Save(Path.Combine(Path.GetFullPath(OutputImagePath), Path.GetFileNameWithoutExtension(imageName)) + ".Jpeg", ImageFormat.Jpeg)
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Save file in any format
        ''' </summary>
        ''' <param name="filename">Save as provided string</param>
        ''' <param name="content">Stream as content of a file</param>
        Public Shared Sub SaveFile(filename As [String], content As Stream)
            Try
                'ExStart:SaveAnyFile
                'Create file stream
                Dim fileStream As FileStream = File.Create(Path.Combine(Path.GetFullPath(OutputPath), filename), CInt(content.Length))

                ' Initialize the bytes array with the stream length and then fill it with data
                Dim bytesInStream As Byte() = New Byte(content.Length - 1) {}
                content.Read(bytesInStream, 0, bytesInStream.Length)

                ' Use write method to write to the file specified above
                'ExEnd:SaveAnyFile
                fileStream.Write(bytesInStream, 0, bytesInStream.Length)
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

#End Region
    End Class

End Namespace

