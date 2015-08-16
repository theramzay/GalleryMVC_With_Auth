using System.Linq;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Concrete
{
    public class EFPictureRepository : IPicturesRepository
    {
        private readonly DBcon context = new DBcon();
        public IQueryable<Picture> Pictures => context.Pictures;
    }
}