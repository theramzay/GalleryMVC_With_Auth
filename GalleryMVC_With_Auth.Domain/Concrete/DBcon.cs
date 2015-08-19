using System.Data.Entity;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Concrete
{
    public class DBcon : DbContext
    {
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}