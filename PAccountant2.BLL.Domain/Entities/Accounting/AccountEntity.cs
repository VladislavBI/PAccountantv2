using PAccountant2.BLL.Domain.Enum;
using PAccountant2.BLL.Domain.Exceptions.Account;
using System.Collections.Generic;

namespace PAccountant2.BLL.Domain.Entities.Accounting
{
    public class AccountEntity
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public IEnumerable<AccountOperationValueObject> AccountOperations { get; set; }

        public AccountHistoryValueObject CreateAccountHistory()
        {
            return new AccountHistoryValueObject
            {
                AccountOperations = AccountOperations
            };
        }
        public void AddMoney(decimal addModelAmount)
        {
            Amount += addModelAmount;

            CreateAccountOperation(addModelAmount, AccountBalanceChangeType.Put);
        }

        public void WithdrawMoney(decimal withdrawAmount)
        {
            CheckIsOperationAvailable(withdrawAmount);

            Amount -= withdrawAmount;

            CreateAccountOperation(withdrawAmount, AccountBalanceChangeType.Withdraw);
        }

        public void CheckIsOperationAvailable(decimal withdrawAmount)
        {
            if (!IsOperationAvailable(withdrawAmount))
            {
                throw new NotEnoughMoneyException();
            }
        }

        public void CheckIsDeletePossible()
        {
            if (Amount > 0)
            {
                throw new CanNotDeleteException(CanNotDeleteReasons.NotNullBalance);
            }
        }
        private bool IsOperationAvailable(decimal neededAmount)
            => Amount >= neededAmount;

        private void CreateAccountOperation(decimal amount, AccountBalanceChangeType operationType)
        {
            var history = CreateAccountHistory();
            history.AddOperation(amount, operationType);
            AccountOperations = history.AccountOperations;
        }
    }
}
