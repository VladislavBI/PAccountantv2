using System;

namespace PAccountant2.BLL.Domain.Exceptions.Account
{
    class SameAccountTransferException : Exception
    {
        public SameAccountTransferException() : base("transfer to same account is not possible")
        {

        }
    }
}
