using System.Collections.Generic;

namespace CurrenctyRateUtil.Models
{
    public class CurrencyConvertModel
    {
        public int BaseCurrencyId { get; set; }

        public int ResultCurrencyId { get; set; }

        public decimal Amount { get; set; }

        public IEnumerable<ExchangeRateModel> Rates { get; set; }
    }
}
