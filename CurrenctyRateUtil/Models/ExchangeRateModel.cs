namespace CurrenctyRateUtil.Models
{
    public class ExchangeRateModel
    {
        public int BaseCurrencyId { get; set; }

        public int ResultCurrencyId { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }
    }
}
