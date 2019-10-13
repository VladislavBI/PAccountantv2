﻿using PAccountant2.Common.Encription;
using System.Linq;

namespace PAccountant2.BLL.Domain.Entities.User
{
    public class UserEntity
    {
        public string Email { get; set; }

        public byte[] Password { get; set; }

        public string StringPassword { get; set; }

        public CredentialsValueObject CreateCredentials()
        {
            Password = GetEncryptedPassword();

            var credentialsModel = new CredentialsValueObject
            {
                Email = Email,
                Password = Password
            };

            return credentialsModel;
        }

        public byte[] GetEncryptedPassword()
            => Password != null && Password.Any() ? Password : Encryption.Encrypt(StringPassword);
    }
}