using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GalleryMVC_With_Auth.Domain.Entities
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public string TmbPath { get; set; }

        [Required(ErrorMessage = "Требуется ввести имя.")]
        [Display(Name = "Имя")]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Требуется ввести описание.")]
        [Display(Name = "Описание")]
        [StringLength(50)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Требуется ввести #тэг.")]
        [Display(Name = "Тэг")]
        [StringLength(50)]
        public string Tag { get; set; }

        [Required(ErrorMessage = "Требуется ввести категорию.")]
        [Display(Name = "Категория")]
        [StringLength(50)]
        public string Category { get; set; }

        [Required(ErrorMessage = "Требуется ввести цену.")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public HttpPostedFileBase[] Files { get; set; }
    }
}