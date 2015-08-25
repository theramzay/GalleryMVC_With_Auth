using System.Linq;
using System.Web.Mvc;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Resources;

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
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == Defines.Painting));
        }

        public ActionResult Watercolor()
        {
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == Defines.Watercolor));
        }

        public ActionResult Gouache()
        {
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == Defines.Gouache));
        }

        public ActionResult Graphics()
        {
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == Defines.Graphics));
        }

        public ActionResult Batik()
        {
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == Defines.Batik));
        }

        public ActionResult Pastel()
        {
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == Defines.Pastel));
        }
    }
}