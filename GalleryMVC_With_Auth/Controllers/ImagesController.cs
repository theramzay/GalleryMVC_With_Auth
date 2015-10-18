using System.Linq;
using System.Web.Mvc;
using GalleryMVC_With_Auth.CustomFilters;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;
using GalleryMVC_With_Auth.Models;
using GalleryMVC_With_Auth.Resources;
using Microsoft.AspNet.Identity;

namespace GalleryMVC_With_Auth.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IPicturesRepository _repository;

        public ImagesController(IPicturesRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Universal(int Id)
        {
            return View(_repository.Pictures.Where(p => p.AlbumId == Id).ToList());
        }

        [MultiAuth(UserRoles.User,UserRoles.Administrator)]
        public ActionResult Comments(int Id)
        {
            return View(_repository.Comments.Where(c => c.PictureID == Id).ToList());
        }

        //[AuthLog(Roles = Defines.Roles)]
        [MultiAuth(UserRoles.User, UserRoles.Administrator)]
        [HttpPost]
        public ActionResult Comments(CommentModel comm, int Id)
        {
            if (!ModelState.IsValid) return View(_repository.Comments.Where(c => c.PictureID == Id).ToList());
            _repository.SendComment(new Comment {PictureID = Id, UserId = User.Identity.GetUserId(), Text = comm.Text});
            return View(_repository.Comments.Where(c => c.PictureID == Id).ToList());
        }
    }
}