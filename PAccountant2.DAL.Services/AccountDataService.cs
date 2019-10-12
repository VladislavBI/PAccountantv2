using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.DAL.Context;

namespace PAccountant2.DAL.Services
{
    public class AccountDataService: IAccountDataService
    {

        private readonly IMapper _mapper;
        private readonly PaccountantContext _context;

        public AccountDataService(PaccountantContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<AddMoneyDataItem> GetMoneyAmountAsync(int addModelId)
        {
            var dbData = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == addModelId);
            var dataItem = _mapper.Map<AddMoneyDataItem>(dbData);

            return dataItem;
        }

        public async Task SaveNewMoneyAmountAync(AddMoneyDataItem newAmountDataItem)
        {
            var dbAccount = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == newAmountDataItem.Id);
            dbAccount.Amount = newAmountDataItem.Amount;

            await _context.SaveChangesAsync();
        }
    }
}
