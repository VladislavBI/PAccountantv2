using System;
using System.Collections.Generic;
using PAccountant2.BLL.Domain.Enum;

namespace PAccountant2.BLL.Domain.Entities.Investment
{
    public class InvestmentEntity
    {
        public int Id { get; set; }

        public InvestmentType InvestmentType { get; set; }

        public PaymentPeriod PaymentPeriod { get; set; }

        public decimal BodyAmount { get; set; }

        public float Percent { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan Term { get; set; }

        public string Comment { get; set; }

        public IEnumerable<InvestmentOperationValueObject> Operations { get; set; }
    }
}
