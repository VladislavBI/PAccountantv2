using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountingWithAccountsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Sum cann't be negative")]
        public decimal Summ { get; set; }

        public IEnumerable<AccountBalanceViewModel> Accounts { get; set; }
    }
}
