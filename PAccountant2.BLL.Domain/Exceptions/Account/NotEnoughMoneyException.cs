using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.BLL.Domain.Exceptions.Account
{
    public class NotEnoughMoneyException: Exception
    {
        public NotEnoughMoneyException(): base("Not enough money to proceed operation")
        {
            
        }
    }
}
