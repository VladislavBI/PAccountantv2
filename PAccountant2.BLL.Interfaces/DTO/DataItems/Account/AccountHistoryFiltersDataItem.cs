using System;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Account
{
    public class AccountHistoryFiltersDataItem
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int OperationType { get; set; }

        public decimal Amount { get; set; }

    }
}
