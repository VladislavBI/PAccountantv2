﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountService
    {
        Task AddMoneyAsync(AddMoneyViewItem addModel);
    }
}