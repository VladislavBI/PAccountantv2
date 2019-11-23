using System.Collections.Generic;
using PAccountant2.DAL.DBO.Entities.Investment;

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
