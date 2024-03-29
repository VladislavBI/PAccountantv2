﻿using System;

namespace PAccountant2.Host.Domain.ViewModels.Investment
{
    public class AddInvestmentViewModel
    {
        public decimal Sum { get; set; }

        public float Percent { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string ContragentName { get; set; }

        public int PaymentType { get; set; }

        public int CurrencyId { get; set; }

        public int MoneyIncomeOption { get; set; }
    }
}
