using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalleryMVC_With_Auth.Domain.Entities.Backup
{
    public class Album
    {
        public Album()
        {
            Pictures = new HashSet<Picture>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string Link { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}