using CurrenctyRateUtil.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrenctyRateUtil.Services
{
    public interface IRateService
    {
        SimpleRateModel ConvertRate(List<SimpleRateModel> rates, string from, string to);
        Task<IEnumerable<SimpleRateModel>> GetCurrentSimpleRates();
    }
}