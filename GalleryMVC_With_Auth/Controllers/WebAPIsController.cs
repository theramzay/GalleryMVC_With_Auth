using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Models;

namespace GalleryMVC_With_Auth.Controllers
{
    public class WebAPIsController : ApiController
    {
        private readonly IPicturesRepository _repository;

        public WebAPIsController(IPicturesRepository repository)
        {
            _repository = repository;
        }

        public List<AlbumModel> GetAlbums()
        {
            return
                _repository.Albums.Select(
                    a =>
                        new AlbumModel
                        {
                            Id = a.Id,
                            Description = a.Description,
                            ImgPath = a.ImgPath,
                            Link = a.Link,
                            Name = a.Name
                        }).ToList();
        }

        public string Get()
        {
            return "U in web api controller!";
        }

        public List<PictureModel> GetFound(string search)
        {
            if (search !=null)
            {
                return search[0] == '#'
    ? _repository.Pictures.Where(p => p.Tag.Name.Contains(search))
        .Select(
            p =>
                new PictureModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Path = p.Path,
                    TmbPath = p.TmbPath
                })
        .ToList()
    : _repository.Pictures.Where(p => p.Name.Contains(search))
        .Select(
            p =>
                new PictureModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Path = p.Path,
                    TmbPath = p.TmbPath
                })
        .ToList();
            }
            return new List<PictureModel>();

        }
    }
}