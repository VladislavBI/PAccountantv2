using System;
using PAccountant2.BLL.Domain.Enum;

namespace PAccountant2.BLL.Domain.Exceptions.Account
{
    public class CanNotDeleteException : Exception
    {
        private const string StillMoneyOnAccount = "You still has money on account, can't delete it";

        public CanNotDeleteException(CanNotDeleteReasons reason)
        {
            var reasonMessage = String.Empty;

            switch (reason)
            {
                case CanNotDeleteReasons.NotNullBalance:
                    reasonMessage = StillMoneyOnAccount;

                    break;
            }

            throw new Exception(reasonMessage);
        }
    }
}
