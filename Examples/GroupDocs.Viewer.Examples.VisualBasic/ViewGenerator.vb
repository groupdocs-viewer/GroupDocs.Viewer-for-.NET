
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Viewer.Config
Imports GroupDocs.Viewer.Handler
Imports GroupDocs.Viewer.Converter.Options
Imports GroupDocs.Viewer.Domain.Html
Imports GroupDocs.Viewer.Domain.Image
Imports GroupDocs.Viewer.Domain.Options
Imports System.Drawing
Imports GroupDocs.Viewer.Domain
Imports GroupDocs.Viewer.Domain.Containers
Imports System.IO
Imports GroupDocs.Viewer.Domain.Transformation
Imports GroupDocs.Viewer.Handler.Input
Imports System.Globalization


Namespace GroupDocs.Viewer.Examples
    Public NotInheritable Class ViewGenerator
        Private Sub New()
        End Sub

#Region "HTMLRepresentation"


        ''' <summary>
        ''' Render simple document in html representation
        ''' </summary>
        ''' <param name="DocumentName">File name</param>
        ''' <param name="DocumentPassword">Optional</param>
        Public Shared Sub RenderDocumentAsHtml(DocumentName As [String], Optional DocumentPassword As [String] = Nothing)
            'ExStart:RenderAsHtml
            'Get Configurations
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create html handler
            Dim htmlHandler As New ViewerHtmlHandler(config)

            ' Guid implies that unique document name 
            Dim guid As String = DocumentName

            'Instantiate the HtmlOptions object
            Dim options As New HtmlOptions()

            'to get html representations of pages with embedded resources
            options.IsResourcesEmbedded = True

            ' Set password if document is password protected. 
            If Not [String].IsNullOrEmpty(DocumentPassword) Then
                options.Password = DocumentPassword
            End If

            'Get document pages in html form
            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid, options)

            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber & "_" & DocumentName, page.HtmlContent)
            Next
            'ExEnd:RenderAsHtml
        End Sub
        ''' <summary>
        ''' Render document in html representation with watermark
        ''' </summary>
        ''' <param name="DocumentName">file/document name</param>
        ''' <param name="WatermarkText">watermark text</param>
        ''' <param name="WatermarkColor"> System.Drawing.Color</param>
        ''' <param name="position">Watermark Position is optional parameter. Default value is WatermarkPosition.Diagonal</param>
        ''' <param name="WatermarkWidth"> width of watermark as integer. it is optional Parameter default value is 100</param>
        ''' <param name="DocumentPassword">Password Parameter is optional</param>
        Public Shared Sub RenderDocumentAsHtml(DocumentName As [String], WatermarkText As [String], WatermarkColor As Color, Optional position As WatermarkPosition = WatermarkPosition.Diagonal, Optional WatermarkWidth As Integer = 100, Optional DocumentPassword As [String] = Nothing)
            'ExStart:RenderAsHtmlWithWaterMark
            'Get Configurations
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create html handler
            Dim htmlHandler As New ViewerHtmlHandler(config)


            ' Guid implies that unique document name 
            Dim guid As String = DocumentName

            'Instantiate the HtmlOptions object 
            Dim options As New HtmlOptions()

            ' Set password if document is password protected. 
            If Not [String].IsNullOrEmpty(DocumentPassword) Then
                options.Password = DocumentPassword
            End If

            ' Call AddWatermark and pass the reference of HtmlOptions object as 1st parameter
            Utilities.PageTransformations.AddWatermark(options, WatermarkText, WatermarkColor, position, WatermarkWidth)

            'Get document pages in html form
            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid, options)

            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber & "_" & DocumentName, page.HtmlContent)
            Next
            'ExEnd:RenderAsHtmlWithWaterMark
        End Sub
        ''' <summary>
        '''  document in html representation and reorder a page
        ''' </summary>
        ''' <param name="DocumentName">file/document name</param>
        ''' <param name="CurrentPageNumber">Page existing order number</param>
        ''' <param name="NewPageNumber">Page new order number</param>
        ''' <param name="DocumentPassword">Password Parameter is optional</param>
        Public Shared Sub RenderDocumentAsHtml(DocumentName As [String], CurrentPageNumber As Integer, NewPageNumber As Integer, Optional DocumentPassword As [String] = Nothing)
            'ExStart:RenderAsHtmlAndReorderPage
            'Get Configurations
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Cast ViewerHtmlHandler class object to its base class(ViewerHandler).
            Dim handler As ViewerHandler(Of PageHtml) = New ViewerHtmlHandler(config)

            ' Guid implies that unique document name 
            Dim guid As String = DocumentName


            'Instantiate the HtmlOptions object with setting of Reorder Transformation
            Dim options As New HtmlOptions() With {.Transformations = Transformation.Reorder}


            'to get html representations of pages with embedded resources
            options.IsResourcesEmbedded = True

            ' Set password if document is password protected. 
            If Not [String].IsNullOrEmpty(DocumentPassword) Then
                options.Password = DocumentPassword
            End If

            'Call ReorderPage and pass the reference of ViewerHandler's class  parameter by reference. 
            Utilities.PageTransformations.ReorderPage(handler, guid, CurrentPageNumber, NewPageNumber)

            'down cast the handler(ViewerHandler) to viewerHtmlHandler
            Dim htmlHandler As ViewerHtmlHandler = DirectCast(handler, ViewerHtmlHandler)

            'Get document pages in html form
            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid, options)

            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber & "_" & DocumentName, page.HtmlContent)
            Next
            'ExEnd:RenderAsHtmlAndReorderPage
        End Sub
        ''' <summary>
        ''' Render a document in html representation whom located at web/remote location.
        ''' </summary>
        ''' <param name="DocumentURL">URL of the document</param>
        ''' <param name="DocumentPassword">Password Parameter is optional</param>
        Public Shared Sub RenderDocumentAsHtml(DocumentURL As Uri, Optional DocumentPassword As [String] = Nothing)
            'ExStart:RenderRemoteDocAsHtml
            'Get Configurations 
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create html handler
            Dim htmlHandler As New ViewerHtmlHandler(config)

            'Instantiate the HtmlOptions object
            Dim options As New HtmlOptions()

            If Not [String].IsNullOrEmpty(DocumentPassword) Then
                options.Password = DocumentPassword
            End If

            'Get document pages in html form
            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(DocumentURL, options)

            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber & "_" & Path.GetFileName(DocumentURL.LocalPath), page.HtmlContent)
            Next
            'ExEnd:RenderRemoteDocAsHtml
        End Sub

        ''' <summary>
        ''' Render a document in html representation with specifying resource prefix.
        ''' </summary>
        ''' <param name="DocumentName">file/document name</param>
        Public Shared Sub RenderDocumentAsHtmlWithResourcePrefix(DocumentName As String)
            'ExStart:RenderDocumentAsHtmlWithResourcePrefix
            'Get Configurations
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            'Create html handler
            Dim htmlHandler As New ViewerHtmlHandler(config)

            'Guid implies that unique document name 
            Dim guid As String = DocumentName

            'Instantiate the HtmlOptions object
            Dim options As New HtmlOptions()

            'To get html representations of pages with embedded resources
            options.IsResourcesEmbedded = False

            'Set resource prefix
            options.HtmlResourcePrefix = "http://contoso.com/api/getResource?name="

            'To ignore resource prefix in CSS 
            'options.IgnoreResourcePrefixForCss = true;

            'Get document pages in html form
            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid, options)

            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(Convert.ToString(page.PageNumber + "_") & DocumentName, page.HtmlContent)
            Next
            'ExEnd:RenderDocumentAsHtmlWithResourcePrefix


        End Sub

        ''' <summary>
        ''' Render hidden pages of Visio file as Html.
        ''' </summary>
        ''' <param name="DocumentName">file/document name</param>
        Public Shared Sub RenderHiddenPagesOfVisioAsHtml(DocumentName As String)
            'ExStart:RenderHiddenPagesInVisioAsHtml
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create html handler
            Dim htmlHandler As New ViewerHtmlHandler(config)
            Dim guid As String = DocumentName

            ' Set html options to show grid lines
            Dim options As New HtmlOptions()
            options.DiagramOptions.ShowHiddenPages = True

            Dim container As DocumentInfoContainer = htmlHandler.GetDocumentInfo(guid)

            For Each page As PageData In container.Pages
                Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible)
            Next

            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid, options)

            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(Convert.ToString(page.PageNumber + "_") & DocumentName, page.HtmlContent)
            Next
            'ExEnd:RenderHiddenPagesInVisioAsHtml


        End Sub

        ''' <summary>
        ''' Render Excel file as Html with internal hyperlink prefix.
        ''' </summary>
        ''' <param name="DocumentName">file/document name</param>
        Public Shared Sub RenderExcelAsHtmlWithInternalHyperlinkPrefix(DocumentName As String)

            'ExStart:RenderExcelAsHtmlWithInternalHyperlinkPrefix
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create html handler
            Dim htmlHandler As New ViewerHtmlHandler(config)
            Dim guid As String = DocumentName

            ' Set html options to show grid lines
            Dim options As New HtmlOptions()
            options.CellsOptions.InternalHyperlinkPrefix = "http://contoso.com/api/getPage?name="

            'InternalHyperlinkPrefix value may contain page number placeholder which will be substituted with referenced sheet number.
            options.CellsOptions.InternalHyperlinkPrefix = "http://contoso.com/api/getPage?number={page-number}"

            Dim container As DocumentInfoContainer = htmlHandler.GetDocumentInfo(guid)

            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid, options)

            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(Convert.ToString(page.PageNumber + "_") & DocumentName, page.HtmlContent)
            Next
            'ExEnd:RenderExcelAsHtmlWithInternalHyperlinkPrefix

        End Sub


#End Region

#Region "ImageRepresentation"
        ''' <summary>
        ''' Render simple document in image representation
        ''' </summary>
        ''' <param name="DocumentName">File name</param>
        ''' <param name="DocumentPassword">Optional</param>
        Public Shared Sub RenderDocumentAsImages(DocumentName As [String], Optional DocumentPassword As [String] = Nothing)
            'ExStart:RenderAsImage
            'Get Configurations
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create image handler 
            Dim imageHandler As New ViewerImageHandler(config)

            ' Guid implies that unique document name 
            Dim guid As String = DocumentName

            'Initialize ImageOptions Object
            Dim options As New ImageOptions()

            ' Set password if document is password protected. 
            If Not [String].IsNullOrEmpty(DocumentPassword) Then
                options.Password = DocumentPassword
            End If

            ' Set one page per sheet option to false for Multiple pages per sheet in Excel documents, default value of this option is true
            ' options.CellsOptions.OnePagePerSheet = false;

            'Get document pages in image form
            Dim Images As List(Of PageImage) = imageHandler.GetPages(guid, options)

            For Each image As PageImage In Images
                'Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream)
            Next
            'ExEnd:RenderAsImage

        End Sub
        ''' <summary>
        ''' Render document in image representation with watermark
        ''' </summary>
        ''' <param name="DocumentName">file/document name</param>
        ''' <param name="WatermarkText">watermark text</param>
        ''' <param name="WatermarkColor"> System.Drawing.Color</param>
        ''' <param name="position">Watermark Position is optional parameter. Default value is WatermarkPosition.Diagonal</param>
        ''' <param name="WatermarkWidth"> width of watermark as integer. it is optional Parameter default value is 100</param>
        ''' <param name="DocumentPassword">Password Parameter is optional</param>
        Public Shared Sub RenderDocumentAsImages(DocumentName As [String], WatermarkText As [String], WatermarkColor As Color, Optional position As WatermarkPosition = WatermarkPosition.Diagonal, Optional WatermarkWidth As Integer = 100, Optional DocumentPassword As [String] = Nothing)
            'ExStart:RenderAsImageWithWaterMark
            'Get Configurations
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create image handler
            Dim imageHandler As New ViewerImageHandler(config)

            ' Guid implies that unique document name
            Dim guid As String = DocumentName

            'Initialize ImageOptions Object
            Dim options As New ImageOptions()

            ' Set password if document is password protected. 
            If Not [String].IsNullOrEmpty(DocumentPassword) Then
                options.Password = DocumentPassword
            End If

            ' Call AddWatermark and pass the reference of ImageOptions object as 1st parameter
            Utilities.PageTransformations.AddWatermark(options, WatermarkText, WatermarkColor, position, WatermarkWidth)

            'Get document pages in image form
            Dim Images As List(Of PageImage) = imageHandler.GetPages(guid, options)

            For Each image As PageImage In Images
                'Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream)
            Next
            'ExEnd:RenderAsImageWithWaterMark
        End Sub
        ''' <summary>
        ''' Render the document in image form and set the rotation angle to rotate the page while display.
        ''' </summary>
        ''' <param name="DocumentName"></param>
        ''' <param name="RotationAngle">rotation angle in digits</param>
        ''' <param name="DocumentPassword"></param>
        Public Shared Sub RenderDocumentAsImages(DocumentName As [String], RotationAngle As Integer, Optional DocumentPassword As [String] = Nothing)
            'ExStart:RenderAsImageWithRotationTransformation
            'Get Configurations
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create image handler
            Dim handler As ViewerHandler(Of PageImage) = New ViewerImageHandler(config)

            ' Guid implies that unique document name 
            Dim guid As String = DocumentName

            'Initialize ImageOptions Object and setting Rotate Transformation
            Dim options As New ImageOptions() With { _
                 .Transformations = Transformation.Rotate _
            }

            ' Set password if document is password protected. 
            If Not [String].IsNullOrEmpty(DocumentPassword) Then
                options.Password = DocumentPassword
            End If

            'Call RotatePages to apply rotate transformation to a page
            Utilities.PageTransformations.RotatePages(handler, guid, 1, RotationAngle)

            'down cast the handler(ViewerHandler) to viewerHtmlHandler
            Dim imageHandler As ViewerImageHandler = DirectCast(handler, ViewerImageHandler)

            'Get document pages in image form
            Dim Images As List(Of PageImage) = imageHandler.GetPages(guid, options)

            For Each image As PageImage In Images
                'Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream)
            Next
            'ExEnd:RenderAsImageWithRotationTransformation
        End Sub
        ''' <summary>
        '''  document in image representation and reorder a page
        ''' </summary>
        ''' <param name="DocumentName">file/document name</param>
        ''' <param name="CurrentPageNumber">Page existing order number</param>
        ''' <param name="NewPageNumber">Page new order number</param>
        ''' <param name="DocumentPassword">Password Parameter is optional</param>
        Public Shared Sub RenderDocumentAsImages(DocumentName As [String], CurrentPageNumber As Integer, NewPageNumber As Integer, Optional DocumentPassword As [String] = Nothing)
            'ExStart:RenderAsImageAndReorderPage
            'Get Configurations
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Cast ViewerHtmlHandler class object to its base class(ViewerHandler).
            Dim handler As ViewerHandler(Of PageImage) = New ViewerImageHandler(config)

            ' Guid implies that unique document name 
            Dim guid As String = DocumentName

            'Initialize ImageOptions Object and setting Reorder Transformation
            Dim options As New ImageOptions() With { _
                .Transformations = Transformation.Reorder _
            }

            ' Set password if document is password protected. 
            If Not [String].IsNullOrEmpty(DocumentPassword) Then
                options.Password = DocumentPassword
            End If

            'Call ReorderPage and pass the reference of ViewerHandler's class  parameter by reference. 
            Utilities.PageTransformations.ReorderPage(handler, guid, CurrentPageNumber, NewPageNumber)

            'down cast the handler(ViewerHandler) to viewerHtmlHandler
            Dim imageHandler As ViewerImageHandler = DirectCast(handler, ViewerImageHandler)

            'Get document pages in image form
            Dim Images As List(Of PageImage) = imageHandler.GetPages(guid, options)

            For Each image As PageImage In Images
                'Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream)
            Next
            'ExEnd:RenderAsImageAndReorderPage
        End Sub
        ''' <summary>
        ''' Render a document in image representation whom located at web/remote location.
        ''' </summary>
        ''' <param name="DocumentURL">URL of the document</param>
        ''' <param name="DocumentPassword">Password Parameter is optional</param>
        Public Shared Sub RenderDocumentAsImages(DocumentURL As Uri, Optional DocumentPassword As [String] = Nothing)
            'ExStart:RenderRemoteDocAsImages
            'Get Configurations
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create image handler
            Dim imageHandler As New ViewerImageHandler(config)

            'Initialize ImageOptions Object
            Dim options As New ImageOptions()

            ' Set password if document is password protected. 
            If Not [String].IsNullOrEmpty(DocumentPassword) Then
                options.Password = DocumentPassword
            End If

            'Get document pages in image form
            Dim Images As List(Of PageImage) = imageHandler.GetPages(DocumentURL, options)

            For Each image As PageImage In Images
                'Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + Path.GetFileName(DocumentURL.LocalPath), image.Stream)
            Next
            'ExEnd:RenderRemoteDocAsImages
        End Sub
        ''' <summary>
        ''' Render hidden pages of Visio file as image.
        ''' </summary>
        ''' <param name="DocumentName">file/document name</param>
        Public Shared Sub RenderHiddenPagesOfVisioAsImage(DocumentName As String)

            'ExStart:RenderHiddenPagesOfVisioAsImage
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create image handler
            Dim imageHandler As New ViewerImageHandler(config)
            Dim guid As String = DocumentName

            ' Set image options to show hidden pages
            Dim options As New ImageOptions()
            options.DiagramOptions.ShowHiddenPages = True

            Dim container As DocumentInfoContainer = imageHandler.GetDocumentInfo(guid)

            For Each page As PageData In container.Pages
                Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible)
            Next

            Dim pages As List(Of PageImage) = imageHandler.GetPages(guid, options)

            For Each page As PageImage In pages
                'Save each image at disk
                Utilities.SaveAsImage(Convert.ToString(page.PageNumber + "_") & DocumentName, page.Stream)
            Next
            'ExEnd:RenderHiddenPagesOfVisioAsImage


        End Sub
#End Region

#Region "GeneralRepresentation"
        ''' <summary>
        ''' Render a document as it is (original form)
        ''' </summary>
        ''' <param name="DocumentName"></param>
        Public Shared Sub RenderDocumentAsOriginal(DocumentName As [String])
            'ExStart:RenderOriginal
            ' Create image handler 
            Dim imageHandler As New ViewerImageHandler(Utilities.GetConfigurations())

            ' Guid implies that unique document name 
            Dim guid As String = DocumentName

            ' Get original file
            Dim container As FileContainer = imageHandler.GetFile(guid)

            'Save each image at disk
            Utilities.SaveAsImage(DocumentName, container.Stream)
            'ExEnd:RenderOriginal

        End Sub
        ''' <summary>
        ''' Render a document in PDF Form
        ''' </summary>
        ''' <param name="DocumentName"></param>
        Public Shared Sub RenderDocumentAsPDF(DocumentName As [String])
            'ExStart:RenderAsPdf
            ' Create/initialize image handler 
            Dim imageHandler As New ViewerImageHandler(Utilities.GetConfigurations())

            ' To Apply transformations on PDF file
            ' options.Transformations = Transformation.Rotate | Transformation.Reorder | Transformation.AddPrintAction;

            ' Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            Dim container As FileContainer = imageHandler.GetPdfFile(DocumentName)

            'Change the extension of the file and assign to a string type variable filename
            Dim filename As [String] = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf"

            'Save each image at disk
            Utilities.SaveFile(filename, container.Stream)
            'ExEnd:RenderAsPdf

        End Sub

        ''' <summary>
        ''' Render a document in PDF Form with watermark 
        ''' </summary>
        ''' <param name="DocumentName"></param>
        ''' <param name="WatermarkText"></param>
        Public Shared Sub RenderDocumentAsPDF(DocumentName As [String], WatermarkText As [String])
            'ExStart:RenderAsPdf
            ' Create/initialize image handler 
            Dim imageHandler As New ViewerImageHandler(Utilities.GetConfigurations())

            ' Set watermark properties
            Dim watermark As New Watermark(WatermarkText)
            watermark.Color = System.Drawing.Color.Blue
            watermark.Position = WatermarkPosition.Diagonal
            watermark.Width = 100

            Dim options As New PdfFileOptions()
            options.Watermark = watermark

            ' To Apply transformations on PDF file
            ' options.Transformations = Transformation.Rotate | Transformation.Reorder | Transformation.AddPrintAction;

            ' Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            Dim container As FileContainer = imageHandler.GetPdfFile(DocumentName, options)

            'Change the extension of the file and assign to a string type variable filename
            Dim filename As [String] = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf"

            'Save each image at disk
            Utilities.SaveFile(filename, container.Stream)
            'ExEnd:RenderAsPdf

        End Sub

        ''' <summary>
        ''' Render a document in PDF Form with watermark 
        ''' </summary>
        ''' <param name="DocumentName"></param>
        ''' <param name="WatermarkText"></param>
        ''' <param name="WatermarkFontName"></param>
        Public Shared Sub RenderDocumentAsPDF(DocumentName As [String], WatermarkText As [String], Optional WatermarkFontName As [String] = "MS Gothic")
            'ExStart:RenderAsPdf
            ' Create/initialize image handler 
            Dim imageHandler As New ViewerImageHandler(Utilities.GetConfigurations())

            ' Set watermark properties
            Dim watermark As New Watermark(WatermarkText)
            watermark.Color = System.Drawing.Color.Blue
            watermark.Position = WatermarkPosition.Diagonal
            watermark.Width = 100

            ' Set watermark font name which contains Japanese characters
            watermark.FontName = WatermarkFontName

            Dim options As New PdfFileOptions()
            options.Watermark = watermark

            ' To Apply transformations on PDF file
            ' options.Transformations = Transformation.Rotate | Transformation.Reorder | Transformation.AddPrintAction;

            ' Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            Dim container As FileContainer = imageHandler.GetPdfFile(DocumentName, options)

            'Change the extension of the file and assign to a string type variable filename
            Dim filename As [String] = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf"

            'Save each image at disk
            Utilities.SaveFile(filename, container.Stream)
            'ExEnd:RenderAsPdf

        End Sub

        ''' <summary>
        ''' Load directory structure as file tree
        ''' </summary>
        ''' <param name="Path"></param>
        Public Shared Sub LoadFileTree(Path As [String])
            'ExStart:LoadFileTree
            ' Create/initialize image handler 
            Dim imageHandler As New ViewerImageHandler(Utilities.GetConfigurations())

            ' Load file list for custom path 
            Dim options As New FileListOptions(Path)

            ' Load file list sorted by Name and ordered Ascending for custom path
            Dim options1 As New FileListOptions(Path, FileListOptions.FileListSortBy.Name, FileListOptions.FileListOrderBy.Ascending)

            ' Load file list for ViewerConfig.StoragePath
            Dim container As FileListContainer = imageHandler.GetFileList()

            ' Load file list for custom path
            Dim container1 As FileListContainer = imageHandler.GetFileList(options)

            For Each node As Object In container.Files
                If node.IsDirectory Then
                    Console.WriteLine("Guid: {0} | Name: {1} | LastModificationDate: {2}", node.Guid, node.Name, node.LastModificationDate)
                Else
                    Console.WriteLine("Guid: {0} | Name: {1} | Document type: {2} | File type: {3} | Extension: {4} | Size: {5} | LastModificationDate: {6}", node.Guid, node.Name, node.DocumentType, node.FileType, node.Extension, _
                        node.Size, node.LastModificationDate)
                End If
            Next
            'ExEnd:LoadFileTree

        End Sub

#End Region


#Region "InputDataHandlers"

        ''' <summary>
        ''' Render a document from Azure Storage 
        ''' </summary>
        ''' <param name="DocumentName"></param>
        Public Shared Sub RenderDocFromAzure(DocumentName As [String])
            ' Setup GroupDocs.Viewer config
            Dim config As New ViewerConfig()
            config.StoragePath = "C:\storage"

            ' File guid
            Dim guid As String = "word.doc"

            ' Use custom IInputDataHandler implementation
            Dim inputDataHandler As IInputDataHandler = New AzureInputDataHandler("<Account_Name>", "<Account_Key>", "<Container_Name>")

            ' Get file HTML representation
            Dim htmlHandler As New ViewerHtmlHandler(config, inputDataHandler)

            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid)
            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent)
            Next
        End Sub
        ''' <summary>
        ''' Render a document from FTP location 
        ''' </summary>
        ''' <param name="DocumentName"></param>
        Public Shared Sub RenderDocFromFTP(DocumentName As [String])
            ' Setup GroupDocs.Viewer config
            Dim config As New ViewerConfig()
            config.StoragePath = "C:\storage"

            ' File guid
            Dim guid As String = "word.doc"

            ' Use custom IInputDataHandler implementation
            Dim inputDataHandler As IInputDataHandler = New FtpInputDataHandler()

            ' Get file HTML representation
            Dim htmlHandler As New ViewerHtmlHandler(config, inputDataHandler)

            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid)
            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent)
            Next
        End Sub
#End Region

#Region "OtherOperations"
        ''' <summary>
        ''' Set custom fonts directory path
        ''' </summary>
        ''' <param name="DocumentName">Input document name</param>
        Public Shared Sub SetCustomFontDirectory(DocumentName As [String])
            Try
                'ExStart:SetCustomFontDirectory
                ' Setup GroupDocs.Viewer config
                Dim config As ViewerConfig = Utilities.GetConfigurations()

                ' Add custom fonts directories to FontDirectories list
                config.FontDirectories.Add("/usr/admin/Fonts")
                config.FontDirectories.Add("/home/admin/Fonts")

                Dim htmlHandler As New ViewerHtmlHandler(config)

                ' File guid
                Dim guid As String = DocumentName

                Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid)

                For Each page As PageHtml In pages
                    'Save each page at disk
                    Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent)
                    'ExEnd:SetCustomFontDirectory
                Next
            Catch exp As System.Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub
#End Region

#Region "EmailAttachments"
        ''' <summary>
        ''' Get attached image with email message
        ''' </summary>
        ''' <param name="DocumentName">Input document name</param>
        Public Shared Sub GetEmailAttachments(DocumentName As [String])
            Try
                'ExStart:GetEmailAttachments
                ' Setup GroupDocs.Viewer config
                Dim config As ViewerConfig = Utilities.GetConfigurations()

                ' Create image handler
                Dim handler As New ViewerImageHandler(config)
                Dim attachment As New EmailAttachment(DocumentName, "attachment-image.png")

                ' Get attachment original file
                Dim container As FileContainer = handler.GetFile(attachment)

                Console.WriteLine("Attach name: {0}, Type: {1}", attachment.Name, attachment.FileType)
                'ExEnd:GetEmailAttachments
                Console.WriteLine("Attach stream lenght: {0}", container.Stream.Length)
            Catch exp As System.Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Get attached file's html representation
        ''' </summary>
        ''' <param name="DocumentName">Input document name</param>
        Public Shared Sub GetEmailAttachmentHTMLRepresentation(DocumentName As [String])
            Try
                'ExStart:GetEmailAttachmentHTMLRepresentation
                ' Setup GroupDocs.Viewer config
                Dim config As ViewerConfig = Utilities.GetConfigurations()

                ' Setup html conversion options
                Dim htmlOptions As New HtmlOptions()
                htmlOptions.IsResourcesEmbedded = False

                ' Init viewer html handler
                Dim handler As New ViewerHtmlHandler(config)

                Dim info As DocumentInfoContainer = handler.GetDocumentInfo(DocumentName)

                ' Iterate over the attachments collection
                For Each attachment As AttachmentBase In info.Attachments
                    Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType)

                    ' Get attachment document html representation
                    Dim pages As List(Of PageHtml) = handler.GetPages(attachment, htmlOptions)
                    For Each page As PageHtml In pages
                        Console.WriteLine("  Page: {0}, size: {1}", page.PageNumber, page.HtmlContent.Length)
                        For Each htmlResource As HtmlResource In page.HtmlResources
                            Dim resourceStream As Stream = handler.GetResource(attachment, htmlResource)
                            Console.WriteLine("     Resource: {0}, size: {1}", htmlResource.ResourceName, resourceStream.Length)
                        Next
                    Next
                    'ExEnd:GetEmailAttachmentHTMLRepresentation
                Next
            Catch exp As System.Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Get attached file's image representation
        ''' </summary>
        ''' <param name="DocumentName">Input document name</param>
        Public Shared Sub GetEmailAttachmentImageRepresentation(DocumentName As [String])
            Try
                'ExStart:GetEmailAttachmentImageRepresentation
                ' Setup GroupDocs.Viewer config
                Dim config As ViewerConfig = Utilities.GetConfigurations()

                ' Init viewer image handler
                Dim handler As New ViewerImageHandler(config)

                Dim info As DocumentInfoContainer = handler.GetDocumentInfo(DocumentName)

                ' Iterate over the attachments collection
                For Each attachment As AttachmentBase In info.Attachments
                    Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType)

                    ' Get attachment document image representation
                    Dim pages As List(Of PageImage) = handler.GetPages(attachment)
                    For Each page As PageImage In pages
                        Console.WriteLine("  Page: {0}, size: {1}", page.PageNumber, page.Stream.Length)
                    Next
                    'ExEnd:GetEmailAttachmentImageRepresentation
                Next
            Catch exp As System.Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub
#End Region

#Region "DocumentInformation"
        ''' <summary>
        ''' Get document information by guid
        ''' </summary>
        ''' <param name="DocumentName">Input document name</param>
        Public Shared Sub GetDocumentInfoByGuid(DocumentName As [String])
            Try
                'ExStart:GetDocumentInfoByGuid
                ' Setup GroupDocs.Viewer config
                Dim config As ViewerConfig = Utilities.GetConfigurations()

                ' Create html handler
                Dim htmlHandler As New ViewerHtmlHandler(config)

                Dim guid As String = DocumentName
                ' Get document information
                Dim options As New DocumentInfoOptions()
                Dim documentInfo As DocumentInfoContainer = htmlHandler.GetDocumentInfo(guid, options)

                Console.WriteLine("DateCreated: {0}", documentInfo.DateCreated)
                Console.WriteLine("DocumentType: {0}", documentInfo.DocumentType)
                Console.WriteLine("DocumentTypeFormat: {0}", documentInfo.DocumentTypeFormat)
                Console.WriteLine("Extension: {0}", documentInfo.Extension)
                Console.WriteLine("FileType: {0}", documentInfo.FileType)
                Console.WriteLine("Guid: {0}", documentInfo.Guid)
                Console.WriteLine("LastModificationDate: {0}", documentInfo.LastModificationDate)
                Console.WriteLine("Name: {0}", documentInfo.Name)
                Console.WriteLine("PageCount: {0}", documentInfo.Pages.Count)
                Console.WriteLine("Size: {0}", documentInfo.Size)

                For Each pageData As PageData In documentInfo.Pages
                    Console.WriteLine("Page number: {0}", pageData.Number)
                    Console.WriteLine("Page name: {0}", pageData.Name)
                    'ExEnd:GetDocumentInfoByGuid
                Next
            Catch exp As System.Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Get document information by Uri
        ''' </summary>
        ''' <param name="Uri__1">Uri of input document</param>
        Public Shared Sub GetDocumentInfoByUri(Uri__1 As [String])
            Try
                'ExStart:GetDocumentInfoByUri
                ' Setup GroupDocs.Viewer config
                Dim config As ViewerConfig = Utilities.GetConfigurations()

                ' Create html handler
                Dim htmlHandler As New ViewerHtmlHandler(config)

                Dim uri__2 As New Uri(Uri__1)

                ' Get document information
                Dim options As New DocumentInfoOptions()
                Dim documentInfo As DocumentInfoContainer = htmlHandler.GetDocumentInfo(uri__2, options)

                Console.WriteLine("DateCreated: {0}", documentInfo.DateCreated)
                Console.WriteLine("DocumentType: {0}", documentInfo.DocumentType)
                Console.WriteLine("DocumentTypeFormat: {0}", documentInfo.DocumentTypeFormat)
                Console.WriteLine("Extension: {0}", documentInfo.Extension)
                Console.WriteLine("FileType: {0}", documentInfo.FileType)
                Console.WriteLine("Guid: {0}", documentInfo.Guid)
                Console.WriteLine("LastModificationDate: {0}", documentInfo.LastModificationDate)
                Console.WriteLine("Name: {0}", documentInfo.Name)
                Console.WriteLine("PageCount: {0}", documentInfo.Pages.Count)
                Console.WriteLine("Size: {0}", documentInfo.Size)

                For Each pageData As PageData In documentInfo.Pages
                    Console.WriteLine("Page number: {0}", pageData.Number)
                    Console.WriteLine("Page name: {0}", pageData.Name)
                    'ExEnd:GetDocumentInfoByUri
                Next
            Catch exp As System.Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Get document information by stream
        ''' </summary>
        ''' <param name="DocumentName">Name of input document</param>
        Public Shared Sub GetDocumentInfoByStream(DocumentName As [String])
            Try
                'ExStart:GetDocumentInfoByStream
                ' Setup GroupDocs.Viewer config
                Dim config As ViewerConfig = Utilities.GetConfigurations()

                ' Create html handler
                Dim htmlHandler As New ViewerHtmlHandler(config)

                ' Get document stream
                Dim stream As Stream = Utilities.GetDocumentStream(DocumentName)
                ' Get document information
                Dim options As New DocumentInfoOptions()
                Dim documentInfo As DocumentInfoContainer = htmlHandler.GetDocumentInfo(stream, options)

                Console.WriteLine("DateCreated: {0}", documentInfo.DateCreated)
                Console.WriteLine("DocumentType: {0}", documentInfo.DocumentType)
                Console.WriteLine("DocumentTypeFormat: {0}", documentInfo.DocumentTypeFormat)
                Console.WriteLine("Extension: {0}", documentInfo.Extension)
                Console.WriteLine("FileType: {0}", documentInfo.FileType)
                Console.WriteLine("Guid: {0}", documentInfo.Guid)
                Console.WriteLine("LastModificationDate: {0}", documentInfo.LastModificationDate)
                Console.WriteLine("Name: {0}", documentInfo.Name)
                Console.WriteLine("PageCount: {0}", documentInfo.Pages.Count)
                Console.WriteLine("Size: {0}", documentInfo.Size)

                For Each pageData As PageData In documentInfo.Pages
                    Console.WriteLine("Page number: {0}", pageData.Number)
                    Console.WriteLine("Page name: {0}", pageData.Name)
                Next
                stream.Close()
                'ExEnd:GetDocumentInfoByStream

            Catch exp As System.Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub


#End Region

#Region "DocumentCache"
        ''' <summary>
        ''' Remove cache files 
        ''' </summary>
        Public Shared Sub RemoveCacheFiles()
            Try
                'ExStart:RemoveCacheFiles
                ' Setup GroupDocs.Viewer config
                Dim config As ViewerConfig = Utilities.GetConfigurations()

                ' Init viewer image or html handler
                Dim viewerImageHandler As New ViewerHtmlHandler(config)

                'Clear all cache files 
                'ExEnd:RemoveCacheFiles
                viewerImageHandler.ClearCache()
            Catch exp As System.Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Remove cache file older than specified date 
        ''' </summary>
        Public Shared Sub RemoveCacheFiles(OlderThanDays As TimeSpan)
            Try
                'ExStart:RemoveCacheFilesTimeSpan
                ' Setup GroupDocs.Viewer config
                Dim config As ViewerConfig = Utilities.GetConfigurations()

                ' Init viewer image or html handler
                Dim viewerImageHandler As New ViewerImageHandler(config)

                'Clear files from cache older than specified time interval 
                'ExEnd:RemoveCacheFilesTimeSpan
                viewerImageHandler.ClearCache(OlderThanDays)
            Catch exp As System.Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub

#End Region

#Region "OtherImprovements"

        ' Working from 3.2.0

        ''' <summary>
        ''' Show grid lines for Excel files in html representation
        ''' </summary>
        ''' <param name="DocumentName"></param>
        Public Shared Sub RenderWithGridLinesInExcel(DocumentName As [String])
            ' Setup GroupDocs.Viewer config
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            Dim htmlHandler As New ViewerHtmlHandler(config)

            ' File guid
            Dim guid As String = DocumentName

            ' Set html options to show grid lines
            Dim options As New HtmlOptions()
            'do same while using ImageOptions
            options.CellsOptions.ShowGridLines = True

            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid, options)

            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent)
            Next
        End Sub
        ''' <summary>
        ''' Multiple pages per sheet
        ''' </summary>
        ''' <param name="DocumentName"></param>
        Public Shared Sub RenderMultiExcelSheetsInOnePage(DocumentName As [String])
            ' Setup GroupDocs.Viewer config
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create image or html handler
            Dim imageHandler As New ViewerImageHandler(config)
            Dim guid As String = DocumentName

            ' Set pdf file one page per sheet option to false, default value of this option is true
            Dim pdfFileOptions As New PdfFileOptions()

            pdfFileOptions.CellsOptions.OnePagePerSheet = False

            'Get pdf file
            Dim fileContainer As FileContainer = imageHandler.GetPdfFile(guid)

            Utilities.SaveFile("test.pdf", fileContainer.Stream)
        End Sub
        ''' <summary>
        ''' Get all supported document formats
        ''' </summary>

        Public Shared Sub ShowAllSupportedFormats()
            ' Setup GroupDocs.Viewer config
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            ' Create image or html handler
            Dim imageHandler As New ViewerImageHandler(config)

            ' Get supported document formats
            Dim documentFormatsContainer As DocumentFormatsContainer = imageHandler.GetSupportedDocumentFormats()
            Dim supportedDocumentFormats As Dictionary(Of String, String) = documentFormatsContainer.SupportedDocumentFormats

            For Each supportedDocumentFormat As KeyValuePair(Of String, String) In supportedDocumentFormats
                Console.WriteLine(String.Format("Extension: '{0}'; Document format: '{1}'", supportedDocumentFormat.Key, supportedDocumentFormat.Value))
            Next
            Console.ReadKey()
        End Sub
        ''' <summary>
        ''' Show hidden sheets for Excel files in image representation
        ''' </summary>
        ''' <param name="DocumentName"></param>
        Public Shared Sub RenderWithHiddenSheetsInExcel(DocumentName As [String])
            ' Setup GroupDocs.Viewer config
            Dim config As ViewerConfig = Utilities.GetConfigurations()

            Dim htmlHandler As New ViewerHtmlHandler(config)

            ' File guid
            Dim guid As String = DocumentName

            ' Set html options to show grid lines
            Dim options As New HtmlOptions()
            'do same while using ImageOptions
            options.CellsOptions.ShowHiddenSheets = True

            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid, options)

            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent)
            Next
        End Sub
        ''' <summary>
        ''' create and use file with localized string
        ''' </summary>
        ''' <param name="DocumentName"></param>
        Public Shared Sub RenderWithLocales(DocumentName As [String])
            ' Setup GroupDocs.Viewer config
            Dim config As ViewerConfig = Utilities.GetConfigurations()
            config.LocalesPath = "D:\from office working\for aspose\GroupDocsViewer\GroupDocs.Viewer.Examples\Data\Locale"

            Dim cultureInfo As New CultureInfo("fr-FR")
            Dim htmlHandler As New ViewerHtmlHandler(config, cultureInfo)

            ' File guid
            Dim guid As String = DocumentName

            ' Set html options to show grid lines
            Dim options As New HtmlOptions()

            Dim pages As List(Of PageHtml) = htmlHandler.GetPages(guid, options)

            For Each page As PageHtml In pages
                'Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent)
            Next
        End Sub

#End Region





    End Class



End Namespace

