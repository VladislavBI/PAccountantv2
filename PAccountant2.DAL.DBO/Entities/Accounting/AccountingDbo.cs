using PAccountant2.DAL.DBO.Entities.Account;
using PAccountant2.DAL.DBO.Entities.Investment;
using System.Collections.Generic;

namespace PAccountant2.DAL.DBO.Entities.Accounting
{
    public class AccountingDbo
    {
        public int Id { get; set; }

        public UserDbo User { get; set; }

        public string UserEmail { get; set; }

        public ICollection<AccountDbo> Accounts { get; set; }

        public ICollection<InvestmentDbo> Investments { get; set; }

        public AccountingOptionsDbo Options { get; set; }
    }
}
