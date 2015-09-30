using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Concrete
{
    public class DBcon : DbContext, IPicturesRepository
    {
        public DbSet<Picture> PicturesTable { get; set; }
        public DbSet<Album> AlbumsTable { get; set; }
        public Picture Picture { get; }
        public IQueryable<Album> Albums => AlbumsTable;
        public IQueryable<Picture> Pictures => PicturesTable;

        public void SaveImagesToDb(List<Picture> pList)
        {
            foreach (Picture pic in pList)
            {
                PicturesTable.Add(pic);
            }
            SaveChanges();
        }
    }
}