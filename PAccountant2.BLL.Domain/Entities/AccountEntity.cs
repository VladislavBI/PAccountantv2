namespace PAccountant2.BLL.Domain.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public void AddMoney(decimal addModelAmount)
        {
            Amount += addModelAmount;
        }
    }
}
