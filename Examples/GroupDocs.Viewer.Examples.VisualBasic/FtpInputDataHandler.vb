
Imports GroupDocs.Viewer.Domain
Imports GroupDocs.Viewer.Domain.Options
Imports GroupDocs.Viewer.Handler.Input
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Text

Namespace GroupDocs.Viewer.Examples
    Public Class FtpInputDataHandler
        Implements IInputDataHandler
        Private Const _server As String = "ftp://localhost"
        Private Const _userName As String = "anonymous"
        Private Const _userPassword As String = ""


        Public Function GetFileDescription(guid As String) As FileDescription Implements IInputDataHandler.GetFileDescription
            Return New FileDescription(guid)
        End Function

        Public Function GetFile(guid As String) As Stream Implements IInputDataHandler.GetFile
            Dim uri As Uri = GetUriFromGuid(guid)
            Dim request As FtpWebRequest = GetFtpRequest(uri, WebRequestMethods.Ftp.DownloadFile)

            Dim reader As Stream = request.GetResponse().GetResponseStream()
            Dim result As New MemoryStream()

            Dim bytesRead As Integer = 0
            Dim buffer As Byte() = New Byte(2047) {}
            While True
                bytesRead = reader.Read(buffer, 0, buffer.Length)

                If bytesRead = 0 Then
                    Exit While
                End If

                result.Write(buffer, 0, bytesRead)
            End While

            Return result
        End Function

        Public Function GetLastModificationDate(guid As String) As DateTime Implements IInputDataHandler.GetLastModificationDate
            Dim uri As Uri = GetUriFromGuid(guid)
            Dim request As FtpWebRequest = GetFtpRequest(uri, WebRequestMethods.Ftp.GetDateTimestamp)

            Using response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
                Return response.LastModified
            End Using
        End Function

        Public Function LoadFileTree(fileTreeOptions As FileTreeOptions) As List(Of FileDescription) Implements IInputDataHandler.LoadFileTree
            Dim uri__1 As Uri = If(Uri.IsWellFormedUriString(fileTreeOptions.Path, UriKind.Absolute), New Uri(fileTreeOptions.Path), GetUriFromGuid(fileTreeOptions.Path))
            Dim request As FtpWebRequest = GetFtpRequest(uri__1, WebRequestMethods.Ftp.ListDirectory)

            Dim result As New List(Of FileDescription)()

            Using response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
                Dim responseStream As Stream = response.GetResponseStream()

                If responseStream IsNot Nothing Then
                    Using reader As New StreamReader(responseStream)
                        Dim guid As String
                        While (InlineAssignHelper(guid, reader.ReadLine())) IsNot Nothing
                            result.Add(New FileDescription(guid, Not guid.Contains(".")))
                        End While
                    End Using
                End If
            End Using

            Return result
        End Function

        Private Function GetUriFromGuid(guid As String) As Uri
            Return If(Uri.IsWellFormedUriString(guid, UriKind.Absolute), New Uri(guid), New Uri(String.Format("{0}/{1}", _server, guid)))
        End Function

        Private Function GetFtpRequest(uri As Uri, method As String) As FtpWebRequest
            Dim request As FtpWebRequest = DirectCast(WebRequest.Create(uri), FtpWebRequest)
            request.Credentials = New NetworkCredential(_userName, _userPassword)
            request.Method = method
            Return request
        End Function
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Namespace

