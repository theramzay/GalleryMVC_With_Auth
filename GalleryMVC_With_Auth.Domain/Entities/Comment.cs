using System.ComponentModel.DataAnnotations;

namespace GalleryMVC_With_Auth.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual AspNetUser User { get; set; }

        [Required]
        public int? PictureID { get; set; }

        public virtual Picture Picture { get; set; }

        [Required]
        [StringLength(255)]
        public string Text { get; set; }
    }
}