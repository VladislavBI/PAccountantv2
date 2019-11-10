namespace CurrenctyRateUtil.Models
{
    public class SimpleRateModel
    {
        public string BaseCurrency { get; set; }

        public string Currency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }
    }
}
