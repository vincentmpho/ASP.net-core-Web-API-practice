using System.ComponentModel.DataAnnotations;

namespace Walk_and_Trails_of_SA_API.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
