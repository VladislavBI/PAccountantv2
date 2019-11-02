using System;
using PAccountant2.BLL.Domain.Enum;

namespace PAccountant2.BLL.Domain.Entities.Investment
{
    public class InvestmentOperationValueObject
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public AccountBalanceChangeType OperationType { get; set; }
    }
}
