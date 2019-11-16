namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.Migration
{
    public class CurrencyMigrationViewItem
    {
        public string BaseCurrency { get; set; }

        public string Currency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }
    }
}
