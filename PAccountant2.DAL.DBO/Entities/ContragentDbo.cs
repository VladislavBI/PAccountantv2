﻿using PAccountant2.DAL.DBO.Entities.Account;
using PAccountant2.DAL.DBO.Entities.Accounting;
using PAccountant2.DAL.DBO.Entities.Credit;
using PAccountant2.DAL.DBO.Entities.Investment;
using System.Collections.Generic;

namespace PAccountant2.DAL.DBO.Entities
{
    public class ContragentDbo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AccountingId { get; set; }

        public AccountingDbo Accounting { get; set; }

        public ICollection<AccountOperationDbo> AccountOperations { get; set; }

        public ICollection<InvestmentOperationDbo> InvestmentOperations { get; set; }

        public ICollection<CreditOperationDbo> CreditOperations { get; set; }

    }
}
