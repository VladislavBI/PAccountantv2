using PAccountant2.BLL.Domain.Exceptions.Account;

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

        public void WithdrawMoney(decimal withdrawAmount)
        {
            if (!IsOperationAvailable(withdrawAmount))
            {
                throw new NotEnoughMoneyException();
            }

            Amount -= withdrawAmount;
        }

        public bool IsOperationAvailable(decimal neededAmount)
            => Amount >= neededAmount;
    }
}
