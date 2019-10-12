using System.ComponentModel.DataAnnotations;

namespace PAccountant2.Host.Domain.ViewModels.Authentification
{
    public class RegistrationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password should be equal")]
        public string PasswordAgain { get; set; }
    }
}
