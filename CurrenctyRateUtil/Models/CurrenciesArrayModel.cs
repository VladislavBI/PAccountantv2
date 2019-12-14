using CurrenctyRateUtil.Models.ResponseModels;
using System.Xml.Serialization;

namespace CurrenctyRateUtil.Models
{
    [XmlRoot("ISO_4217")]
    public class CurrenciesArrayModel
    {
        [XmlArray("CcyTbl")]
        [XmlArrayItem("CcyNtry")]
        public CurrencyResponseModel[] Currencies { get; set; }
    }
}
