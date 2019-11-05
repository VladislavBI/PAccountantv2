using System;

namespace PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment
{
    public class AddLoanViewItem
    {
        public decimal Sum { get; set; }

        public float Percent { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string ContragentName { get; set; }

        public int PaymentType { get; set; }
    }
}
