﻿namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Migration
{
    public class CurrencyMigrationDataItem
    {
        public string BaseCurrency { get; set; }

        public string Currency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }
    }
}
