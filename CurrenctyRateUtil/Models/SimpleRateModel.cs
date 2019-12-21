using System;

namespace CurrenctyRateUtil.Models
{
    public class SimpleRateModel : ICloneable
    {
        public string BaseCurrency { get; set; }

        public int? BaseCode { get; set; }

        public string ResultCurrency { get; set; }

        public int? ResultCode { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
