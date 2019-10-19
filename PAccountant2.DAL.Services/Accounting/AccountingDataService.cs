using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities;

namespace PAccountant2.DAL.Services.Accounting
{
    public class AccountingDataService: IAccountingDataService
    {
        private readonly PaccountantContext _context;

        public AccountingDataService(PaccountantContext context)
        {
            _context = context;
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
    }
}
