namespace PAccountant2.BLL.Domain.Entities
{
    public class CurrencyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Buy { get; set; }

        public decimal Sale { get; set; }

    }
}
