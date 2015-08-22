using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalleryMVC_With_Auth.Domain.Entities
{
    public class Album
    {
        public Album()
        {
            Pictures = new HashSet<Picture>();
        }

        [Key]
        public int AlbId { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}