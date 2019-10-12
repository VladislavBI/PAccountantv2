using System.ComponentModel.DataAnnotations;

namespace PAccountant2.Host.Domain.ViewModels.Authentification
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
