﻿using PAccountant2.BLL.Domain.Entities.Account.Handlers;
using PAccountant2.BLL.Domain.Enum;
using PAccountant2.BLL.Domain.Exceptions.Account;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.BLL.Interfaces.Specifications;
using PAccountant2.BLL.Interfaces.Specifications.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Domain.Entities.Account
{
    public class AccountEntity
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public IEnumerable<AccountOperationValueObject> AccountOperations { get; set; }

        private readonly TransactionHandler _transactionHandler;

        private readonly OperationHandler _operationHandler;

        private readonly AccountHistoryHandler _historyHandler;

        private readonly AccountFactory _accountFactory;

        public AccountEntity()
        {
            _transactionHandler = new TransactionHandler();
            _operationHandler = new OperationHandler();
            _accountFactory = new AccountFactory();
            _historyHandler = new AccountHistoryHandler();
        }

        public AccountOperationValueObject PutMoney(decimal putAmount)
        {
            var transaction = _accountFactory.CreateTransactionValueObject(putAmount, Amount);
            Amount = _transactionHandler.PerformPutTransaction(transaction);

            var newOperation =
                _accountFactory.CreateOperationValueObject(putAmount, AccountBalanceChangeType.Put, DateTime.Now);
            AccountOperations = _operationHandler.AddNewOperation(newOperation, AccountOperations);

            return newOperation;
        }

        public AccountOperationValueObject WithdrawMoney(decimal withdrawAmount)
        {
            var transaction = _accountFactory.CreateTransactionValueObject(withdrawAmount, Amount);
            Amount = _transactionHandler.PerformWithdrawTransaction(transaction);

            var newOperation =
                _accountFactory.CreateOperationValueObject(withdrawAmount, AccountBalanceChangeType.Withdraw, DateTime.Now);
            AccountOperations = _operationHandler.AddNewOperation(newOperation, AccountOperations);

            return newOperation;
        }

        public void CheckIsOperationAvailable(decimal amount)
        {
            if (!IsOperationAvailable(amount))
            {
                throw new NotEnoughMoneyException();
            }
        }

        public async Task<IEnumerable<AccountOperationValueObject>> GetAccountHistoryFilteredAsync(AccountHistoryFiltersViewItem filters,
            IAccountDataService dataService)
        {
            var accountHistory = await _historyHandler.GetAccountHistoryAsync(Id, filters, dataService);

            var historyMapped = accountHistory.Select(oper => 
                _accountFactory.CreateOperationValueObject(oper.Amount, oper.OperationType, oper.Date, oper.Id));

            return historyMapped;
        }

        private bool IsOperationAvailable(decimal neededAmount)
            => Amount >= neededAmount;

        public async Task DeleteAsync(IAccountDataService dataService)
        {
            if (Amount > 0)
            {
                throw new CanNotDeleteException(CanNotDeleteReasons.NotNullBalance);
            }

            await dataService.DeleteAccount(Id);
        }
    }
}
