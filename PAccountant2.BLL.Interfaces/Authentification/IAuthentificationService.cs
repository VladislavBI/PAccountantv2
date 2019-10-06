using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;

namespace PAccountant2.BLL.Interfaces.Authentification
{
    public interface IAuthentificationService
    {
        Task<string> RegisterUserAsync(RegisterViewItem item);

        Task LoginUserAsync(LoginViewItem item);
    }
}
