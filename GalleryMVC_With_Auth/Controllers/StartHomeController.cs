using System.Linq;
using System.Web.Mvc;
using GalleryMVC_With_Auth.Domain.Abstract;

namespace GalleryMVC_With_Auth.Controllers
{
    public class StartHomeController : Controller
    {
        private readonly IPicturesRepository _repository;

        public StartHomeController(IPicturesRepository repository)
        {
            _repository = repository;
        }
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

        
        public ActionResult Found(string search)
        {
            if (search == "") return View();
            return View("Found", search[0] == '#' ? _repository.Pictures.Where(p => p.Tag.Contains(search)) : _repository.Pictures.Where(p => p.Name.Contains(search)));
        }
    }
}