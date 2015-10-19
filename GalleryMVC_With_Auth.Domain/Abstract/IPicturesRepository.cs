using System.Collections.Generic;
using System.Data.Entity;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Abstract
{
    public interface IPicturesRepository
    {
        DbSet<Album> Albums { get; }
        DbSet<Picture> Pictures { get; }
        DbSet<Tag> Tags { get; }
        DbSet<Comment> Comments { get; }
        Picture Picture { get; }
        void SaveImagesToDb(List<Picture> pList);
        void Save();
        void SendComment(Comment comm);
    }
}