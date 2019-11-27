using System.Collections.Generic;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Account
{
    public class AccountingWithAccountsDataItem
    {
        public int Id { get; set; }

        public decimal Summ { get; set; }

        public IEnumerable<AccountBalanceDataItem> Accounts { get; set; }
    }
}
