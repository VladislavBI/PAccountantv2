using PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Investment
{
    public interface IInvestmentService
    {
       Task<int> AddNewInvestment(int acctingId, int invType, AddInvestmentViewItem mappedModel);

        Task AddMoneyAutoAsync();
    }
}
