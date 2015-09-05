using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using GalleryMVC_With_Auth.CustomFilters;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;
using GalleryMVC_With_Auth.Helpers;
using GalleryMVC_With_Auth.Resources;

namespace GalleryMVC_With_Auth.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IPicturesRepository _repository;

        public AdminPanelController(IPicturesRepository repository)
        {
            _repository = repository;
        }

        [AuthLog(Roles = Defines.AdminRole)]
        public ActionResult Index()
        {
            return View();
        }
        [AuthLog(Roles = Defines.AdminRole)]
        public ActionResult Upload()
        {
            ViewBag.alb = new List<Album>();
            foreach (var a in _repository.Albums)
            {
                ViewBag.alb.Add(a);
            }
            return View(_repository);
        }
        [AuthLog(Roles = Defines.AdminRole)]
        [HttpPost]
        public ActionResult Upload(Picture model)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in model.Files)
                {
                    var pic = Path.GetFileName($"{(file.FileName + DateTime.Now.Ticks).GetHashCode()}.jpg");
                    var album = GetAlbumName(model);
                    var pth = $"/Content/images/{album}/{pic}";
                    var path = Server.MapPath($"{pth.Insert(0,"~")}");

                    var tmbpath = Server.MapPath($"{pth.Insert(pth.Length-pic.Length,"tmb/").Insert(0, "~")}");
                    // file is uploaded
                    file.SaveAs(path);

                    ThumbnailCreater.ToTmb(path, tmbpath);

                    //Upload info to DB
                    var p = new Picture
                    {
                        Path = pth,
                        TmbPath = pth.Insert(pth.Length-pic.Length,"tmb/"),
                        Name = model.Name,
                        Description = model.Description,
                        Tag = model.Tag,
                        Category = model.Category,
                        Price = model.Price,
                        AlbumId = model.AlbumId
                    };
                    _repository.PicturesTable.Add(p);
                    _repository.SaveState();
                }
                return RedirectToAction("Upload");
            }
            ViewBag.alb = new List<Album>();
            foreach (var a in _repository.Albums)
            {
                ViewBag.alb.Add(a);
            }
            return View(_repository);
        }

        private string GetAlbumName(Picture pic)
        {
            return _repository.Albums.Where(x => x.Id == pic.AlbumId).Select(x => x.Name).FirstOrDefault();
        }
    }
}