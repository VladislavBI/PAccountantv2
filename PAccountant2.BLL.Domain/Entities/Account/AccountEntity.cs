using PAccountant2.BLL.Domain.Entities.Account.Handlers;
using PAccountant2.BLL.Domain.Entities.Accounting.Handlers;
using PAccountant2.BLL.Domain.Entities.Currency.Handlers;
using PAccountant2.BLL.Domain.Enum;
using PAccountant2.BLL.Domain.Exceptions.Account;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Currency;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
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

        public string Name { get; set; }

        public int CurrencyId { get; set; }

        public IEnumerable<AccountOperationValueObject> AccountOperations { get; set; }

        private readonly TransactionHandler _transactionHandler;

        private readonly OperationHandler _operationHandler;

        private readonly AccountHistoryHandler _historyHandler;

        private readonly AccountFactory _accountFactory;

        private readonly CurrencyFactory _currencyFactory;

        private readonly CurrencyHandler _currencyHandler;


        public AccountEntity()
        {
            _currencyFactory = new CurrencyFactory();
            _currencyHandler = new CurrencyHandler();
            _transactionHandler = new TransactionHandler();
            _operationHandler = new OperationHandler();
            _accountFactory = new AccountFactory();
            _historyHandler = new AccountHistoryHandler();
        }

        public AccountOperationValueObject PutMoneyToThisAccount(decimal putAmount, int putCurrencyId, IEnumerable<ExchangeRateDataItem> exchangeRates)
        {
            var (newAmount, newOperation) = PutMoney(putAmount, Amount, putCurrencyId, CurrencyId, AccountOperations,
                exchangeRates);
            Amount = newAmount;

            return newOperation;
        }

        public AccountOperationValueObject WithdrawMoneyFromThisAccount(decimal withdrawAmount, int withdrawCurrencyId, IEnumerable<ExchangeRateDataItem> exchangeRates)
        {
            var (newAmount, newOperation) = WithdrawMoney(withdrawAmount, Amount, withdrawCurrencyId, CurrencyId, AccountOperations,
                exchangeRates);
            Amount = newAmount;

            return newOperation;
        }

        //TODO: refactor this
        public (decimal newAmount, AccountOperationValueObject newOperation) PutMoney(decimal putAmount, decimal accAmount,
            int putCurrencyId, int accCurrencyId, IEnumerable<AccountOperationValueObject> accountOperations, 
            IEnumerable<ExchangeRateDataItem> exchangeRates)
        {

            var ratesValueObjects = exchangeRates
                .Select(rate => _currencyFactory.CreateExchangeRateValueObject(rate.Buy, rate.Sell, rate.BaseCurrencyId, rate.ResultCurrencyId));
            var convertedPutAmount = _currencyHandler.ConvertToRate(putAmount, accCurrencyId, putCurrencyId, ratesValueObjects);

            var transaction = _accountFactory.CreateTransactionValueObject(convertedPutAmount, accAmount);
            var newAmount = _transactionHandler.PerformPutTransaction(transaction);

            var newOperation =
                _accountFactory.CreateOperationValueObject(putAmount, AccountBalanceChangeType.Put, DateTime.Now, putCurrencyId);
            AccountOperations = _operationHandler.AddNewOperation(newOperation, accountOperations);

            return (newAmount, newOperation);
        }

        public (decimal newAmount, AccountOperationValueObject newOperation) WithdrawMoney(decimal withdrawAmount, decimal accAmount,
            int withdrawCurrencyId, int accCurrencyId, IEnumerable<AccountOperationValueObject> accountOperations,
            IEnumerable<ExchangeRateDataItem> exchangeRates)
        {

            var ratesValueObjects = exchangeRates
                .Select(rate => _currencyFactory.CreateExchangeRateValueObject(rate.Buy, rate.Sell, rate.BaseCurrencyId, rate.ResultCurrencyId));
            var convertedWithdrawAmount = _currencyHandler.ConvertToRate(withdrawAmount, accCurrencyId, withdrawCurrencyId, ratesValueObjects);

            var transaction = _accountFactory.CreateTransactionValueObject(convertedWithdrawAmount, accAmount);
            var newAmount = _transactionHandler.PerformWithdrawTransaction(transaction);

            var newOperation =
                _accountFactory.CreateOperationValueObject(withdrawAmount, AccountBalanceChangeType.Withdraw, DateTime.Now, withdrawCurrencyId);
            AccountOperations = _operationHandler.AddNewOperation(newOperation, accountOperations);

            return (newAmount, newOperation);
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
                _accountFactory.CreateOperationValueObject(oper.Amount, oper.OperationType, oper.Date, oper.CurrencyId, oper.Id));

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
        //TODO: refactor this
        public (decimal newForAmount, decimal newToAmount, 
            AccountOperationValueObject newFromOperation, AccountOperationValueObject newToOperation) TransferToAccount
            (decimal amountToTransfer, decimal accountToAmount, int accountToCurrencyId, IEnumerable<ExchangeRateDataItem> exchangeRates)
        {
            var exchangeRateDataItems = exchangeRates as ExchangeRateDataItem[] ?? exchangeRates.ToArray();

            var newWithdrawOperation = WithdrawMoneyFromThisAccount(amountToTransfer, CurrencyId, exchangeRateDataItems);
            var (newAmount, newPutOperation) = PutMoney(amountToTransfer, accountToAmount, CurrencyId, accountToCurrencyId, null, exchangeRateDataItems);

            return (Amount, newAmount, newWithdrawOperation, newPutOperation);
        }
    }
}
