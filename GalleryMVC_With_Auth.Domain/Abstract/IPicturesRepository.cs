using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Abstract
{
    public interface IPicturesRepository
    {
        DbSet<Picture> PicturesTable { get; set; }
        DbSet<Album> AlbumsTable { get; set; }
        IQueryable<Album> Albums { get; }
        IQueryable<Picture> Pictures { get; }
        Picture Picture { get; }
        void SaveImagesToDb(List<Picture> pList);
    }
}