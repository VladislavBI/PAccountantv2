using System;

namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.Account
{
    public class AccountHistoryFiltersViewItem
    {
        public int? AmountBellow { get; set; }

        public int? AmountAbove { get; set; }

        public DateTime? DateBefore { get; set; }

        public DateTime? DateAfter { get; set; }

        public int? OperationType { get; set; }
    }
}
