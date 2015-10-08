using System.ComponentModel.DataAnnotations;

namespace GalleryMVC_With_Auth.Domain.Entities
{
    public class Comment
    {
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(128)]
        public string PictureID { get; set; }

        [Required]
        [StringLength(255)]
        public string Text { get; set; }
    }
}