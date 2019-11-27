using PAccountant2.BLL.Domain.Enum;
using System;

namespace PAccountant2.BLL.Domain.Entities.Account.Handlers
{
    public class AccountFactory
    {
        public TransactionValueObject CreateTransactionValueObject(decimal amountForTransaction, decimal currentAmount)
        {
            return new TransactionValueObject
            {
                AmountForTransfer = amountForTransaction,
                CurrentAmount = currentAmount
            };
        }

        public AccountOperationValueObject CreateOperationValueObject
            (decimal operationAmount, int operationType, DateTime operationDate, int operationId = 0)
        {
            var operationTypeEnum = System.Enum.Parse<AccountBalanceChangeType>(operationType.ToString());

            var newOperation = CreateOperationValueObject(operationAmount, operationTypeEnum, operationDate, operationId);

            return newOperation;
        }

        public AccountOperationValueObject CreateOperationValueObject
            (decimal operationAmount, AccountBalanceChangeType operationTypeEnum, DateTime operationDate, int operationId = 0)
        {
            var newOperation = new AccountOperationValueObject
            {
                Id = operationId,
                Amount = operationAmount,
                OperationType = operationTypeEnum,
                Date = operationDate
            };

            return newOperation;
        }
    }
}
