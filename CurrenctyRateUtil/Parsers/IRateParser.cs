using CurrenctyRateUtil.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrenctyRateUtil.Parsers
{
    public interface IRateParser
    {
        Task<IEnumerable<SimpleRateModel>> GetSimpleRateData();
    }
}
