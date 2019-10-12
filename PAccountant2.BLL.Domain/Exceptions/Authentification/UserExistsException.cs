using System;

namespace PAccountant2.BLL.Domain.Exceptions.Authentification
{
    public class UserExistsException : Exception
    {
        public UserExistsException(string email)
            : base($"User with email {email} already exists")
        {

        }
    }
}
