using System.Collections.Generic;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Currency;

namespace PAccountant2.BLL.Interfaces.Currency
{
    public interface ICurrencyDataService
    {
        Task<IEnumerable<ExchangeRateDataItem>> GetExchangeRates();
    }
}