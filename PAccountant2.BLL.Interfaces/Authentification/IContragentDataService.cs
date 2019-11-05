using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;

namespace PAccountant2.BLL.Interfaces.Authentification
{
    public interface IContragentDataService
    {
        Task<int> CreateContragent(ContragentDataItem data);

        Task<bool> IsContragentExists(string name);

        Task<ContragentDataItem> Get(string name);

    }
}
