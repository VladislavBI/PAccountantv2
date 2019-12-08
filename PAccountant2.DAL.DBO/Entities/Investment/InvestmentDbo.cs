using PAccountant2.DAL.DBO.Entities.Accounting;
using System;
using System.Collections.Generic;
using PAccountant2.DAL.DBO.Entities.Currency;

namespace PAccountant2.DAL.DBO.Entities.Investment
{
    public class InvestmentDbo
    {
        public int Id { get; set; }

        public int InvestmentType { get; set; }

        public int PaymentPeriod { get; set; }

        public decimal StartBodyAmount { get; set; }

        public decimal CurrentBodyAmount { get; set; }

        public float Percent { get; set; }

        public DateTime StartDate { get; set; }

        public long Term { get; set; }

        public int MoneyIncomeOption { get; set; }

        public string Comment { get; set; }

        public bool Completed { get; set; }

        public ICollection<InvestmentOperationDbo> Operations { get; set; }

        public int AccountingId { get; set; }

        public AccountingDbo Accounting { get; set; }

        public int CurrencyId { get; set; }

        public CurrencyDbo Currency { get; set; }
    }
}
