using System;
using System.Collections.Generic;
using System.Text;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;

namespace PAccountant2.BLL.Interfaces.Authentification
{
    public interface IAuthentificationDataService
    {
        void RegisterUser(RegisterDataItem item);
    }
}
