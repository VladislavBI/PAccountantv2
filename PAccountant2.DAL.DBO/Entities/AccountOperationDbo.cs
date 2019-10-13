using PAccountant2.BLL.Domain.Enum;
using System;

namespace PAccountant2.DAL.DBO.Entities
{
    public class AccountOperationDbo
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public AccountBalanceChangeType OperationType { get; set; }

        public decimal Amount { get; set; }

        public AccountDbo Account { get; set; }

        public int AccountId { get; set; }
    }
}
