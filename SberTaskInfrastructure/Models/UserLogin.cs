using System.ComponentModel.DataAnnotations;

namespace SberTaskInfrastructure.Models
{
    public class UserLogin
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
