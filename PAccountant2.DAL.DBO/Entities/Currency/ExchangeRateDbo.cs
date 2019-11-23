using System.Collections.Generic;
using PAccountant2.DAL.DBO.Entities.Accounting;
using PAccountant2.DAL.DBO.Entities.Investment;

namespace PAccountant2.DAL.DBO.Entities.Currency
{
    public class ExchangeRateDbo
    {
        public int Id { get; set; }

        public int BaseCurrencyId { get; set; }

        public CurrencyDbo BaseCurrency { get; set; }

        public int ResultCurrencyId { get; set; }

        public CurrencyDbo ResultCurrency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }

    }
}
