using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountingDataService
    {
        Task CreateAccountingForUser(string newUserEmail);

        Task<AccountingWithAccountsDataItem> GetAccountingWithAccounts(int id);

        Task TransferMoneyToOtherAccountAsync(AccountTransferDataItem dbTransfer);
    }
}
