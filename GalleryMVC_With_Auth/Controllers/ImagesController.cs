using System.Linq;
using System.Web.Mvc;
using GalleryMVC_With_Auth.Domain.Abstract;

namespace GalleryMVC_With_Auth.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IPicturesRepository _repository;

        public ImagesController(IPicturesRepository repository)
        {
            _repository = repository;
        }

        // GET: Images
        public ActionResult Painting()
        {
            return View(_repository.Pictures.Where(p => p.Category == "Живопись" || p.Category == "zivopis"));
        }

        public ActionResult Watercolor()
        {
            return View(_repository.Pictures.Where(p => p.Category == "Акварель" || p.Category == "akvarel"));
        }

        public ActionResult Gouache()
        {
            return View();
        }

        public ActionResult Graphics()
        {
            return View();
        }

        public ActionResult Batik()
        {
            return View(_repository.Pictures.Where(p => p.Category == "Батик" || p.Category == "batik"));
        }

        public ActionResult Pastel()
        {
            return View(_repository.Pictures.Where(p => p.Category == "Пастель" || p.Category == "pastel"));
        }
    }
}