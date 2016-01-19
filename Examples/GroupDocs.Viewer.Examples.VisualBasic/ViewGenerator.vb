
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
            Dim handler As ViewerHandler = New ViewerHtmlHandler(config)

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

            'Get document pages in image form
            Dim Images As List(Of PageImage) = imageHandler.GetPages(guid, options)

            For Each image As PageImage In Images
                'Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" & DocumentName, image.Stream)
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
                Utilities.SaveAsImage(image.PageNumber & "_" & DocumentName, image.Stream)
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
            Dim imageHandler As New ViewerImageHandler(config)

            ' Guid implies that unique document name 
            Dim guid As String = DocumentName

            'Initialize ImageOptions Object and setting Rotate Transformation
            Dim options As New ImageOptions() With {.Transformations = Transformation.Rotate}

            ' Set password if document is password protected. 
            If Not [String].IsNullOrEmpty(DocumentPassword) Then
                options.Password = DocumentPassword
            End If

            'Call RotatePages to apply rotate transformation to a page
            Utilities.PageTransformations.RotatePages(options, RotationAngle)

            'Get document pages in image form
            Dim Images As List(Of PageImage) = imageHandler.GetPages(guid, options)

            For Each image As PageImage In Images
                'Save each image at disk
                Utilities.SaveAsImage(image.PageNumber & "_" & DocumentName, image.Stream)
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
            Dim handler As ViewerHandler = New ViewerImageHandler(config)

            ' Guid implies that unique document name 
            Dim guid As String = DocumentName


            'Initialize ImageOptions Object and setting Reorder Transformation
            Dim options As New ImageOptions() With {.Transformations = Transformation.Reorder }

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
                Utilities.SaveAsImage(image.PageNumber & "_" & DocumentName, image.Stream)
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
                Utilities.SaveAsImage(image.PageNumber & "_" & Path.GetFileName(DocumentURL.LocalPath), image.Stream)
            Next
            'ExEnd:RenderRemoteDocAsImages
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

            'Initialize PdfFileOptions object
            Dim options As New PdfFileOptions()

            ' Guid implies that unique document name 
            options.Guid = DocumentName

            ' Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            Dim container As FileContainer = imageHandler.GetPdfFile(options)

            'Change the extension of the file and assign to a string type variable filename
            Dim filename As [String] = Path.GetFileNameWithoutExtension(DocumentName) & ".pdf"

            'Save each image at disk
            Utilities.SaveFile(filename, container.Stream)
            'ExEnd:RenderAsPdf

        End Sub

#End Region

        

    End Class



End Namespace

