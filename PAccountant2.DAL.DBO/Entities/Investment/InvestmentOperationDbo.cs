using System;

namespace PAccountant2.DAL.DBO.Entities.Investment
{
    public class InvestmentOperationDbo
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public int OperationType { get; set; }
        
        public int InvestmentId { get; set; }

        public InvestmentDbo Investment { get; set; }

        public int ContragentId { get; set; }

        public ContragentDbo Contragent { get; set; }

        public int CurrencyId { get; set; }

        public CurrencyDbo Currency { get; set; }
    }
}
