using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Authentification
{
    public interface IAuthentificationDataService
    {
        Task<string> RegisterUserAsync(RegisterDataItem item);

        Task<byte[]> GetPaswordByEmailAsync(string email);

        Task<bool> CheckUserExistsAsync(string email);


    }
}
