using System.Collections.Generic;
using System.Threading.Tasks;
using CurrenctyRateUtil.Models;

namespace CurrenctyRateUtil.Services
{
    public interface IRateService
    {
        SimpleRateModel ConvertRate(List<SimpleRateModel> rates, string from, string to);
        Task<IEnumerable<SimpleRateModel>> GetCurrentSimpleRates();
    }
}