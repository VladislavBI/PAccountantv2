namespace PAccountant2.BLL.Domain.Entities.Migration.Currency
{
    public class CurrencyIncomeValueObject
    {
        public string BaseCurrency { get; set; }

        public int BaseCode { get; set; }
        public int ResultCode { get; set; }

        public string Currency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }
    }
}
