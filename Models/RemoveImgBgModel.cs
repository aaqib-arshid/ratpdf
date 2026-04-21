using System.ComponentModel.DataAnnotations;

namespace ratpdf.Models
{
    public class RemoveImgBgModel
    {
        [Required(ErrorMessage = "Please select an image file.")]
        public IFormFile File { get; set; }
    }
}
