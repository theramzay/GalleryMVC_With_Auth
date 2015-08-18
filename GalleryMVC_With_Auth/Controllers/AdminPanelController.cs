using System.Web.Mvc;

namespace GalleryMVC_With_Auth.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }
    }
}