﻿using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Account;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.Currency;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Domain.Services.Accounting
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataService _dataService;

        private readonly ICurrencyDataService _currencyDataService;

        private readonly IMapper _mapper;


        public AccountService(IAccountDataService dataService, IMapper mapper, ICurrencyDataService currencyDataService)
        {
            _dataService = dataService;
            _mapper = mapper;
            _currencyDataService = currencyDataService;
        }


        public async Task PutMoneyAsync(int accountId, MoneyChangeViewItem model)
        {

            var currentMoneyAmount = await _dataService.GetBalanceAsync(accountId);
            var account = _mapper.Map<AccountEntity>(currentMoneyAmount);
            var exchangeRates = await _currencyDataService.GetExchangeRates();
            
            var newOperation = account.PutMoneyToThisAccount(model.Amount, model.CurrencyId, exchangeRates);

            var newAmountDataItem = _mapper.Map<MoneyChangeDataItem>(account);
            await _dataService.SaveNewMoneyAmountAsync(newAmountDataItem);

            var newOperationDataItem = _mapper.Map<AccountOperationDataItem>(newOperation);
            await _dataService.CreateOperationAsync(account.Id, newOperationDataItem);
        }

        public async Task WithdrawMoneyAsync(int accountId, MoneyChangeViewItem model)
        {
            var currentMoneyAmount = await _dataService.GetBalanceAsync(accountId);
            var account = _mapper.Map<AccountEntity>(currentMoneyAmount);
            var exchangeRates = await _currencyDataService.GetExchangeRates();

            var newOperation = account.WithdrawMoneyFromThisAccount(model.Amount, model.CurrencyId, exchangeRates);

            var newAmountDataItem = _mapper.Map<MoneyChangeDataItem>(account);
            await _dataService.SaveNewMoneyAmountAsync(newAmountDataItem);

            var newOperationDataItem = _mapper.Map<AccountOperationDataItem>(newOperation);
            await _dataService.CreateOperationAsync(account.Id, newOperationDataItem);
        }

        public async Task<IEnumerable<AccountOperationViewItem>> GetHistoryAsync(int accountId, AccountHistoryFiltersViewItem filters)
        {
            var accountEntity = new AccountEntity {Id = accountId};
            accountEntity.AccountOperations = await accountEntity.GetAccountHistoryFilteredAsync(filters, _dataService);

            var mappedOperations = _mapper.Map<IEnumerable<AccountOperationViewItem>>(accountEntity.AccountOperations);

            return mappedOperations;
        }

        public async Task<AccountBalanceViewItem> GetBalanceAsync(int accountId)
        {
            var dbBalance = await _dataService.GetBalanceAsync(accountId);
            var viewItem = _mapper.Map<AccountBalanceViewItem>(dbBalance);

            return viewItem;
        }

        public async Task<int> CreateNewAccountAsync(int accountingId, AccountCreateViewItem createModel)
        {
            var mappedModel = _mapper.Map<AccountCreateDataItem>(createModel);
            var newAccId = await _dataService.CreateAccountAsync(accountingId, mappedModel);

            return newAccId;
        } 

        public async Task DeleteAccount(int id)
        {
            var currentMoneyAmount = await _dataService.GetBalanceAsync(id);
            var account = _mapper.Map<AccountEntity>(currentMoneyAmount);

            await account.DeleteAsync(_dataService);
        }

        public async Task UpdateAccountAsync(int id, AccountUpdateViewItem updateModel)
        {
            var mappedModel = _mapper.Map<AccountUpdateDataItem>(updateModel);

            await _dataService.UpdateAccountAsync(id, mappedModel);
        }

        public async Task TransferMoneyToOtherAccountAsync(int idFrom, int idTo, AccountTransferViewItem viewData)
        {
            
            var accountFrom = await _dataService.GetBalanceAsync(idFrom);
            var accountTo = await _dataService.GetBalanceAsync(idTo);
            var exchangeRates = await _currencyDataService.GetExchangeRates();

            var accountEntityFrom = _mapper.Map<AccountEntity>(accountFrom);
            var accountEntityTo = _mapper.Map<AccountEntity>(accountTo);

            var (newAccFromAmount, newAccToAmount, newAccFromOper, newAccToOper) =
                accountEntityFrom.TransferToAccount(viewData.Amount, accountTo.Amount, accountTo.CurrencyId, exchangeRates);

            accountEntityFrom.Amount = newAccFromAmount;
            accountEntityTo.Amount = newAccToAmount;

            var fromMoneyChange = _mapper.Map<MoneyChangeDataItem>(accountEntityFrom);
            var toMoneyChange = _mapper.Map<MoneyChangeDataItem>(accountEntityTo);
            var fromOperation = _mapper.Map<AccountOperationDataItem>(newAccFromOper);
            var toOperation = _mapper.Map<AccountOperationDataItem>(newAccToOper);

            await _dataService.SaveNewMoneyAmountAsync(fromMoneyChange);
            await _dataService.SaveNewMoneyAmountAsync(toMoneyChange);
            await _dataService.CreateOperationAsync(accountEntityFrom.Id, fromOperation);
            await _dataService.CreateOperationAsync(accountEntityTo.Id, toOperation);
        }
    }
}
