using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Investment
{
    public interface IInvestmentDataService
    {
        Task<int> AddLoanTo(AddLoanDataItem dbInvestment);

        Task<int> AddLoanFrom(AddLoanDataItem dbInvestment);

        Task<int> AddSimpleDeposit(AddLoanDataItem dbInvestment);

        Task<int> AddComplexDeposit(AddLoanDataItem dbInvestment);
    }
}
