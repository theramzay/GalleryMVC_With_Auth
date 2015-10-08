﻿using System.Linq;
using System.Web.Mvc;
using GalleryMVC_With_Auth.Domain.Abstract;

namespace GalleryMVC_With_Auth.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPicturesRepository _repository;

        public HomeController(IPicturesRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.Albums);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact(string lang = "ru")
        {
            return View();
        }


        public ActionResult Found(string search)
        {
            if (search == "") return View();
            return View("Found",
                search[0] == '#'
                    ? _repository.Pictures.Where(p => p.Tag.Name.Contains(search)).ToList()
                    : _repository.Pictures.Where(p => p.Name.Contains(search)).ToList());
        }
    }
}