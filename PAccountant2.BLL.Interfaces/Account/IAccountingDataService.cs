using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountingDataService
    {
        Task CreateAccountingForUser(string newUserEmail);
        
        Task<AccountingWithAccountsDataItem> GetAccountingWithAccounts(int id);
    }
}
