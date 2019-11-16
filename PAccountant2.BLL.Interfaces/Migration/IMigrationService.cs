using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Migration
{
    public interface IMigrationService
    {
        Task UpdateCurrenciesRatesAsync();
    }
}
