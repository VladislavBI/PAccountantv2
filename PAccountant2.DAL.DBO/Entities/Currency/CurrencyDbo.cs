using PAccountant2.DAL.DBO.Entities.Account;
using PAccountant2.DAL.DBO.Entities.Accounting;
using PAccountant2.DAL.DBO.Entities.Investment;
using System.Collections.Generic;
using PAccountant2.DAL.DBO.Entities.Credit;

namespace PAccountant2.DAL.DBO.Entities.Currency
{
    public class CurrencyDbo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public ICollection<AccountOperationDbo> AccountOperations { get; set; }

        public ICollection<InvestmentOperationDbo> InvestmentOperations { get; set; }

        public ICollection<CreditOperationDbo> CreditOperations { get; set; }

        public ICollection<AccountingOptionsDbo> AccountingOptions { get; set; }

        public ICollection<AccountDbo> Accounts { get; set; }

        public ICollection<ExchangeRateDbo> BaseCurrenciesRates { get; set; }

        public ICollection<ExchangeRateDbo> ResultCurrenciesRates { get; set; }

        public ICollection<InvestmentDbo> Investments { get; set; }

    }
}
