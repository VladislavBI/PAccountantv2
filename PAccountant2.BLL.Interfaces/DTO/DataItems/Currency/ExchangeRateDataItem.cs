namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Currency
{
    public class ExchangeRateDataItem
    {
        public CurrencyDataItem BaseCurrency { get; set; }

        public CurrencyDataItem ResultCurrency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }

    }
}
