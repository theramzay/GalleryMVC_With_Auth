using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalleryMVC_With_Auth.Domain.Entities
{
    public class Picture
    {

        public Picture()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public string TmbPath { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? TagId { get; set; }

        public virtual Tag Tag { get; set; }

        public decimal Price { get; set; }

        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}