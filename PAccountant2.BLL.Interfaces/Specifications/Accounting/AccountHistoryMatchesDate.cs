using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

namespace PAccountant2.BLL.Interfaces.Specifications.Accounting
{
    public class AccountHistoryMatchesDate : ISpecification<AccountHistoryFiltersDataItem>
    {
        private readonly AccountHistoryFiltersViewItem _filters;

        public AccountHistoryMatchesDate(AccountHistoryFiltersViewItem filters)
        {
            _filters = filters;
        }

        public bool IsSatisfied(AccountHistoryFiltersDataItem item)
        {
            var isAfterTrue = !_filters.DateAfter.HasValue || item.Date > _filters.DateAfter.Value;
            var isBeforeTrue = !_filters.DateBefore.HasValue || item.Date < _filters.DateBefore.Value;

            return isAfterTrue && isBeforeTrue;
        }
    }
}
