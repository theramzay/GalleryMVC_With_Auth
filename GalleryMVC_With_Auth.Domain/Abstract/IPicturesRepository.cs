using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Domain.Abstract
{
    public interface IPicturesRepository
    {
        IQueryable<Picture> Pictures { get; }
    }
}
