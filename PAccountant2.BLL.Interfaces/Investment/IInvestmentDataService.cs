using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Investment
{
    public interface IInvestmentDataService
    {
        Task<int> AddNewInvestment(AddInvestmentDataItem dbInvestment);

        Task<IEnumerable<InvestmentDataItem>> GetAutoUpdateInvestments();

        Task UpdateInvestmentAsync(InvestmentDataItem dbInvestment);

        Task AddInvestmentOperationAsync(int dbInvestmentId, InvestmentOperationDataItem mappedOperation);
    }
}
