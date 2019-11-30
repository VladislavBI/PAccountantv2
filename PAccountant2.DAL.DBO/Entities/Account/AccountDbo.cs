using PAccountant2.DAL.DBO.Entities.Accounting;
using System.Collections.Generic;
using PAccountant2.DAL.DBO.Entities.Currency;

namespace PAccountant2.DAL.DBO.Entities.Account
{
    public class AccountDbo
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public AccountingDbo Accounting { get; set; }

        public int AccountingId { get; set; }

        public string Name { get; set; }

        public CurrencyDbo Currency { get; set; }

        public int CurrencyId { get; set; }

        public ICollection<AccountOperationDbo> AccountHistory { get; set; }

    }
}
