using System.Collections.Generic;
using PAccountant2.DAL.DBO.Entities.Accounting;
using PAccountant2.DAL.DBO.Entities.Investment;

namespace PAccountant2.DAL.DBO.Entities
{
    public class CurrencyDbo
    {
        public int Id { get; set; }

        public string BaseCurrency { get; set; }

        public string Currency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }

        public ICollection<AccountOperationDbo> AccountOperations { get; set; }

        public ICollection<InvestmentOperationDbo> InvestmentOperations { get; set; }

        public ICollection<AccountingOptionsDbo> AccountingOptions { get; set; }

    }
}
