﻿using System.Data.Entity;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Concrete
{
    internal class DBcon : DbContext
    {
        public DbSet<Picture> Pictures { get; set; }
    }
}