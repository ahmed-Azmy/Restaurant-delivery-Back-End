using System.ComponentModel.DataAnnotations;

namespace Restaurant.APIs.DTOs
{
    public class RegisterDto
    {
        [Required]
        [RegularExpression("^[a-zA-Z]*$" , ErrorMessage ="Username must consist of letters only and no spaces")]
        [MinLength(3 , ErrorMessage ="Min Length Is 3 letters")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
