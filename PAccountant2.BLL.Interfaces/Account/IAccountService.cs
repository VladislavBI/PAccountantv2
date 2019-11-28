using System.Collections.Generic;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountService
    {
        Task<AccountBalanceViewItem> GetBalanceAsync(int accountId);

        Task PutMoneyAsync(int accountId, MoneyChangeViewItem model);

        Task WithdrawMoneyAsync(int accountId, MoneyChangeViewItem model);

        Task<IEnumerable<AccountOperationViewItem>> GetHistoryAsync(int accountId, AccountHistoryFiltersViewItem filters);

        Task<int> CreateNewAccountAsync(int accountingId);
        
        Task DeleteAccount(int id);

        Task UpdateAccountAsync(int id, AccountUpdateViewItem updateModel);
    }
}
