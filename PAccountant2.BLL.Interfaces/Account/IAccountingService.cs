using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Accounting;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountingService
    {
        Task<AccountingWithAccountsViewItem> GetAccountingWithAccountsAsync(int id, AccountFilterViewItem mappedFilters);

        Task TransferMoneyToOtherAccountAsync(int acctingId, int fromId, AccountTransferViewItem viewData);

        Task<AccountingOptionsViewItem> GetOptionsAsync(int id);

        Task UpdateOptionsAsync(int id, AccountingOptionsViewItem options);
    }
}
