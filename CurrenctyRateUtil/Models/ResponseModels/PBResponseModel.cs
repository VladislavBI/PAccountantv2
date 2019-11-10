using System;
using System.Collections.Generic;

namespace CurrenctyRateUtil.Models.ResponseModels
{
    class PBResponseModel
    {
        public DateTime Date { get; set; }

        public string Bank { get; set; }

        public int BaseCurrency { get; set; }

        public string BaseCurrencyLit { get; set; }

        public IEnumerable<PBExchangeRate> ExchangeRate { get; set; }
    }

    class PBExchangeRate
    {
        public string BaseCurrency { get; set; }

        public string Currency { get; set; }

        public float SaleRateNB { get; set; }

        public float PurchaseRateNB { get; set; }

        public float SaleRate { get; set; }

        public float PurchaseRate { get; set; }

    }
}
