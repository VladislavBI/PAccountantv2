using System;
using System.Collections.Generic;
using System.Text;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;

namespace PAccountant2.BLL.Interfaces.Authentification
{
    public interface IAuthentificationService
    {
        void RegisterUser(RegisterViewItem item);
    }
}
