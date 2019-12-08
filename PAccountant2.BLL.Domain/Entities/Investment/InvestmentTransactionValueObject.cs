using PAccountant2.BLL.Domain.Enum;

namespace PAccountant2.BLL.Domain.Entities.Investment
{
    class InvestmentTransactionValueObject
    {
        public decimal StartBodyAmount { get; set; }

        public decimal CurrentBodyAmount { get; set; }

        public InvestmentType InvestmentType { get; set; }

        public float PaymentPercent { get; set; }
    }
}
