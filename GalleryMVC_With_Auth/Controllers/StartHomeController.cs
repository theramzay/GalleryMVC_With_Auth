using System.Web.Mvc;

namespace GalleryMVC_With_Auth.Controllers
{
    public class StartHomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "О сайте.";

            return View();
        }

        //[HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Наши контакты.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string lang)
        {
            ViewBag.Message = "Наши контакты.";
            return View(model:lang);
        }
    }
}