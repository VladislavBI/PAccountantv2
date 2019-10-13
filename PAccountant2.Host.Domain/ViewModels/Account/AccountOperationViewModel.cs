using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.Host.Domain.ViewModels.Account
{
    public class AccountOperationViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int OperationType { get; set; }

        public decimal Amount { get; set; }
    }
}
