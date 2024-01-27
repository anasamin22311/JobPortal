using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain.Auth
{
    public class AuthModel
    {
        public bool IsAuthenticated { get; set; }
        public string? Message { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        [Required]
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
