namespace GalleryMVC_With_Auth.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Picture
    {
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

        [Required]
        [StringLength(50)]
        public string Tag { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        public decimal Price { get; set; }

        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
