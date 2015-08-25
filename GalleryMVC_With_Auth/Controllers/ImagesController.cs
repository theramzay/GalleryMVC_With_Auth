﻿using System.Linq;
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
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == 3));
        }

        public ActionResult Watercolor()
        {
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == 5));
        }

        public ActionResult Gouache()
        {
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == 6));
        }

        public ActionResult Graphics()
        {
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == 1));
        }

        public ActionResult Batik()
        {
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == 2));
        }

        public ActionResult Pastel()
        {
            return View(_repository.Pictures.Where(p => p.AlbumAlbId == 4));
        }

        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(string type,string value)
        {
            switch (type)
            {
                case "Имя":
                    return View("Found", _repository.Pictures.Where(p => p.Name.Contains(value)));
                case "Тэг":
                    return View("Found", _repository.Pictures.Where(p => p.Tag.Contains(value)));
                case "Категория":
                    return View("Found", _repository.Pictures.Where(p => p.Category.Contains(value)));
                default:
                    return View("Found", _repository.Pictures.Where(p => p.Name.Contains(value)));
            }
        }
    }
}