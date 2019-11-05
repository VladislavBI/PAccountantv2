using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment;

namespace PAccountant2.BLL.Interfaces.Investment
{
    public interface IInvestmentService
    {
        Task<int> AddLoanToAsync(int acctingId, AddLoanViewItem mappedModel);
    }
}
