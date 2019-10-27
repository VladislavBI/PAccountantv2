using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

namespace PAccountant2.BLL.Interfaces.Specifications.Accounting
{
    public class AccountHistoryMatchesAmount: ISpecification<AccountHistoryFiltersDataItem>
    {
        private readonly AccountHistoryFiltersViewItem _filters;

        public AccountHistoryMatchesAmount(AccountHistoryFiltersViewItem filters)
        {
            _filters = filters;
        }

        public bool IsSatisfied(AccountHistoryFiltersDataItem item)
        {
            var isMoreTrue = !_filters.AmountAbove.HasValue || item.Amount > _filters.AmountAbove;
            var isLessTrue = !_filters.AmountBellow.HasValue || item.Amount < _filters.AmountBellow;

            return isMoreTrue && isLessTrue;
        }
    }
}
