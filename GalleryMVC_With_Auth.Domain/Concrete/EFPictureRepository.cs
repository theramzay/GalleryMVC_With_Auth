using System.Linq;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Concrete
{
    public class EFPictureRepository : IPicturesRepository
    {
        public Picture Picture { get; }
        public DBcon context { get; set; } = new DBcon();
        public IQueryable<Album> Albums => context.Albums;
        public IQueryable<Picture> Pictures => context.Pictures;
    }
}