namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.Migration
{
    public class ExchangeRatesMigrationViewItem
    {
        public int BaseNumber { get; set; }

        public string BaseCurrency { get; set; }

        public int ResultNumber { get; set; }

        public string Currency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }
    }
}
