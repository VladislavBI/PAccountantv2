namespace PAccountant2.DAL.DBO.Entities
{
    public class CurrencyDbo
    {
        public int Id { get; set; }

        public string BaseCurrency { get; set; }

        public string Currency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }
    }
}
