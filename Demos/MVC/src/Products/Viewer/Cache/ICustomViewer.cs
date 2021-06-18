using GroupDocs.Viewer.Results;

namespace GroupDocs.Viewer.MVC.Products.Viewer.Cache
{
    interface ICustomViewer
    {
        GroupDocs.Viewer.Viewer GetViewer();

        void CreateCache();

        ViewInfo GetViewInfo();
    }
}