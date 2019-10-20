using System;

namespace PAccountant2.BLL.Domain.Exceptions.Account
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException() : base("Not enough money to proceed operation")
        {

        }
    }
}
