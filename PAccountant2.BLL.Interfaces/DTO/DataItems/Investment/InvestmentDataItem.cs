using System;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Investment
{
    public class InvestmentDataItem
    {
        public int Id { get; set; }

        public decimal StartBodyAmount { get; set; }

        public decimal CurrentBodyAmount { get; set; }

        public float Percent { get; set; }

        public int InvestmentType { get; set; }

        public DateTime LastPayment { get; set; }

        public DateTime StartDate { get; set; }

        public int PaymentPeriod { get; set; }

        public TimeSpan Term { get; set; }

        public bool Completed { get; set; }

    }
}
