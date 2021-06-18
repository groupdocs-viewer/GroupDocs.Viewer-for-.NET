namespace GroupDocs.Viewer.WebForms.Products.Viewer.Cache
{
    interface ICustomViewer
    {
        GroupDocs.Viewer.Viewer GetViewer();

        void CreateCache();
    }
}