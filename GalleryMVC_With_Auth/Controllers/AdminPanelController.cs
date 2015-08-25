using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using GalleryMVC_With_Auth.CustomFilters;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;
using GalleryMVC_With_Auth.Helpers;

namespace GalleryMVC_With_Auth.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IPicturesRepository _repository;

        public AdminPanelController(IPicturesRepository repository)
        {
            _repository = repository;
        }
        [AuthLog(Roles = "Administrator")]
        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }
        [AuthLog(Roles = "Administrator")]
        public ActionResult Upload()
        {
            ViewBag.alb = new List<Album>();
            foreach (var a in _repository.Albums)
            {
                ViewBag.alb.Add(a);
            }
            return View(_repository);
        }
        [AuthLog(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Upload(Picture model)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in model.Files)
                {
                    var pic = Path.GetFileName($"{(file.FileName + DateTime.Now.Ticks).GetHashCode()}.jpg");
                    var path = Path.Combine(
                        Server.MapPath(
                            $"~/Content/images/{_repository.Albums.Where(x => x.AlbId == model.AlbumAlbId).Select(x => x.Name).FirstOrDefault()}/"),
                        pic);
                    var tmbpath = Path.Combine(
                        Server.MapPath(
                            $"~/Content/images/{_repository.Albums.Where(x => x.AlbId == model.AlbumAlbId).Select(x => x.Name).FirstOrDefault()}/tmb"),
                        pic);
                    // file is uploaded
                    file.SaveAs(path);

                    ThumbnailCreater.ToTmb(path, tmbpath);

                    //Upload info to DB
                    var p = new Picture
                    {
                        Path =
                            $"/Content/images/{_repository.Albums.Where(x => x.AlbId == model.AlbumAlbId).Select(x => x.Name).FirstOrDefault()}/{pic}",
                        TmbPath =
                            $"/Content/images/{_repository.Albums.Where(x => x.AlbId == model.AlbumAlbId).Select(x => x.Name).FirstOrDefault()}/tmb/{pic}",
                        Name = model.Name,
                        Description = model.Description,
                        Tag = model.Tag,
                        Category = model.Category,
                        Price = model.Price,
                        AlbumAlbId = model.AlbumAlbId
                    };
                    _repository.context.Pictures.Add(p);
                    _repository.context.SaveChanges();
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
    }
}