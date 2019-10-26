using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities;
using Z.EntityFramework.Plus;

namespace PAccountant2.DAL.Services.Accounting
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


        public async Task<AccountBalanceDataItem> GetBalanceAsync(int accountId)
        {
            var dbData = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == accountId);
            var dataItem = _mapper.Map<AccountBalanceDataItem>(dbData);

            return dataItem;
        }

        public async Task SaveNewMoneyAmountAsync(MoneyChangeDataItem dataItem)
        {
            var dbAccount = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == dataItem.Id);
            dbAccount.Amount = dataItem.Amount;

            await _context.SaveChangesAsync();
        }

        public async Task<AccountWithHistotyDataItem> GetHistoryAsync(int accountId)
        {
            var dbData = await _context.Accounts.Select(acc => new
            {
                acc.Id,
                acc.AccountHistory
            }).FirstOrDefaultAsync(acc => acc.Id == accountId);

            var accountWithHistory = new AccountWithHistotyDataItem
            {
                Id = dbData.Id,
                AccountOperations = _mapper.Map<IEnumerable<AccountOperationDataItem>>(dbData.AccountHistory)
            };

            return accountWithHistory;
        }

        public async Task CreateOperationAsync(int accountId, AccountOperationDataItem newOperation)
        {
            var dbData = await _context.Accounts
                .Include(acc => acc.AccountHistory)
                .FirstOrDefaultAsync(acc => acc.Id == accountId);

            var newDbOperation = _mapper.Map<AccountOperationDbo>(newOperation);
            dbData.AccountHistory.Add(newDbOperation);

            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateAccountAsync(int accountingId)
        {
            var newAccount = new AccountDbo
            {
                AccountingId = accountingId
            };

            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();

            return newAccount.Id;
        }

        public async Task DeleteAccount(int id)
        {
            
            _context.Accounts.Where(acc => acc.Id == id).Delete();

            await _context.SaveChangesAsync();
        }
    }
}
