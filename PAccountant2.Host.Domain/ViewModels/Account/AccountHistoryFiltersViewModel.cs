using System;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountHistoryFiltersViewModel
    {
        public int? AmountBellow { get; set; }

        public int? AmountAbove { get; set; }

        public DateTime? DateBefore { get; set; }

        public DateTime? DateAfter { get; set; }

        public int? OperationType { get; set; }
    }
}
