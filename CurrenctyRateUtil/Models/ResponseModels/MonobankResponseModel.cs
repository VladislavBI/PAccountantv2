using System.Xml.Serialization;

namespace CurrenctyRateUtil.Models.ResponseModels
{
    public class MonobankResponseModel
    {
        [XmlElement("currencyCodeA")]
        public int CurrencyCodeA { get; set; }

        [XmlElement("currencyCodeB")]
        public int CurrencyCodeB { get; set; }

        [XmlElement("rateBuy")]
        public float RateBuy { get; set; }

        [XmlElement("rateSell")]
        public float RateSell { get; set; }
    }
}
