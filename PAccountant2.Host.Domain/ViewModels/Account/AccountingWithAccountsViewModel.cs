using System.Collections.Generic;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountingWithAccountsViewModel
    {
        public int Id { get; set; }

        public decimal Summ { get; set; }

        public IEnumerable<AccountBalanceViewModel> Accounts { get; set; }
    }
}
