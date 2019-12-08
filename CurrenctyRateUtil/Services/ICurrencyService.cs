using System.Threading.Tasks;
using CurrenctyRateUtil.Models;

namespace CurrenctyRateUtil.Services
{
    public interface ICurrencyService
    {
        Task<CurrenciesArrayModel> GetAllCurrencies();
    }
}