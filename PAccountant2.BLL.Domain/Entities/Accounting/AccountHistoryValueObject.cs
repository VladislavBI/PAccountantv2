using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PAccountant2.BLL.Domain.Enum;

namespace PAccountant2.BLL.Domain.Entities.Accounting
{
    public class AccountHistoryValueObject
    {
        public IEnumerable<AccountOperationValueObject> AccountOperations { get; set; }

        public void AddOperation(decimal amount, AccountBalanceChangeType changeType)
        {
            CreateAccountOperationsIfNotCreated();

            var newOperation = new AccountOperationValueObject
            {
                Amount = amount,
                Date = DateTime.UtcNow,
                OperationType = changeType
            };

            AddNewOperation(newOperation);
        }

        private void AddNewOperation(AccountOperationValueObject newOperation)
        {
            var operationsList = AccountOperations.ToList();
            operationsList.Add(newOperation);
            AccountOperations = operationsList;
        }

        private void CreateAccountOperationsIfNotCreated()
        {
            AccountOperations = AccountOperations ?? new List<AccountOperationValueObject>();
        }

        public AccountOperationValueObject GetLastOperation()
            => AccountOperations
                .OrderByDescending(op => op.Date)
                .FirstOrDefault();
    }
}
