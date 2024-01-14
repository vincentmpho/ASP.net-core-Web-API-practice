using System.ComponentModel.DataAnnotations;

namespace Walk_and_Trails_of_SA_API.Models.DTO
{
    public class ImageUploadRequestDto
    {
        public IFormFile File { get; set; }

        [Required]
        public string FileName { get; set; }

        public string? FileDescription { get; set; }
    }
}
