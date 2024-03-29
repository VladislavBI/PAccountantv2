﻿using PAccountant2.BLL.Domain.Enum;
using System;

namespace PAccountant2.BLL.Domain.Entities.Investment
{
    public class InvestmentOperationValueObject
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public decimal NewTotalAmount { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

    }
}
