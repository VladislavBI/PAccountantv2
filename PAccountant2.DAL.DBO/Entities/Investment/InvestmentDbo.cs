using System;
using System.Collections.Generic;

namespace PAccountant2.DAL.DBO.Entities.Investment
{
    public class InvestmentDbo
    {
        public int Id { get; set; }

        public int InvestmentType { get; set; }

        public int PaymentPeriod { get; set; }

        public decimal BodyAmount { get; set; }

        public float Percent { get; set; }

        public DateTime StartDate { get; set; }

        public long Term { get; set; }

        public string Comment { get; set; }

        public ICollection<InvestmentOperationDbo> Operations { get; set; }

        public int AccountingId { get; set; }

        public AccountingDbo Accounting { get; set; }
    }
}
