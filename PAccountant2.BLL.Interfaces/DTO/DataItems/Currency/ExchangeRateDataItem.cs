namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Currency
{
    public class ExchangeRateDataItem
    {
        public CurrencyDataItem BaseCurrency { get; set; }

        public int BaseCurrencyId { get; set; }

        public CurrencyDataItem ResultCurrency { get; set; }

        public int ResultCurrencyId { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }

    }
}
