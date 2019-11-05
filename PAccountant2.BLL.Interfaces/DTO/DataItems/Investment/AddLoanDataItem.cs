﻿using System;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Investment
{
    public class AddLoanDataItem
    {
        public decimal BodyAmount { get; set; }

        public float Percent { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan Term { get; set; }

        public int ContragentId { get; set; }

        public int AccountingId { get; set; }

        public int PaymentType { get; set; }
    }
}
