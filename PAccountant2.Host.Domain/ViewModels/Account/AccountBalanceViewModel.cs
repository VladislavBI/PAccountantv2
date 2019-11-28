using System.ComponentModel.DataAnnotations;
using PAccountant2.Common.Constants;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountBalanceViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Money amount cann't be negative")]
        public decimal Amount { get; set; }
        
        [MaxLength(StringLengthConsts.NameLength)]
        public string Name { get; set; }

        [Required]
        public int CurrencyId { get; set; }
    }
}
