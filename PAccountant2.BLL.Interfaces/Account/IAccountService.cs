using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountService
    {
        Task AddMoneyAsync(int accountId, MoneyChangeViewItem model);

        Task<AccountBalanceViewItem> GetBalanceAsync(int accountId);

    }
}
