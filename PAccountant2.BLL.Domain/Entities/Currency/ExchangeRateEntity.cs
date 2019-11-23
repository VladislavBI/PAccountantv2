namespace PAccountant2.BLL.Domain.Entities.Currency
{
    public class ExchangeRateEntity
    {
        public CurrencyEntity BaseCurrency { get; set; }

        public CurrencyEntity ResultCurrency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }
    }
}
