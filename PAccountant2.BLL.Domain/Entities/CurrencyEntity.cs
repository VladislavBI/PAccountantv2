namespace PAccountant2.BLL.Domain.Entities
{
    public class CurrencyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Purchase { get; set; }

        public decimal Sale { get; set; }

    }
}
