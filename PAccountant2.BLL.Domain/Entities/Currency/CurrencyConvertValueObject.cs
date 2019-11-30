using System.Collections.Generic;

namespace PAccountant2.BLL.Domain.Entities.Currency
{
    public class CurrencyConvertValueObject
    {
        public int BaseCurrencyId { get; set; }

        public int ResultCurrencyId { get; set; }

        public decimal Amount { get; set; }

        public IEnumerable<ExchangeRateValueObject> Rates { get; set; }
    }
}
