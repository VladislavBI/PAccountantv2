using System.Xml.Serialization;

namespace CurrenctyRateUtil.Models.ResponseModels
{
    public class CurrencyResponseModel
    {
        [XmlElement("CcyNbr")]
        public int Number { get; set; }

        [XmlElement("CcyNm")]
        public string FullName { get; set; }

        [XmlElement("Ccy")]
        public string Code { get; set; }
    }
}
