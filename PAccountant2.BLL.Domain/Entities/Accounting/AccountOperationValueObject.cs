using PAccountant2.BLL.Domain.Enum;
using System;

namespace PAccountant2.BLL.Domain.Entities.Accounting
{
    public class AccountOperationValueObject
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public AccountBalanceChangeType OperationType { get; set; }

        public decimal Amount { get; set; }

        public CurrencyEntity Currency { get; set; }
    }
}
