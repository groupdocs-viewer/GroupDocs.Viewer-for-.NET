
Imports GroupDocs.Viewer.Domain
Imports GroupDocs.Viewer.Domain.Options
Imports GroupDocs.Viewer.Handler.Input
Imports Microsoft.WindowsAzure.Storage
Imports Microsoft.WindowsAzure.Storage.Auth
Imports Microsoft.WindowsAzure.Storage.Blob
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions

Namespace GroupDocs.Viewer.Examples
    ''' <summary>
    ''' The implementation of GroupDocs.Viewer data handler for Azure Blob Storage.
    ''' </summary>
    Public Class AzureInputDataHandler
        Implements IInputDataHandler
        ''' <summary>
        ''' The blob delimiter.
        ''' </summary>
        Private Const Delimiter As Char = "/"c
        ''' <summary>
        ''' The endpoint template.
        ''' </summary>
        Private Const EndpointTemplate As String = "https://{account-name}.blob.core.windows.net/"
        ''' <summary>
        ''' The cloud blob container.
        ''' </summary>
        Private ReadOnly _container As CloudBlobContainer
        ''' <summary>
        ''' Initializes a new instance of the <see cref="AzureInputDataHandler"/> class.
        ''' </summary>
        ''' <param name="accountName"></param>
        ''' <param name="accountKey"></param>
        ''' <param name="containerName"></param>
        Public Sub New(accountName As String, accountKey As String, containerName As String)
            Me.New(GetEndpoint(accountName), accountName, accountKey, containerName)
        End Sub
        ''' <summary>
        ''' Initializes a new instance of the <see cref="AzureInputDataHandler"/> class.
        ''' </summary>
        ''' <param name="endpoint">The endpoint e.g. https://youraccountname.blob.core.windows.net/ </param>
        ''' <param name="accountName">The account name.</param>
        ''' <param name="accountKey">The account key.</param>
        ''' <param name="containerName">The container name.</param>
        Public Sub New(endpoint As Uri, accountName As String, accountKey As String, containerName As String)
            Try
                Dim storageCredentials As New StorageCredentials(accountName, accountKey)
                Dim cloudStorageAccount As New CloudStorageAccount(storageCredentials, endpoint, Nothing, Nothing, Nothing)
                Dim cloudBlobClient As CloudBlobClient = cloudStorageAccount.CreateCloudBlobClient()
                Dim serverTimeout As System.Nullable(Of TimeSpan) = cloudBlobClient.DefaultRequestOptions.ServerTimeout
                cloudBlobClient.DefaultRequestOptions.ServerTimeout = TimeSpan.FromSeconds(10)
                _container = cloudBlobClient.GetContainerReference(containerName)
                _container.CreateIfNotExists()
                cloudBlobClient.DefaultRequestOptions.ServerTimeout = serverTimeout
            Catch e As StorageException
                Throw New System.Exception("Unable to recognize that Account Name/Account Key or container name is invalid.", e)
            Catch e As FormatException
                Throw New System.Exception("Unable to recognize that Account Name/Account Key.", e)
            End Try
        End Sub
        
        ''' <summary>
        ''' Gets the file description.
        ''' </summary>
        ''' <param name="guid">The unique identifier.</param>
        ''' <returns>GroupDocs.Viewer.Domain.FileDescription.</returns>
        Public Function GetFileDescription(guid As String) As FileDescription Implements IInputDataHandler.GetFileDescription
            Try
                Dim blobName As String = GetNormalizedBlobName(guid)
                Dim blob As CloudBlob = _container.GetBlobReference(blobName)
                blob.FetchAttributes()
                Return New FileDescription(blobName, False) With { _
                    .LastModificationDate = GetDateTimeOrEmptyDate(blob.Properties.LastModified), _
                     .Size = blob.Properties.Length _
                }
            Catch ex As StorageException
                Throw New System.Exception("Unabled to get file description.", ex)
            End Try
        End Function
        Public Function GetFile(guid As String) As Stream Implements IInputDataHandler.GetFile
            Try
                Dim blobName As String = GetNormalizedBlobName(guid)
                Dim blob As CloudBlob = _container.GetBlobReference(blobName)
                Dim memoryStream As New MemoryStream()
                blob.DownloadToStream(memoryStream)
                memoryStream.Position = 0
                Return memoryStream
            Catch ex As StorageException
                Throw New System.Exception("Unabled to get file.", ex)
            End Try
        End Function
        ''' <summary>
        ''' Gets the last modification date.
        ''' </summary>
        ''' <param name="guid">The unique identifier.</param>
        ''' <returns>System.DateTime.</returns>
        Public Function GetLastModificationDate(guid As String) As DateTime Implements IInputDataHandler.GetLastModificationDate
            Dim fileDescription As FileDescription = GetFileDescription(guid)
            Return fileDescription.LastModificationDate
        End Function
       
        ''' <summary>
        ''' Gets the endpoint e.g. https://youraccountname.blob.core.windows.net/
        ''' </summary>
        ''' <param name="accountName">The account name.</param>
        ''' <returns>Endpoint Uri.</returns>
        Private Shared Function GetEndpoint(accountName As String) As Uri
            Dim endpoint As String = EndpointTemplate.Replace("{account-name}", accountName)
            Return New Uri(endpoint)
        End Function
        ''' <summary>
        ''' Gets the file tree.
        ''' </summary>
        ''' <param name="blobName">The blob name.</param>
        ''' <returns>The file tree.</returns>
        Private Function GetFileTree(blobName As String) As List(Of FileDescription)
            Dim directory As CloudBlobDirectory = _container.GetDirectoryReference(blobName)
            Dim fileTree As New List(Of FileDescription)()
            For Each blob As IListBlobItem In directory.ListBlobs()
                Dim fileDescription As FileDescription
                Dim blobDirectory As CloudBlobDirectory = TryCast(blob, CloudBlobDirectory)
                If blobDirectory IsNot Nothing Then
                    fileDescription = New FileDescription(blobDirectory.Prefix, True)
                Else
                    Dim blobFile As ICloudBlob = DirectCast(blob, ICloudBlob)
                    fileDescription = New FileDescription(blobFile.Name, False) With { _
                         .Size = blobFile.Properties.Length, _
                         .LastModificationDate = GetDateTimeOrEmptyDate(blobFile.Properties.LastModified) _
                    }
                End If
                fileTree.Add(fileDescription)
            Next
            Return fileTree
        End Function
        ''' <summary>
        ''' Gets normalized blob name, updates guid from dir\\file.ext to dir/file.ext
        ''' </summary>
        ''' <param name="guid">The unique identifier.</param>
        ''' <returns>Normalized blob name.</returns>
        Private Function GetNormalizedBlobName(guid As String) As String
            Return Regex.Replace(guid, "\\+", Delimiter.ToString()).Trim(Delimiter)
        End Function
        ''' <summary>
        ''' Gets date time or empty date.
        ''' </summary>
        ''' <param name="dateTimeOffset">The date time offset.</param>
        ''' <returns>Date time or empty date.</returns>
        Private Function GetDateTimeOrEmptyDate(dateTimeOffset As System.Nullable(Of DateTimeOffset)) As DateTime
            Dim emptyDate As New DateTime(1, 1, 1)
            Return If(dateTimeOffset.HasValue, dateTimeOffset.Value.DateTime, emptyDate)
        End Function
        Public Sub AddFile(guid As String, content As Stream) Implements IInputDataHandler.AddFile
            'TODO
        End Sub
        Public Function GetEntities(path As String) As List(Of FileDescription) Implements IInputDataHandler.GetEntities
            'TODO
            Return New List(Of FileDescription)()
        End Function
    End Class
End Namespace


