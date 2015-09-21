using System.Web;

namespace GalleryMVC_With_Auth.Models
{
    public class PictureModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string TmbPath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }

        public string Category { get; set; }
        public decimal Price { get; set; }

        public int AlbumId { get; set; }
        public HttpPostedFileBase[] Files { get; set; }
    }
}