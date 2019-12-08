using System;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Investment
{
    public class InvestmentOperationDataItem
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public decimal NewTotalAmount { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public int ContragentId { get; set; }
    }
}
