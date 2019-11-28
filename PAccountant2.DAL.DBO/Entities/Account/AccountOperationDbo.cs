using PAccountant2.BLL.Domain.Enum;
using PAccountant2.DAL.DBO.Entities.Currency;
using System;

namespace PAccountant2.DAL.DBO.Entities.Account
{
    public class AccountOperationDbo
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public AccountBalanceChangeType OperationType { get; set; }

        public decimal Amount { get; set; }

        public AccountDbo Account { get; set; }

        public int AccountId { get; set; }

        public int? ContragentId { get; set; }

        public ContragentDbo Contragent { get; set; }

        public int CurrencyId { get; set; }

        public CurrencyDbo Currency { get; set; }
    }
}
