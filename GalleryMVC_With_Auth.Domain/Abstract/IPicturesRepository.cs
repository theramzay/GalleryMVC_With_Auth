using System.Linq;
using GalleryMVC_With_Auth.Domain.Concrete;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Abstract
{
    public interface IPicturesRepository
    {
        IQueryable<Album> Albums { get; }
        IQueryable<Picture> Pictures { get; }
        Picture Picture { get; }
        DBcon context { get; set; }
    }
}