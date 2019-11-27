using System;
using PAccountant2.BLL.Domain.Exceptions.Account;

namespace PAccountant2.BLL.Domain.Entities.Account.Handlers
{
    public class TransactionHandler
    {
        public decimal PerformPutTransaction(TransactionValueObject transaction)
        {
            if (transaction == null)
            {
                throw new NullReferenceException("no transaction were sent");
            }

            var newAmount = transaction.CurrentAmount + transaction.AmountForTransfer;

            return newAmount;
        }

        public decimal PerformWithdrawTransaction(TransactionValueObject transaction)
        {
            if (transaction == null)
            {
                throw new NullReferenceException("no transaction were sent");
            }

            decimal newAmount;

            if (IsWithdrawTransactionAvailable(transaction))
            {
                newAmount = transaction.CurrentAmount - transaction.AmountForTransfer;
            }
            else
            {
                throw new NotEnoughMoneyException();
            }

            return newAmount;
        }

        private bool IsWithdrawTransactionAvailable(TransactionValueObject transaction)
            => transaction.CurrentAmount >= transaction.AmountForTransfer;

    }
}
