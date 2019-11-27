using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Account;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Domain.Services.Accounting
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


        public async Task PutMoneyAsync(int accountId, MoneyChangeViewItem model)
        {

            var currentMoneyAmount = await _dataService.GetBalanceAsync(accountId);
            var account = _mapper.Map<AccountEntity>(currentMoneyAmount);

            var newOperation = account.PutMoney(model.Amount);

            var newAmountDataItem = _mapper.Map<MoneyChangeDataItem>(account);
            await _dataService.SaveNewMoneyAmountAsync(newAmountDataItem);

            var newOperationDataItem = _mapper.Map<AccountOperationDataItem>(newOperation);
            await _dataService.CreateOperationAsync(account.Id, newOperationDataItem);
        }

        public async Task WithdrawMoneyAsync(int accountId, MoneyChangeViewItem model)
        {
            var currentMoneyAmount = await _dataService.GetBalanceAsync(accountId);
            var account = _mapper.Map<AccountEntity>(currentMoneyAmount);

            var newOperation = account.WithdrawMoney(model.Amount);

            var newAmountDataItem = _mapper.Map<MoneyChangeDataItem>(account);
            await _dataService.SaveNewMoneyAmountAsync(newAmountDataItem);

            var newOperationDataItem = _mapper.Map<AccountOperationDataItem>(newOperation);
            await _dataService.CreateOperationAsync(account.Id, newOperationDataItem);
        }

        public async Task<IEnumerable<AccountOperationViewItem>> GetHistoryAsync(int accountId, AccountHistoryFiltersViewItem filters)
        {
            var accountEntity = new AccountEntity {Id = accountId};
            var accountHistory = await accountEntity.GetAccountHistoryFiltered(filters, _dataService);

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

        public async Task<int> CreateNewAccountAsync(int accountingId)
            => await _dataService.CreateAccountAsync(accountingId);

        public async Task DeleteAccount(int id)
        {
            var currentMoneyAmount = await _dataService.GetBalanceAsync(id);
            var account = _mapper.Map<AccountEntity>(currentMoneyAmount);

            account.CheckIsDeletePossible();

            await _dataService.DeleteAccount(id);
        }
    }
}
