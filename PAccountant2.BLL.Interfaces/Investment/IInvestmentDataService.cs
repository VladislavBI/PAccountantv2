using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Investment
{
    public interface IInvestmentDataService
    {
        Task<int> AddNewInvestment(AddInvestmentDataItem dbInvestment);
    }
}
