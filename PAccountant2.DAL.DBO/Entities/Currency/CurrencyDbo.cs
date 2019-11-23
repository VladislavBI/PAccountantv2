using System.Collections.Generic;
using PAccountant2.DAL.DBO.Entities.Accounting;
using PAccountant2.DAL.DBO.Entities.Investment;

namespace PAccountant2.DAL.DBO.Entities.Currency
{
    public class CurrencyDbo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public ICollection<AccountOperationDbo> AccountOperations { get; set; }

        public ICollection<InvestmentOperationDbo> InvestmentOperations { get; set; }

        public ICollection<AccountingOptionsDbo> AccountingOptions { get; set; }

        public ICollection<ExchangeRateDbo> BaseCurrenciesRates { get; set; }

        public ICollection<ExchangeRateDbo> ResultCurrenciesRates { get; set; }

    }
}
