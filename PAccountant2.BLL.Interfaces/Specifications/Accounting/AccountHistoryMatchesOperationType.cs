using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

namespace PAccountant2.BLL.Interfaces.Specifications.Accounting
{
    public class AccountHistoryMatchesOperationType : ISpecification<AccountHistoryFiltersDataItem>
    {
        private readonly AccountHistoryFiltersViewItem _filters;

        public AccountHistoryMatchesOperationType(AccountHistoryFiltersViewItem filters)
        {
            _filters = filters;
        }


        public bool IsSatisfied(AccountHistoryFiltersDataItem item)
        {
            var isTypeMatches = !_filters.OperationType.HasValue || item.OperationType == _filters.OperationType.Value;

            return isTypeMatches;
        }
    }
}
