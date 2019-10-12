using System;

namespace PAccountant2.BLL.Domain.Exceptions.Authentification
{
    public class WrongCredentialsException : Exception
    {
        public WrongCredentialsException(string userEmail)
            : base(message: $"User {userEmail} is not found or password provided is wrong")
        {

        }
    }
}
