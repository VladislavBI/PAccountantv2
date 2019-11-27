using System;
using PAccountant2.BLL.Domain.Entities.Currency;
using PAccountant2.BLL.Domain.Enum;

namespace PAccountant2.BLL.Domain.Entities.Account
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
