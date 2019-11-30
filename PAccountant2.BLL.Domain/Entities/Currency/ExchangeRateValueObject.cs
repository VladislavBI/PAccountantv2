namespace PAccountant2.BLL.Domain.Entities.Currency
{
    public class ExchangeRateValueObject
    {
        public int BaseCurrencyId { get; set; }

        public int ResultCurrencyId { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }
    }
}
