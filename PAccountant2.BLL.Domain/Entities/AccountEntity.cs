namespace PAccountant2.BLL.Domain.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }

        public float Amount { get; set; }

        public void AddMoney(float addModelAmount)
        {
            Amount += addModelAmount;
        }
    }
}
