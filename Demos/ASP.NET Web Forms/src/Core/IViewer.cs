﻿using System.Threading.Tasks;
using GroupDocs.Viewer.AspNetWebForms.Core.Entities;

namespace GroupDocs.Viewer.AspNetWebForms.Core
{
    public interface IViewer
    {
        string PageExtension { get; }
        Page CreatePage(int pageNumber, byte[] data);
        Task<DocumentInfo> GetDocumentInfoAsync(FileCredentials fileCredentials);
        Task<Page> GetPageAsync(FileCredentials fileCredentials, int pageNumber);
        Task<Pages> GetPagesAsync(FileCredentials fileCredentials, int[] pageNumbers);
        Task<byte[]> GetPdfAsync(FileCredentials fileCredentials);
        Task<byte[]> GetPageResourceAsync(FileCredentials fileCredentials, int pageNumber, string resourceName);
    }
}