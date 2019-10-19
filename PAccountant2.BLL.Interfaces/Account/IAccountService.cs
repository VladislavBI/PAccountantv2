using System.Collections.Generic;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountService
    {
        Task<AccountBalanceViewItem> GetBalanceAsync(int accountId);

        Task AddMoneyAsync(int accountId, MoneyChangeViewItem model);

        Task WithdrawMoneyAsync(int accountId, MoneyChangeViewItem model);

        Task<IEnumerable<AccountOperationViewItem>> GetHistoryAsync(int accountId);

        Task<int> CreateNewAccountAsync(int accountingId);
    }
}
