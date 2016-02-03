using GroupDocs.Viewer;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Apply product license.
            License lic = new License();
            lic.SetLicense(@"D:\GroupDocs.Viewer.lic");
            return View();
        }
    }
}