using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GalleryMVC_With_Auth.Domain.Entities
{
    public class Tag
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tag()
        {
            Pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}