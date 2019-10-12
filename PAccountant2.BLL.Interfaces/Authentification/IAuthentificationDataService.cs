﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;

namespace PAccountant2.BLL.Interfaces.Authentification
{
    public interface IAuthentificationDataService
    {
        Task<string> RegisterUserAsync(RegisterDataItem item);

        Task<byte[]> GetPaswordByEmailAsync(string email);

    }
}
