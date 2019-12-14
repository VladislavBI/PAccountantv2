using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Accounting;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Accounting;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountingDataService
    {
        Task<int> CreateAccountingForUser(string newUserEmail);

        Task<AccountingWithAccountsDataItem> GetAccountingWithAccounts(int id, Specifications.AndSpecification<AccountBalanceDataItem> accountingSpecification);

        Task TransferMoneyToOtherAccountAsync(AccountTransferDataItem dbTransfer);

        Task<AccountingOptionsDataItem> GetOptionsAsync(int id);

        Task UpdateOptionsAsync(int id, AccountingOptionsViewItem options);
    }
}
