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
    }
}
