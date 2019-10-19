using System;
using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataService _dataService;

        private readonly IMapper _mapper;


        public AccountService(IAccountDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }


        public async Task AddMoneyAsync(int accountId, MoneyChangeViewItem model)
        {
            var currentMoneyAmount = await _dataService.GetBalanceAsync(accountId);
            var account = _mapper.Map<AccountEntity>(currentMoneyAmount);

            account.AddMoney(model.Amount);

            var newAmountDataItem = _mapper.Map<MoneyChangeDataItem>(account);
            await _dataService.SaveNewMoneyAmountAsync(newAmountDataItem);

            await SaveNewOperation(account);
        }

        public async Task WithdrawMoneyAsync(int accountId, MoneyChangeViewItem model)
        {
            var currentMoneyAmount = await _dataService.GetBalanceAsync(accountId);
            var account = _mapper.Map<AccountEntity>(currentMoneyAmount);

            account.WithdrawMoney(model.Amount);

            var newAmountDataItem = _mapper.Map<MoneyChangeDataItem>(account);
            await _dataService.SaveNewMoneyAmountAsync(newAmountDataItem);

            await SaveNewOperation(account);

        }

        public async Task<IEnumerable<AccountOperationViewItem>> GetHistoryAsync(int accountId)
        {
            var dbData = await _dataService.GetHistoryAsync(accountId);

            var account = _mapper.Map<AccountEntity>(dbData);
            var accountHistory = account.CreateAccountHistory();
            var accountOperation = accountHistory.AccountOperations;

            var mappedHistory = _mapper.Map<IEnumerable<AccountOperationViewItem>>(accountOperation);

            return mappedHistory;
        }

        public async Task<AccountBalanceViewItem> GetBalanceAsync(int accountId)
        {
            var dbBalance = await _dataService.GetBalanceAsync(accountId);
            var viewItem = _mapper.Map<AccountBalanceViewItem>(dbBalance);

            return viewItem;
        }

        private async Task SaveNewOperation(AccountEntity account)
        {
            var lastOperation = account
                .CreateAccountHistory()
                .GetLastOperation();
            var lastOperationDataItem = _mapper.Map<AccountOperationDataItem>(lastOperation);
            await _dataService.CreateOperationAsync(account.Id, lastOperationDataItem);
        }
    }
}
