using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GalleryMVC_With_Auth.Domain.Entities
{
    public class Album
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            Pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public string ImgPath { get; set; }

        public string Link { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}