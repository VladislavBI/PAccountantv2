using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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


        public async Task AddMoneyAsync(AddMoneyViewItem addModel)
        {
            var currentMoneyAmount = await _dataService.GetMoneyAmountAsync(addModel.Id);
            var account = _mapper.Map<AccountEntity>(currentMoneyAmount);

            account.AddMoney(addModel.Amount);

            var newAmountDataItem = _mapper.Map<AddMoneyDataItem>(account);
            await _dataService.SaveNewMoneyAmountAync(newAmountDataItem);
        }
    }
}
