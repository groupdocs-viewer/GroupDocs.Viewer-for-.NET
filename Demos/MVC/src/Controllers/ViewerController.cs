using System.Web.Mvc;

namespace GroupDocs.Viewer.MVC.Controllers
{
    /// <summary>
    /// Viewer Web page controller.
    /// </summary>
    public class ViewerController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}