using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Accounting;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Accounting;
using PAccountant2.BLL.Interfaces.Specifications;
using PAccountant2.DAL.DBO.Entities.Accounting;

namespace PAccountant2.DAL.Services.Accounting
{
    public class AccountingDataService : IAccountingDataService
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
            var newOptions = new AccountingOptionsDbo
            {
                AccountingBaseCurrencyId = 1
            };

            var newAccounting = new AccountingDbo
            {
                UserEmail = newUserEmail,
                Options = newOptions
            };

            _context.Accountings.Add(newAccounting);

            await _context.SaveChangesAsync();
        }

        public async Task<AccountingWithAccountsDataItem> GetAccountingWithAccounts(int id,
            AndSpecification<AccountBalanceDataItem> accountingSpecification)
        {
            var dbAccounting = await _context.Accountings
                    .Include(x => x.Accounts)
                    .FirstOrDefaultAsync(accting => accting.Id == id);

            var accounts = await _context.Accounts
                .Where(acc => acc.AccountingId == id)
                .Select(acc => new AccountBalanceDataItem
                {
                    Id = acc.Id,
                    Amount = acc.Amount,
                    Name =  acc.Name,
                    CurrencyId = acc.CurrencyId
                })
                .Where(acc => accountingSpecification == null || accountingSpecification.IsSatisfied(acc))
                .ToListAsync();

            var dataItem = _mapper.Map<AccountingWithAccountsDataItem>(dbAccounting);
            dataItem.Accounts = accounts;

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

        public async Task<AccountingOptionsDataItem> GetOptionsAsync(int id)
        {
            var dbAccounting = await _context.Accountings
                .Include(x => x.Options)
                .ThenInclude(x => x.AccountingBaseCurrency)
                .FirstOrDefaultAsync(x => x.Id == id);

            var dbOptions = dbAccounting.Options; 

            var mappedOptions =  _mapper.Map<AccountingOptionsDataItem>(dbOptions);

            return mappedOptions;
        }

        public async Task UpdateOptionsAsync(int id, AccountingOptionsViewItem options)
        {
            var dbOptions = _mapper.Map<AccountingOptionsDbo>(options);
            _context.Entry(options).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
