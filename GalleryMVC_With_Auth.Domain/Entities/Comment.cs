namespace GalleryMVC_With_Auth.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
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
