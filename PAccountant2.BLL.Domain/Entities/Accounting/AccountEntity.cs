using PAccountant2.BLL.Domain.Enum;
using PAccountant2.BLL.Domain.Exceptions.Account;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.BLL.Interfaces.Specifications;
using PAccountant2.BLL.Interfaces.Specifications.Accounting;

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

        public AccountHistoryValueObject CreateAccountHistory(IEnumerable<AccountOperationValueObject> operations)
        {
            return new AccountHistoryValueObject
            {
                AccountOperations = operations
            };
        }

        public AccountOperationValueObject CreateAccountOperation(AccountOperationDataItem operation)
        {
            var operationTypeEnum = System.Enum.Parse<AccountBalanceChangeType>(operation.OperationType.ToString());

            var operationValueObject = new AccountOperationValueObject
            {
                Id = operation.Id,
                Amount = operation.Amount,
                OperationType = operationTypeEnum,
                Date = operation.Date
            };

            return operationValueObject;
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

        public void CheckIsOperationAvailable(decimal amount)
        {
            if (!IsOperationAvailable(amount))
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

        public async Task<AccountHistoryValueObject> GetAccountHistoryFiltered(AccountHistoryFiltersViewItem filters,
            IAccountDataService dataService)
        {
            var accountHistorySpecification = CreateAccountSpecification(filters);

            var data = await dataService.GetHistoryAsync(Id, accountHistorySpecification);

            var operations = data.AccountOperations.Select(CreateAccountOperation);
            var history = CreateAccountHistory(operations);

            return history;
        }

        private static AndSpecification<AccountHistoryFiltersDataItem> CreateAccountSpecification(AccountHistoryFiltersViewItem filters)
        {
            var isAmountMatches = new AccountHistoryMatchesAmount(filters);
            var isDateMatches = new AccountHistoryMatchesAmount(filters);
            var isTypeMatches = new AccountHistoryMatchesAmount(filters);

            var compositeSpecification = new AndSpecification<AccountHistoryFiltersDataItem>(isAmountMatches, isDateMatches);
            compositeSpecification = new AndSpecification<AccountHistoryFiltersDataItem>(compositeSpecification, isTypeMatches);
            return compositeSpecification;
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
