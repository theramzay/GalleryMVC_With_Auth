using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Concrete
{
    class DBcon : DbContext
    {
        public DbSet<Picture> Pictures { get; set; }
    }
}
