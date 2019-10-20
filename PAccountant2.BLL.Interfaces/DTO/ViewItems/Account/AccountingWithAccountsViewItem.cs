using System.Collections.Generic;

namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.Account
{
    public class AccountingWithAccountsViewItem
    {
        public int Id { get; set; }

        public decimal Summ { get; set; }

        public IEnumerable<AccountBalanceViewItem> Accounts { get; set; }
    }
}
