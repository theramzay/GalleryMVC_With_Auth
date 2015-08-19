using System.Linq;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Concrete
{
    public class EFPictureRepository : IPicturesRepository
    {
        private DBcon DB = new DBcon();

        public DBcon context
        {
            get { return DB; }
            set { DB = value; }
        }

        public IQueryable<Album> Albums => context.Albums;
        public IQueryable<Picture> Pictures => context.Pictures;
    }
}