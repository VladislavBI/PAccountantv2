using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.Specifications;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountDataService
    {
        Task<AccountBalanceDataItem> GetBalanceAsync(int accountId);

        Task SaveNewMoneyAmountAsync(MoneyChangeDataItem dataItem);

        Task<AccountWithHistotyDataItem> GetHistoryAsync(int accountId, ISpecification<AccountHistoryFiltersDataItem> specification);

        Task CreateOperationAsync(int accountId, AccountOperationDataItem operation);

        Task<int> CreateAccountAsync(int accountingId);
        
         Task DeleteAccount(int id);

        Task UpdateAccountAsync(int id, AccountUpdateDataItem mappedModel);
    }
}
