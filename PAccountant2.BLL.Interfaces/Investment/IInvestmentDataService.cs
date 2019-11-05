using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;

namespace PAccountant2.BLL.Interfaces.Investment
{
    public interface IInvestmentDataService
    {
        Task<int> AddLoanTo(AddLoanDataItem dbInvestment);
    }
}
