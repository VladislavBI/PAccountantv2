using System.Collections.Generic;

namespace PAccountant2.DAL.DBO.Entities
{
    public class AccountDbo
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public AccountingDbo Accounting { get; set; }

        public int AccountingId { get; set; }

        public ICollection<AccountOperationDbo> AccountHistory { get; set; }
    }
}
