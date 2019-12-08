using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.BLL.Domain.Entities.Investment
{
    class InvestmentTransactionResultValueObject
    {
        public decimal CurrentBodyAmount { get; set; }

        public decimal PaymentAmount { get; set; }
    }
}
