using System;

namespace CurrenctyRateUtil.Models
{
    public class SimpleRateModel : ICloneable
    {
        public string BaseCurrency { get; set; }

        public string Currency { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
