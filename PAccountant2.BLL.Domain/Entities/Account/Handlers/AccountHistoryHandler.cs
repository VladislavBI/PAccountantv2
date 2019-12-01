using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.BLL.Interfaces.Specifications;
using PAccountant2.BLL.Interfaces.Specifications.Accounting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Domain.Entities.Account.Handlers
{
    public class AccountHistoryHandler
    {
        public async Task<IEnumerable<AccountOperationDataItem>> GetAccountHistoryAsync(int accId, AccountHistoryFiltersViewItem filters, IAccountDataService dataService)
        {
            var specification = CreateAccountSpecification(filters);
            var accountWithHistory = await dataService.GetHistoryAsync(accId, specification);

            var accountHistory = accountWithHistory.AccountOperations;

            return accountHistory;
        }

        private static ISpecification<AccountHistoryFiltersDataItem> CreateAccountSpecification(AccountHistoryFiltersViewItem filters)
        {
            var isAmountMatches = new AccountHistoryMatchesAmount(filters);
            var isDateMatches = new AccountHistoryMatchesDate(filters);
            var isTypeMatches = new AccountHistoryMatchesOperationType(filters);

            var compositeSpecification = new AndSpecification<AccountHistoryFiltersDataItem>(isAmountMatches, isDateMatches);
            compositeSpecification = new AndSpecification<AccountHistoryFiltersDataItem>(compositeSpecification, isTypeMatches);
            return compositeSpecification;
        }
    }
}
