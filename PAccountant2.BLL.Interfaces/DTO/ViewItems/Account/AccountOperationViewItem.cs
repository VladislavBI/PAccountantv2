using System;

namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.Account
{
    public class AccountOperationViewItem
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int OperationType { get; set; }

        public decimal Amount { get; set; }

        public int CurrencyId { get; set; }
    }
}
