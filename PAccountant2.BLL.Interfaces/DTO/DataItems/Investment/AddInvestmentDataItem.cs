using System;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Investment
{
    public class AddInvestmentDataItem
    {
        public decimal StartBodyAmount { get; set; }

        public float Percent { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan Term { get; set; }

        public int ContragentId { get; set; }

        public int AccountingId { get; set; }

        public int PaymentType { get; set; }

        public int InvestmentType { get; set; }

        public int CurrencyId { get; set; }

        public int MoneyIncomeOption { get; set; }
    }
}
