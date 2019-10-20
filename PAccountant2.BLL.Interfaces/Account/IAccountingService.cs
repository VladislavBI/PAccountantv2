using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountingService
    {
        Task<AccountingWithAccountsViewItem> GetAccountingWithAccountsAsync(int id);

        Task TransferMoneyToOtherAccountAsync(int acctingId, int fromId, AccountTransferViewItem viewData);
    }
}
