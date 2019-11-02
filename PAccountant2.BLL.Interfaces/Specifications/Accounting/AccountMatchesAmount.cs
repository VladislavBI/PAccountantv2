using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

namespace PAccountant2.BLL.Interfaces.Specifications.Accounting
{
    public class AccountMatchesAmount: ISpecification<AccountBalanceDataItem>
    {
        private readonly AccountFilterViewItem _filters;

        public AccountMatchesAmount(AccountFilterViewItem filters)
        {
            _filters = filters;
        }

        public bool IsSatisfied(AccountBalanceDataItem item)
        {
            var isMoreThan = !_filters.AmountAbove.HasValue || _filters.AmountAbove.Value < item.Amount;
            var isLessThan = !_filters.AmountBellow.HasValue || _filters.AmountBellow.Value > item.Amount;

            return isLessThan && isMoreThan;
        }
    }
}
