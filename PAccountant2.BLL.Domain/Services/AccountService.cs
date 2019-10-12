﻿using System.Threading.Tasks;
using AutoMapper;
using PAccountant2.BLL.Domain.Entities;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

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
        }

        public async Task WithdrawMoneyAsync(int accountId, MoneyChangeViewItem model)
        {
            var currentMoneyAmount = await _dataService.GetBalanceAsync(accountId);
            var account = _mapper.Map<AccountEntity>(currentMoneyAmount);

            account.WithdrawMoney(model.Amount);

            var newAmountDataItem = _mapper.Map<MoneyChangeDataItem>(account);
            await _dataService.SaveNewMoneyAmountAsync(newAmountDataItem);
        }

        public async Task<AccountBalanceViewItem> GetBalanceAsync(int accountId)
        {
            var dbBalance = await _dataService.GetBalanceAsync(accountId);
            var viewItem = _mapper.Map<AccountBalanceViewItem>(dbBalance);

            return viewItem;
        }
    }
}
