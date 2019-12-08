using System;
using PAccountant2.DAL.DBO.Entities.Currency;

namespace PAccountant2.DAL.DBO.Entities.Credit
{
    public class CreditOperationDbo
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public int OperationType { get; set; }

        public int CreditId { get; set; }

        public CreditDbo Credit { get; set; }

        public int ContragentId { get; set; }

        public ContragentDbo Contragent { get; set; }

        public int CurrencyId { get; set; }

        public CurrencyDbo Currency { get; set; }
    }
}
