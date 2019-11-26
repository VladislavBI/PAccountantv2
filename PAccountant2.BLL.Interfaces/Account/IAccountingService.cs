using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Accounting;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountingService
    {
        Task<AccountingWithAccountsViewItem> GetAccountingWithAccountsAsync(int id, AccountFilterViewItem mappedFilters);

        Task TransferMoneyToOtherAccountAsync(int acctingId, int fromId, AccountTransferViewItem viewData);

        Task<AccountingOptionsViewItem> GetOptionsAsync(int id);
    }
}
