using System.ComponentModel.DataAnnotations;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountBalanceViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Money amount cann't be negative")]
        public decimal Amount { get; set; }
    }
}
