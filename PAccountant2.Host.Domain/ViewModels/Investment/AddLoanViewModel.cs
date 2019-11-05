using System;

namespace PAccountant2.Host.Domain.ViewModels.Investment
{
    public class AddLoanViewModel
    {
        public decimal Sum { get; set; }

        public float Percent { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string ContragentName { get; set; }

        public int PaymentType { get; set; }
    }
}
