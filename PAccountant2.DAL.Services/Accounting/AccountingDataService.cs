using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities;
using System.Threading.Tasks;

namespace PAccountant2.DAL.Services.Accounting
{
    public class AccountingDataService: IAccountingDataService
    {
        private readonly PaccountantContext _context;

        private readonly IMapper _mapper;

        public AccountingDataService(PaccountantContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateAccountingForUser(string newUserEmail)
        {
            var newAccounting = new AccountingDbo
            {
                UserEmail = newUserEmail
            };

            _context.Accountings.Add(newAccounting);

            await _context.SaveChangesAsync();
        }

        public async Task<AccountingWithAccountsDataItem> GetAccountingWithAccounts(int id)
        {
            var dbAccounting = await _context.Accountings
                .Include(accting => accting.Accounts)
                .FirstOrDefaultAsync(accting => accting.Id == id);

            var dataItem = _mapper.Map<AccountingWithAccountsDataItem>(dbAccounting);

            return dataItem;

        }

        public async Task TransferMoneyToOtherAccountAsync(AccountTransferDataItem dbTransfer)
        {
            var fromAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == dbTransfer.IdAccountFrom);
            var toAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == dbTransfer.IdAccountTo);

            fromAccount.Amount -= dbTransfer.Amount;
            toAccount.Amount += dbTransfer.Amount;

            await _context.SaveChangesAsync();
        }
    }
}
