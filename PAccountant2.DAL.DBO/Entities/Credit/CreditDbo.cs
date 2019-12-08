using PAccountant2.DAL.DBO.Entities.Accounting;
using System;
using System.Collections.Generic;

namespace PAccountant2.DAL.DBO.Entities.Credit
{
    public class CreditDbo
    {
        public int Id { get; set; }

        public int CreditType { get; set; }

        public int PercentPeriod { get; set; }

        public decimal BodyAmount { get; set; }

        public decimal LeftAmount { get; set; }

        public decimal PercentAmount { get; set; }

        public float Percent { get; set; }

        public DateTime StartDate { get; set; }

        public long Term { get; set; }

        public string Comment { get; set; }

        public ICollection<CreditOperationDbo> Operations { get; set; }

        public int AccountingId { get; set; }

        public AccountingDbo Accounting { get; set; }
    }
}
