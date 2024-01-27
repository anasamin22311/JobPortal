using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain.Auth
{
    public class LoginModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }


    }

}
