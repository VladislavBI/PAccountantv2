using System.ComponentModel.DataAnnotations;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountTransferViewModel
    {
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount cann't be negative")]
        public decimal Amount { get; set; }

        [Required]
        public int IdAccountForTranser { get; set; }
    }
}
