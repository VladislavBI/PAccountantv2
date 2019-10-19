using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountingDataService
    {
        Task CreateAccountingForUser(string newUserEmail);
    }
}
