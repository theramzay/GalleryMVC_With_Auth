using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryMVC_With_Auth.Domain.Entities
{
    public class Picture
    {
        public int ImgId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
