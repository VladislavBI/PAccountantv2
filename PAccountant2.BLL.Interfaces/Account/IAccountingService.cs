using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountingService
    {
        Task<AccountingWithAccountsViewItem> GetAccountingWithAccountsAsync(int id);
    }
}
